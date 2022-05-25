using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Accounts.Repositories
{
    public class EmailSender
    {
        public EmailSender(){}

        

        // Must install PM> Install-Package SendGrid
        public async Task Execute(string message, string receiver)
        {
            EncryptionHelper encryptionHelper = new EncryptionHelper();
            string a = "QcXhdv4TLgn6xKN79GKqRSMOb3oNvEXXmAMMA0HotgBrh9cBkOR4E0S1Ct0QBPvp29T57umzIFCiNYVrcYw9L2vvPrHEfkcjj83BHa5Nrf2X0nzTcnlPUnfyTIh1Aq99Z0tc0vJqkM93emLQEGnCYFkz7ou6Ny4CPA587IHOLhLvaGQpd/ow52Hlf1zK2WwM";
            string value = encryptionHelper.Decrypt(a);
            var client = new SendGridClient(a);
            var from = new EmailAddress("nayeriazofeifa3003@gmail", "Planilla_UCR");
            var subject = "Account confirmation";
            var to = new EmailAddress(receiver, "");
            var plainTextContent = "";
            var htmlContent = "<strong>"+ message + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response);
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

