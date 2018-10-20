using PaYmate1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaYmate1.Database
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(): base ("PaYmateContext")
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<PhoneBill> PhoneBill { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Room> Room { get; set; }

    }
}