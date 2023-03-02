using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NHLSystemClassLibrary;

namespace NHLWebApp.Pages
{
    public class NhlPlayersModel : PageModel
    {
        private IWebHostEnvironment WebHostEnvironment;

        public NhlPlayersModel(IWebHostEnvironment env)
        {
            this.WebHostEnvironment = env;
        }

        public List<Player> PlayerList { get; private set; } = new List<Player>();

        public void OnGet()
        {
            string wwwPath = WebHostEnvironment.WebRootPath;
            string csvFilePath = Path.Combine(wwwPath, @"data\OilersPlayers.txt");
            string[] allLines = System.IO.File.ReadAllLines(csvFilePath);
            foreach (var currentLine in allLines)
            {
                try
                {
                    Player currentPlayer = null;
                    if (Player.TryParse(currentLine, out currentPlayer))
                    {
                        PlayerList.Add(currentPlayer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from file with exception {ex.Message}");
                }
            }
        }
    }
}
