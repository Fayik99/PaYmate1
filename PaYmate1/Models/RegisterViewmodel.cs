using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaYmate1.Models
{
    public class RegisterViewmodel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public int BlockStatus { get; set; }
        [Required]
        public string NIC { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string BankType { get; set; }
        [Required]
        public string PhoneType { get; set; }
        public int UserRole { get; set; }


    }
}