using PaYmate1.Database;
using PaYmate1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaYmate1.Services
{
    public class HomeService
    {
        private readonly ApplicationContext _applicationContext;
        public HomeService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public List<TransactionLogViewModel> GetTransactionLog(CustomerViewModel customerViewModel)
        {
            var logList = _applicationContext.Log.Where(x => x.CustomerId == customerViewModel.CustomerId)
                .Select(x => new TransactionLogViewModel
                {
                    TransactionType = x.TransactionType,
                    TransactionAmount = x.Amount,
                    Date = x.Date
                }).ToList();
            return logList;
        }

        public List<FundTransferReport> GetFundTransferReport(CustomerViewModel customerViewModel, DateTime FromDate, DateTime ToDate)
        {
            var logList1 = _applicationContext.Log
                .Where(x => x.CustomerId == customerViewModel.CustomerId && x.TransactionType == "Fund Transaction" && DbFunctions.TruncateTime(x.Date) >= FromDate.Date && DbFunctions.TruncateTime(x.Date) <= ToDate)
                .Select(x => new FundTransferReport
                {
                    CustomerId = x.CustomerId.ToString(),
                    TransactionType = "FundTransfer".ToString(),
                    TransactionAmount = x.Amount,
                    Date = x.Date
                }).OrderByDescending(o=>o.Date).ToList();
            return logList1;
        }

    }
}