﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaYmate1.Models
{
    public class TransactionLogViewModel
    {
        public string TransactionType { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime Date { get; set; }

    }
}