
namespace Application.Email
{
    public interface IEmailServices
    {
        public void SendConfirmationEmail(string message, string destiny);

        public void SendFiredEmployeeEmail(EmailObject emailData);
    }
}
