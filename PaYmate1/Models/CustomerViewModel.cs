using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaYmate1.Models
{
    public class CustomerViewModel
    {
        public string UserName { get; set; }
        public int BlockStatus { get; set; }
        public string NIC { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string BankType { get; set; }
        public string PhoneType { get; set; }
        public int UserRole { get; set; }
        public int CustomerId { get; set; }

    }
}