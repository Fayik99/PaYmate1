using PaYmate1.Common;
using PaYmate1.Database;
using PaYmate1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaYmate1.Services
{
    public class CustomerService
    {
        private readonly ApplicationContext _applicationContext;
        public CustomerService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;

        }

        public CustomerViewModel GetCustomerDetail(int customerId)
        {
            var result = _applicationContext.Customer.FirstOrDefault(x => x.CustomerId == customerId && x.BlockStatus == (int)RecordStatusEnum.Active);
            return new CustomerViewModel
            {
               BankType=result.BankType
              
               
            };
          
        }
        public CustomerViewModel GetCustomerDetail1(int customerId)
        {
            var result = _applicationContext.Customer.FirstOrDefault(x => x.CustomerId == customerId && x.BlockStatus == (int)RecordStatusEnum.Active);
            return new CustomerViewModel
            {
                PhoneType = result.PhoneType


            };

        }



    }
}