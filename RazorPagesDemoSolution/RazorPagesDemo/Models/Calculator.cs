using Microsoft.AspNetCore.Mvc;

namespace RazorPagesDemo.Models
{
    public class Calculator
    {
        public int NumberOne { get; set; }
        public int NumberTwo { get; set; }  

        public int Add() => NumberOne + NumberTwo;
        public int Subtract() => NumberOne - NumberTwo;
        public int Multiply () => NumberOne * NumberTwo;
        public int Divide() => NumberOne / NumberTwo;
    }
}