using PaYmate1.Database;
using PaYmate1.Entities;
using PaYmate1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaYmate1.Services
{
    public class BankService
    {

        private readonly ApplicationContext _applicationContext;
        public BankService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;

        }
        public BankViewModel GetBankBalance(CustomerViewModel customerViewModel)
        {
            var bankInfo = _applicationContext.BankAccount.FirstOrDefault(x => x.CustomerId == customerViewModel.CustomerId);
            var bankViewModel = new BankViewModel
            {
                AcoountNo = bankInfo.AccountNumber,
                AccountBalance = bankInfo.AccountBalance,

            };

            return bankViewModel;
        }
        public int FundTransfer(CustomerViewModel customerViewModel, BankViewModel bankViewModel)
        {
            //var customerBankInfo = _applicationContext.BankAccount.FirstOrDefault(x => x.CustomerId == customerViewModel.CustomerId);
            //var validAccount = _applicationContext.BankAccount.FirstOrDefault(x => x.AccountNumber == bankViewModel.AcoountNo);

            //if (validAccount != null && customerBankInfo.AccountBalance >= bankViewModel.TransferAmount)
            //{
            //validAccount.AccountBalance += bankViewModel.TransferAmount;
            //customerBankInfo.AccountBalance -= bankViewModel.TransferAmount;
            var logInfo = new Log
            {
                CustomerId = customerViewModel.CustomerId,
                TransactionType = "Fund Transaction",
                Amount = bankViewModel.TransferAmount,
                Date = DateTime.Now
            };
            _applicationContext.Log.Add(logInfo);
            _applicationContext.SaveChanges();
            return 1; //Success
        }
        //else if(validAccount==null)
        //{
        //    return 2; // Invalid Account Number

        //}
        //else 
        //{

        //    return 3; // Insufficient Balance
        //}

    }

    //public BankViewModel GetBankDetail(int customerId)
    //{
    //   var result= _applicationContext.BankAccount.FirstOrDefault(x => x.CustomerId == customerId);


    //}
}
