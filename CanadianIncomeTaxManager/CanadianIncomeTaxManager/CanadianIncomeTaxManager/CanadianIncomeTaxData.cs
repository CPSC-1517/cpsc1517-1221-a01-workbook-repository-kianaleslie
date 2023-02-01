using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadianIncomeTaxManager
{
    public struct CanadianIncomeTaxData
    {
        public string RegionAbbreviation { get; set; }  
        public string RegionName  { get;  set; }
        public int TaxYear { get;  set; }
        public decimal StartingIncome { get;  set; }
        public decimal EndingIncome { get;  set; }
        public double TaxRate { get;  set; }
        public decimal BaseTaxAmount { get;  set; }

    }
}
