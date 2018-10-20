using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaYmate1.Models
{
    public class BankViewModel
    {

        public string UserName { get; set; }
        public int AcoountNo { get; set; }
        public double AccountBalance { get; set; }
        public double TransferAmount { get; set; }
    }
}