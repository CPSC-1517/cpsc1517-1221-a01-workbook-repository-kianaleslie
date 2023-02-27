using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class MultiplicationTableModel : PageModel
    {
        [BindProperty]
        public int DigitsVertically { get; set; } = 9;
        [BindProperty]
        public int DigitsHorizontally { get; set; } = 9;
        public TableType? TableTypeGen { get; private set; }
        public void OnPostMultiply() //known as a page handler
        {
            TableTypeGen = TableType.Multiplication;
        }
        public void OnPostAdd()
        {
            TableTypeGen = TableType.Addition;
        }
        public void OnPostSubtract()
        {
            TableTypeGen = TableType.Subtraction;
        }
        public void OnGet()
        {

        }
    }
}