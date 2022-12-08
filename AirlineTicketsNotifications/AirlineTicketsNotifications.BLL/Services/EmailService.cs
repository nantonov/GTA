using AirlineTicketsNotifications.BLL.Interfaces;
using AirlineTicketsNotifications.BLL.Models.Requests;
using AirlineTicketsNotifications.Core.Constants;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AirlineTicketsNotifications.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailMessage(NotificationRequest notificationRequest, CancellationToken cancellationToken)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                EnableSsl = true
            };
            smtpClient.Credentials = new NetworkCredential(_configuration["Gmail:Address"], _configuration["Gmail:Password"]);

            var message = CreateEmailMessage(notificationRequest);

            await smtpClient.SendMailAsync(message, cancellationToken);
        }

        private MailMessage CreateEmailMessage(NotificationRequest notificationRequest)
        {
            var messageText = new StringBuilder(EmailMessages.TicketAddedMainMessage);
            messageText.AppendLine();
            messageText.Append(EmailMessages.CityAppend);
            messageText.AppendLine(notificationRequest.CityName);
            messageText.Append(EmailMessages.CityStatusAppend);
            messageText.Append(notificationRequest.StayingStatus);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["Gmail:Address"]),
                Subject = "Airline ticket",
                Body = messageText.ToString(),
                IsBodyHtml = false,
            };

            mailMessage.To.Add(notificationRequest.Email);

            return mailMessage;
        }
    }
}
