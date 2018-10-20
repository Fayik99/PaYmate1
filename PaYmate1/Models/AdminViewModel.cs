using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaYmate1.Models
{
    public class AdminViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string BlockStatus { get; set; }
        public string PhoneNumber { get; set; }
    }
}