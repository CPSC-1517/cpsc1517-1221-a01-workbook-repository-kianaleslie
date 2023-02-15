using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public DateTime CurrentDateTime { get; private set; } = DateTime.Now;
        public int LuckyNumber { get; private set; } = 25;
        public void OnGet()
        {
            var rand = new Random();
            LuckyNumber = rand.Next(1, 101);
        }
    }
}