using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaYmate1.Entities
{
    [Table("PhoneBill")]
    public class PhoneBill
    {
        [Key]
        public int PhoneBillId { get; set; }
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public double BillAmount { get; set; }
    }
}