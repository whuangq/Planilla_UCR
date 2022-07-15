using Domain.Subscriptions.Entities;
using Domain.LegalDeductions.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Application.Email.Implementations
{
    public class EmailServices : IEmailServices
    {
        private EmailSender _emailSender = new EmailSender();

        public void SendConfirmationEmail(string message, string destiny)
        {
            string htmlContent = "<section>" + "<div>" + "<header style = BACKGROUND-COLOR:#00695c>" + "<center>" + "<FONT SIZE=5 COLOR=#FFFFFF>" + 
                    "<strong>" + "PlanillaUCR" + "</strong>" + "</FONT>" + "</center>" + "<br>" + "</br>" + "</div>" + "</header>" + "<br>" +
                    "</br>" + "<div>" + "¡Gracias por registrarte en PlanillaUCR! " + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + 
                    "<div>" + "<strong>" + message + "</strong>" + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + 
                    "Recibiste este email porque te registraste en una cuenta de PlanillaUCR con esta dirección de email. " +
                    "Si piensas que fue un error, por favor, ignora este email. No te preocupes la cuenta aún no ha sido creada." +
                    "</div>" + "<div>" + "<FONT COLOR=#00695c>" + "PlanillaUCR" + "</FONT>" + "<br>" + "</br>" + "</div>" + "</section>";
            string subject = "Confirmación de registro Planilla_UCR";
            _emailSender.SendMail(destiny, subject, htmlContent);
        }

        public void SendFiredEmployeeEmail(EmailObject emailData)
        {
            string employeeName = emailData.EmployeeName;
            string employerName = emailData.EmployerName;
            string projectName = emailData.ProjectName;
            string message = emailData.Message;
            string destiny = emailData.Destiny;
            string htmlContent = "<section>" + "<div>" + "<header style = BACKGROUND-COLOR:#00695c>" + "<center>" + "<FONT SIZE=5 COLOR=#FFFFFF>" + "<strong>" + "PlanillaUCR" + 
                "</strong>" + "</FONT>" + "</center>" + "</div>" + "</header>" + "</section>" + "<br>" + "</br>" + "<section>" + "<div>" + "Señor(a): " + employeeName + "<br>" + 
                "</br>" + "</div>" + "</section>" + "<section>" + "<div>" +  "Reciba un cordial saludo," + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + 
                "Yo," + " " + employerName + " a cargo de " + projectName + " me dirijo a usted con todo el respeto que se merece, para comunicarle que desafortunadamente debemos " +
                " de prescindir de sus servicios en la compañía." + "<section>" + "<div>" + "Queremos dejar en claro que la causa del despido no tiene nada que ver con su " +
                "comportamiento dentro de la empresa, por el contrario, consideramos que usted es un excelente empleado, cumplidor de su deber y le agradecemos su compromiso. " +
                "No obstante, nos vimos obligados a tomar esta decisión por " + message + "."+ "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + "De antemano " +
                "agradecemos su comprensión y le agradecemos profundamente todo lo que aportó a la empresa durante el ejercicio de su labor. Asimismo, es importante que tenga en " +
                "cuenta que le pagaremos todo lo relacionado a nuestras obligaciones." + "</div>" + "<section>" + "<div>" + "No siendo más, nos despedimos de usted con un gran " +
                "agradecimiento por su labor, y deseando que encuentre un nuevo trabajo acorde a su potencial." + "<br>" + "</br>" + "</div>" + "</section>" +  "<section>" + "<div>" +
                "Cordialmente, " + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + employerName + "<br>" + "</br>" + "</div>" + "</section>";
            string subject = "Carta de despido";
            _emailSender.SendMail(destiny, subject, htmlContent);
        }

        public void SendLastPayEmail(EmailObject emailData, IList<string> rows, IList<Subscription> deductions, IList<LegalDeduction> legalDeductions)
        {
            string employeeName = rows[0].Split("#")[0];
            string contractType = rows[0].Split("#")[1];
            string date = rows[0].Split("#")[2];
            string projectName = rows[1].Split("#")[0];
            string salary = rows[1].Split("#")[2];
            string netSalary = rows[2].Split("#")[2];
            string htmlContent = File.ReadAllText("../Server_Planilla/wwwroot/emails/LastPayEmail.html");
            htmlContent = htmlContent.Replace("[employeeName]", employeeName);
            htmlContent = htmlContent.Replace("[contractType]", contractType);
            htmlContent = htmlContent.Replace("[Date]", date);
            htmlContent = htmlContent.Replace("[projectName]", projectName);
            htmlContent = htmlContent.Replace("[salary]", salary);
            htmlContent = htmlContent.Replace("[netSalary]", netSalary);

            htmlContent = htmlContent.Replace("[Heading]", "Reporte de último pago en " + projectName.Replace("Proyecto: ", "") + " el " + date.Replace("Fecha: ", ""));
            string legal = string.Empty;
            foreach (LegalDeduction tax in legalDeductions)
            {
                legal += "<tr>";
                legal += "<td>" + tax.DeductionName + "</td>";
                legal += "<td>" + "₡" + string.Format("{0:N}", tax.Cost) + " </td>";
                legal += "</tr>";
            }
            htmlContent = htmlContent.Replace("[Legal]", legal);

            string voluntary = string.Empty;
            foreach (Subscription subscription in deductions)
            {
                voluntary += "<tr>";
                voluntary += "<td>" + subscription.SubscriptionName + "</td>";
                voluntary += "<td>" + "₡" + string.Format("{0:N}", subscription.Cost) + " </td>";
                voluntary += "</tr>";
            }
            htmlContent = htmlContent.Replace("[Voluntary]", voluntary);

            _emailSender.SendMail(emailData.Destiny, "Último pago", htmlContent);
        }

        public void SendPaymentBreakdownEmail(EmailObject emailData, IList<LegalDeduction> summaryTable, IList<LegalDeduction> salariesTable, IList<LegalDeduction> deductionTable, IList<LegalDeduction> benefitsTable)
        {
            string projectName = summaryTable.ElementAtOrDefault(0).DeductionName;
            string date = summaryTable.ElementAtOrDefault(2).DeductionName;
            string htmlContent = File.ReadAllText("../Server_Planilla/wwwroot/emails/PlanillaReportEmail.html");
            htmlContent = htmlContent.Replace("[date]", date);
            htmlContent = htmlContent.Replace("[projectName]", projectName);

            htmlContent = htmlContent.Replace("[Heading]", "Reporte de pagos en " + projectName.Replace("Proyecto: ", "") + " el " + date.Replace("Fecha: ", ""));
            string summary = string.Empty;
            string salaries = string.Empty;
            string benefits = string.Empty;
            string deductions = string.Empty;


            summary += "<tr>";
            summary += "<td>" + summaryTable.ElementAtOrDefault(3).DeductionName + "</td>";
            summary += "<td>" + "₡" + string.Format("{0:N}", summaryTable.ElementAtOrDefault(3).Cost) + " </td>";
            summary += "</tr>";
            
            htmlContent = htmlContent.Replace("[summary]", summary);

            foreach (LegalDeduction salary in salariesTable)
            {
                salaries += "<tr>";
                salaries += "<td>" + salary.DeductionName + "</td>";
                salaries += "<td>" + "₡" + string.Format("{0:N}", salary.Cost) + " </td>";
                salaries += "</tr>";
            }

            htmlContent = htmlContent.Replace("[salaries]", salaries);


            foreach (LegalDeduction benefit in benefitsTable)
            {
                benefits += "<tr>";
                benefits += "<td>" + benefit.DeductionName + "</td>";
                benefits += "<td>" + "₡" + string.Format("{0:N}", benefit.Cost) + " </td>";
                benefits += "</tr>";
            }
            htmlContent = htmlContent.Replace("[benefits]", benefits);


            foreach (LegalDeduction deduction in deductionTable)
            {
                deductions += "<tr>";
                deductions += "<td>" + deduction.DeductionName + "</td>";
                deductions += "<td>" + "₡" + string.Format("{0:N}", deduction.Cost) + " </td>";
                deductions += "</tr>";
            }
            htmlContent = htmlContent.Replace("[deductions]", deductions);

            _emailSender.SendMail(emailData.Destiny, "Reporte planilla", htmlContent);
        }
    }
}
