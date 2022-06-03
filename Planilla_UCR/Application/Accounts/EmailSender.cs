using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace Application.Accounts
{
    public class EmailSender
    {
        public EmailSender() { }
        private string user = "i/MVRXAfhPPNVbUc0F0ILYn2xj4vSGjeCu1sXhBD7I0fFZBI5H7wD/8GHhHlMzPo";
        private string key = "p/ZNHkzgSrYi7TogkFKN7qRHrBb0lc/XTw8DmUZ2Jro=";
        public void SendMail(string textMessage, string email)
        {
            try
            {
                var encriptor = new EncryptionHelper();
                var htmlContent = "<section>" + "<div>" + "<center>" + "<FONT SIZE=4 COLOR=#00695c>" + "<strong>" + "Planilla_UCR" +
                    "</strong>" + "</FONT>" + "</center>" + "<br>" + "</br>" + "</div>" + "<div>" + "<center>" + "¡Ya casi! " + 
                    "</center>" + "<br>" + "</br>" + "</div>" + "<div>" + "<center>" + "¡Gracias por registrarte en Planilla_UCR! " +
                    "</center>" + 
                    "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + "<center>" + "<strong>" + textMessage + 
                    "</strong>" + "</center>" + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" +
                    "Recibiste este email porque te registraste en una cuenta de Planilla_UCR con esta dirección de email. " +
                    "Si piensas que fue un error, por favor, ignora este email. No te preocupes la cuenta aún no ha sido creada." +
                    "</div>" + "<div>" + "<FONT COLOR=#00695c>" + "Planilla_UCR" + "</FONT>" + "<br>" + "</br>" + "</div>" + "</section>";
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(encriptor.Decrypt(user));
                message.To.Add(new MailAddress(email));
                message.Subject = "Confirmación de registro Planilla_UCR";
                message.IsBodyHtml = true;
                message.Body = htmlContent;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(encriptor.Decrypt(user), encriptor.Decrypt(key));
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }

    public class EncryptionHelper
    {
        public EncryptionHelper() { }
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}

