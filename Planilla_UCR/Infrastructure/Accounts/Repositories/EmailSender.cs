using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Accounts.Repositories
{
    public class EmailSender
    {
        public EmailSender(){}


        // Must install PM> Install-Package SendGrid
        public async Task Execute(string message, string receiver)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("stevenleonel22201@gmail.com", "Planilla_UCR");
            var subject = "Account confirmation";
            var to = new EmailAddress(receiver, "");
            var plainTextContent = "";
            var htmlContent = "<strong>"+ message + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response);
        }
    }
}
