using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaYmate1.Entities
{
    [Table("Log")]
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public int  CustomerId { get; set; }
        public string  TransactionType { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}