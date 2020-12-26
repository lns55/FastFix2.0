﻿using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace FastFix2._0.Infrastructure.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("FastFix Crew", "luzginnick55@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.sendgrid.net", 587, false);
                await client.AuthenticateAsync("apikey", "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");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
