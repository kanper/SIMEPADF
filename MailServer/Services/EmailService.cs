using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using MailServer.Models;
using MimeKit;
using MimeKit.Text;

namespace MailServer.Services
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
    
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;
 
        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
 
        public List<EmailMessage> ReceiveEmail(int maxCount = 10)
        {
            using (var emailClient = new Pop3Client())
            {
                emailClient.Connect(_emailConfiguration.PopServer, _emailConfiguration.PopPort, true);
 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
 
                emailClient.Authenticate(_emailConfiguration.PopUsername, _emailConfiguration.PopPassword);
 
                List<EmailMessage> emails = new List<EmailMessage>();
                for(int i=0; i < emailClient.Count && i < maxCount; i++)
                {
                    var message = emailClient.GetMessage(i);
                    var emailMessage = new EmailMessage
                    {
                        Content = !string.IsNullOrEmpty(message.HtmlBody) ? message.HtmlBody : message.TextBody,
                        Subject = message.Subject
                    };
                    emailMessage.ToAddresses.AddRange(message.To.Select(x => (MailboxAddress)x).Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
                    emailMessage.FromAddresses.AddRange(message.From.Select(x => (MailboxAddress)x).Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
                    emails.Add(emailMessage);
                }
 
                return emails;
            }
        }
 
        public void Send(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            //message.To.Add(new MailboxAddress("E-mail Recipient Name", "luis.jca96@gmail.com"));
            //message.From.Add(new MailboxAddress("E-mail From Name", "luis.debca@gmail.com"));
 
            message.Subject = emailMessage.Subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content,
            };
            
 
            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect("smtp.gmail.com", 587, false);
 
                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate("simepadf.ues@gmail.com","jvtRLqyEs7ih6b6");
                emailClient.Send(message);
                emailClient.Disconnect(true);
            }
        }
    }
}