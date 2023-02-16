using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class SimpleCalculatorModel : PageModel
    {
        [BindProperty]
        public Calculator Calculator { get; set; }
        [BindProperty]
        public string? InfoMessage { get; private set; }
        [BindProperty]
        public string? ErrorMessage { get; private set; }
        public void OnGet()
        {

        }
        public void OnPostAdd()
        {
            InfoMessage = $"{Calculator.NumberOne} + {Calculator.NumberTwo} = {Calculator.Add()}";
        }
        public void OnPostSubtract()
        {
            InfoMessage = $"{Calculator.NumberOne} - {Calculator.NumberTwo} = {Calculator.Subtract()}";
        }
        public void OnPostMultiply()
        {
            InfoMessage = $"{Calculator.NumberOne} * {Calculator.NumberTwo} = {Calculator.Multiply()}";
        }
        public void OnPostDivide()
        {
            try
            {
                InfoMessage = $"{Calculator.NumberOne} / {Calculator.NumberTwo} = {Calculator.Divide()}";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}