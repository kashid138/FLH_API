using Application.Abstractions;
using DataAccess;
using Domain.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MimeKit.Utils;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

public class MailRepository : IMailRepository
{
    private readonly LFHDBContext _context;

    // Ideally, move these to configuration
    private readonly IConfiguration _configuration;


    public MailRepository(LFHDBContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;

    }

    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _smtpPort = 587; // TLS port
    private readonly string _smtpUser = "ykashid9@gmail.com"; // Your Gmail address
    private readonly string _smtpPass = "qjbghjomvbgknaxf"; // App-specific password

    public async Task SendEmailAsync(SendMail sm)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Lets Fly Holidays", sm.From));
        message.To.Add(new MailboxAddress("", sm.To));
        message.Subject = "Welcome to Lets Fly Holidays!!";

        // Use a free demo logo URL
        var logoUrl = "https://via.placeholder.com/150x50?text=Lets+Fly+Holidays+Logo"; // Replace with any demo logo URL

        // Create the email body with inline CSS and an external logo
        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = $@"
        <div style='font-family: Arial, sans-serif; font-size: 16px; color: #333;'>
            <div style='text-align: center;'>
                <img src='{logoUrl}' alt='Lets Fly Holidays Logo' style='width: 150px;'/>
            </div>
            <h1 style='text-align: center; color: #0066cc;'>Welcome to Lets Fly Holidays!</h1>
            <p>Dear {sm.To},</p>
            <p>
                We're thrilled to have you on board! At Lets Fly Holidays, we strive to make your travel experiences
                unforgettable. Thank you for registering with us.
            </p>
            <p>
                Feel free to explore our exclusive deals and tailor-made travel packages just for you.
                Should you need any assistance, our customer support team is here to help.
            </p>
            <p style='text-align: center;'>
                <a href='https://www.letsflyholidays.com' style='display: inline-block; background-color: #e08d66; color: #fff; padding: 10px 20px; text-decoration: none; border-radius: 5px;'>
                    Explore Now
                </a>
            </p>
            <p>Best Regards,</p>
            <p>The Lets Fly Holidays Team</p>
        </div>
    "
        };

        message.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            client.Connect(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);

            // Authenticate using the app-specific password
            client.Authenticate(_smtpUser, _smtpPass);

            await client.SendAsync(message);
            client.Disconnect(true);
        }
    }


}
