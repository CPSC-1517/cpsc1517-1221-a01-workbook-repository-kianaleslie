using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;

namespace RazorPagesDemo.Pages
{
    public class ContactMeModel : PageModel
    {
        private readonly IConfiguration Configuration;
        public ContactMeModel(IConfiguration configuration)
        {
          this.Configuration = configuration;
        } //constructor dependancy injection
        [BindProperty]
        public string? Name { get; set; }
        [BindProperty]
        public string? Email { get; set; }
        [BindProperty]
        public string? Comments { get; set; }
        [BindProperty]
        public Boolean Promotions { get; set; } = true;
        [BindProperty]
        public string? InfoMessage { get; private set; }
        [BindProperty]
        public string? ErrorMessage { get; set; }
        public void OnPostSendMessage()
        {
            string promo = (Promotions == true) ? "Yes" : "No";
            InfoMessage = $"Name: {Name} <br />"
                            + $"Email: {Email} <br />"
                            + $"Comments: {Comments}"
                            + $"Subscribe to mail: {promo}";

            SmtpClient sendMail = new();
            sendMail.Host = Configuration["MailServerSettings:SmtpHost"];
            sendMail.Port = int.Parse(Configuration["MailServerSettings:Port"]);
            sendMail.EnableSsl = bool.Parse(Configuration["MailServerSettings:EnableSsl"]);

            NetworkCredential mailCred = new();
            mailCred.UserName = Configuration["MailServerSettings:Username"];
            mailCred.Password = Configuration["MailServerSettings:AppPassword"];
            sendMail.Credentials = mailCred;

            string mailToAddress = Email ?? Configuration["MailServerSettings:Email"];
            string mailFromAddress = Configuration["MailServerSettings:Email"];

            MailMessage mailMessage = new MailMessage(mailFromAddress, mailToAddress);
            mailMessage.Subject = "CPSC1517 new contact me from submission";
            mailMessage.Body = InfoMessage;
            try
            {
                sendMail.Send(mailMessage);
                Name = null;
                Email = null;
                Comments = null;
                InfoMessage = "Your message has been sent.";
            }
            catch(Exception ex)
            {
                ErrorMessage = $"Error sending mail with exception: {ex.Message}";
            }
        }
        public IActionResult OnPostClear() //need in order to update page info - forces onget to be reloaded
        {
            Name = null;
            Email = null;
            Comments = null;
            Promotions = true;
            return RedirectToPage();
        }
        public void OnGet()
        {
        }
    }
}