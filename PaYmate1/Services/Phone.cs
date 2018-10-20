using PaYmate1.Database;
using PaYmate1.Entities;
using PaYmate1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaYmate1.Services
{
    public class Phone
    {
        private readonly ApplicationContext _applicationContext;
        public Phone(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public PhoneViewModel GetPhoneBill(CustomerViewModel customerViewModel)
        {

            var phoneInfo = _applicationContext.PhoneBill.FirstOrDefault(x => x.CustomerId == customerViewModel.CustomerId);
            var PhoneViewModel = new PhoneViewModel
            {
                PhoneNumber = phoneInfo.PhoneNumber,
                BillAmount = phoneInfo.BillAmount,
                

            };

            return PhoneViewModel;


        }
        public int PayPhoneBill(CustomerViewModel customerViewModel, PhoneViewModel phoneViewModel)
        {

            var phoneInfo = _applicationContext.PhoneBill.FirstOrDefault(x => x.CustomerId == customerViewModel.CustomerId);
            var bankInfo = _applicationContext.BankAccount.FirstOrDefault(x => x.CustomerId == customerViewModel.CustomerId);
            if (bankInfo!=null &&  bankInfo.AccountBalance > phoneViewModel.PayingAmount)
            {
                bankInfo.AccountBalance -= phoneViewModel.PayingAmount;
                phoneInfo.BillAmount -= phoneViewModel.PayingAmount;
                var logInfo = new Log
                {
                    CustomerId = customerViewModel.CustomerId,
                    TransactionType = "Phone Bill Payment",
                    Amount = phoneViewModel.PayingAmount,
                    Date = DateTime.Now
                };
                _applicationContext.Log.Add(logInfo);
                _applicationContext.SaveChanges();
                return 1;
            }
            else
            {
                return 2;

            }



        }
    }
}