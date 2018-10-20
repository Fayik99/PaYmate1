using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaYmate1.Entities
{ 
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int UserRole { get; set; }
        public int BlockStatus { get; set; }
        public string NIC { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string BankType { get; set; }
        public string PhoneType { get; set; }





    }
}