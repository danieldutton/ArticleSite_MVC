using ArticleSite.Services.Interfaces;
using System.Net.Mail;

namespace ArticleSite.Services.Email
{
    public class Emailer : IEmailer
    {
        private EmailSettings _emailSettings;

        public EmailSettings EmailSettings
        {
            get { return _emailSettings; }
            set { _emailSettings = value; }
        }

        public Contact Contact { get; set; }


        public Emailer(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public void Message()
        {
            var smtp = new SmtpClient(_emailSettings.SmtpServer);

            var mail = new MailMessage
            {
                From = new MailAddress(Contact.Email),
                Subject = Contact.Subject,
                Body = Contact.Message
            };

            mail.To.Add(_emailSettings.TargetEmail);
            smtp.Send(mail);
        }
    }
}
