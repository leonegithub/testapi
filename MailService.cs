using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

public class MailService : IMailService
{
    MailSettings? _mailSettings = null;

    public MailService(IOptions<MailSettings> options)
    {
        _mailSettings = options.Value;
    }
    public bool SendMail(MailData mailData)
    {
        try
        {
            MimeMessage emailMessage = new MimeMessage();
            MailboxAddress emailFrom = new MailboxAddress(_mailSettings?.Name, _mailSettings?.EmailId);
            emailMessage.From.Add(emailFrom);
            MailboxAddress email_To = new MailboxAddress(mailData.EmailToName, mailData.EmaiToId);
            emailMessage.To.Add(email_To);
            emailMessage.Subject = mailData.EmailSubject;
            BodyBuilder emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.TextBody = mailData.EmailBody;
            emailMessage.Body = emailBodyBuilder.ToMessageBody();
            //this is the SmtpClient class from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
            SmtpClient MailClient = new SmtpClient();
            MailClient.Connect(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            MailClient.Authenticate(_mailSettings.Username, _mailSettings.Password);
            MailClient.Send(emailMessage);
            MailClient.Disconnect(true);
            MailClient.Dispose();
            return true;
        }
        catch (Exception)
        {

            throw;
        }
    }
}