using GYM_Management_System.Data;
using GYM_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GYM_Management_System.Models.Services
{
    public class SubscriptionCheckBackgroundService : BackgroundService
    {
        private readonly IEmail _email;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SubscriptionCheckBackgroundService(IEmail email, IServiceScopeFactory serviceScopeFactory)
        {
            _email = email;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                var fivePM = new DateTime(now.Year, now.Month, now.Day, 17, 0, 0);

                if (now > fivePM)
                {
                    fivePM = fivePM.AddDays(1);
                }

                var delay = fivePM - now;

                await Task.Delay(delay, stoppingToken);

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetRequiredService<GymDbContext>();
                    await CheckSubscriptions(_context);
                }
            }
        }

        public async Task CheckSubscriptions(GymDbContext _context)

        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime targerDate = currentDate.AddDays(7);

            var clients = await _context.Clients
                .Where(subex => subex.SubscriptionExpiry.Date == targerDate)
                .ToListAsync();



            foreach (var client in clients)
            {
                var user = await _context.Users.FindAsync(client.UserId);
                string emailSubject = "Subscription Expiry Notice";
                string emailBody = "<!DOCTYPE html>\r\n" +
    "<html>\r\n" +
    "<head>\r\n" +
    "    <style>\r\n" +
    "        body {\r\n" +
    "            font-family: Arial, sans-serif;\r\n" +
    "        }\r\n" +
    "        .email-container {\r\n" +
    "            width: 80%;\r\n" +
    "            margin: auto;\r\n" +
    "            padding: 20px;\r\n" +
    "            border: 1px solid #ddd;\r\n" +
    "            border-radius: 5px;\r\n" +
    "            background-color: #f9f9f9;\r\n" +
    "        }\r\n" +
    "        .email-header {\r\n" +
    "            text-align: center;\r\n" +
    "            color: #333;\r\n" +
    "        }\r\n" +
    "        .email-body {\r\n" +
    "            margin-top: 20px;\r\n" +
    "            line-height: 1.6;\r\n" +
    "        }\r\n" +
    "    </style>\r\n" +
    "</head>\r\n" +
    "<body>\r\n" +
    "    <div class=\"email-container\">\r\n" +
    "        <h2 class=\"email-header\">Subscription Expiry Notice</h2>\r\n" +
    "        <div class=\"email-body\">\r\n" +
    $"            <p>Dear {client.Name},</p>\r\n" +
    $"            <p>I hope this message finds you well. This is a friendly reminder that your subscription is due to expire on {client.SubscriptionExpiry.ToString("dd/MM/yyyy")}. We value your membership and would like to invite you to renew your subscription at your earliest convenience.</p>\r\n" +
    "            <p>If you find this email in your spam folder, please mark it as 'Not Spam' and add our email address to your contact list to ensure our future communications reach your inbox.</p>\r\n" +
    "            <p>Best regards,</p>\r\n" +
    "            <p>GYM Management System</p>\r\n" +
    "        </div>\r\n" +
    "    </div>\r\n" +
    "</body>\r\n" +
    "</html>";






                await _email.SendEmail(user.Email, client.Name, emailSubject, emailBody);
            }
        }
    }
}