using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NHLWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty] //aloows us to bind the name property to the name field not the ID field
        //Define an auto implemented property for username
        public string Username { get; set; }
        //Define an auto implemented property for feedback messages
        public string? InfoMessage { get; private set; }
        public void OnPost()
        {
            //Generate a lucky number between 1 and 50 (inlcusive)
            //and send a feedback message with format:
            //"Hello {username}. Your lucky number is {luckynumber}!"
           
            var rand = new Random();
            var luckyNumber = rand.Next(1, 51);
            InfoMessage = $"Hello {Username}. Your lucky number is {luckyNumber}!";
        }
        public void OnGet()
        {

        }
    }
}