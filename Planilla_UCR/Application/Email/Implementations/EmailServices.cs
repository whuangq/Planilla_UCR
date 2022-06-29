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
    }
}
