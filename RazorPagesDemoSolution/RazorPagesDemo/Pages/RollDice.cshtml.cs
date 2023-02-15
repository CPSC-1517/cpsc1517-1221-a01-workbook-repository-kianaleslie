using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class RollDiceModel : PageModel
    {
        public int DiceFaceValue { get; private set; }
        public string DiceFaceImage { get; private set; }
        public string[] DiceImages =
        {
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-one.png",
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-two.png",
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-three.png",
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-four.png",
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-five.png",
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-six.png"
        };
        public void OnPost()
        {
            var random = new Random();
            DiceFaceValue = random.Next(1, 7);
            DiceFaceImage = DiceImages[DiceFaceValue - 1];
        }
        public void OnGet()
        {
            DiceFaceImage = "/img/icons/ffffff/000000/1x1/delapouite/rolling-dices.png";
        }
    }
}
