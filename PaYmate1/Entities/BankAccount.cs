using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaYmate1.Entities
{
    [Table("BankAccount")]
    public class BankAccount
    { 
        [Key]
        public int BankAccountId { get; set; }
        public int CustomerId { get; set; }
        public int AccountNumber { get; set; }
        public double AccountBalance { get; set; }

    }
}