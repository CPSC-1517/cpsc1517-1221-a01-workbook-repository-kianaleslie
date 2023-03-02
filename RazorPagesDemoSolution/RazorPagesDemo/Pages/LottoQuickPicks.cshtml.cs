using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class LottoQuickPicksModel : PageModel
    {
        [BindProperty]
        public string? Name { get; set; }
        [BindProperty]
        public LottoType Lotto { get; private set; }
        [BindProperty]
        public int QuickPicks { get; set; } = 3;
        //properties that can be get from the page 
        public string? InfoMessage { get; private set; }
        public string? ErrorMessage { get; private set; }
        public List<int[]> QuickPickNumbers { get; private set; } = new();

        //post handler methods
        public void OnPostGenNums()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                ErrorMessage = "<strong>Name</strong> is required and cannot be blank.";
            }
            else
            {
                //remove any previous QPN
                QuickPickNumbers.Clear();

                //random object for random num gen
                Random random = new();

                //a new array of int for each QPN
                for(int count = 1; count <= QuickPicks; count++)
                {
                    //gen 6 unique nums between 1 and 49 for lotto 6/49
                    if(Lotto == LottoType.Lotto649)
                    {
                        int[] currentLottoQP = new int[6];
                        for(int counter = 1; counter <= 6; counter++)
                        {
                            int rand = random.Next(1, 50);
                            while(currentLottoQP.ToList().Any(number => number == rand)) /*OR currentLottoQP.ToList().Contains(rand)*/
                            {
                                random.Next(1, 50);
                            }
                            currentLottoQP[counter - 1] = rand;
                        }
                        //sort the contents
                        Array.Sort(currentLottoQP);
                        //add the array to the list
                        QuickPickNumbers.Add(currentLottoQP);
                    }
                    //gen 7 unique nums between 1 and 50 for lotto max
                }
                InfoMessage = $"Hi {Name}! :)";
            }
        }
        public void /*IActionResult*/ OnPostClear()
        {
            Name = null;
            InfoMessage = null;
            ErrorMessage = null;
            //return RedirectToPage();
        }
        public void OnGet()
        {

        }
    }
}