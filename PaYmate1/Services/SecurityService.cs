

using PaYmate1.Common;
using PaYmate1.Database;
using PaYmate1.Entities;
using PaYmate1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaYmate1.Services
{
    public class SecurityService
    {
        private readonly ApplicationContext _applicationContext;

        public SecurityService(ApplicationContext context)
        {
            _applicationContext = context;


        }
        public CustomerViewModel AuthenticateUser(LoginViewModel loginViewModel)
        {


            var result = _applicationContext.Customer.Where(x => x.UserName == loginViewModel.Username && x.Password == loginViewModel.Password)
                .Select(x => new CustomerViewModel()
                {
                    UserName = x.UserName,
                    CustomerId = x.CustomerId,
                    BankType=x.BankType,
                    UserRole=x.UserRole,
                    BlockStatus=x.BlockStatus

                }).FirstOrDefault();
            return result;
            //if (result != null)
            //{
            //    var customerViewModel = new CustomerViewModel
            //    {
            //        CustomerId = result.CustomerId,
            //        UserName = result.UserName,

            //    };

            //    return customerViewModel;

            //};
            //return new CustomerViewModel();




        }


        public void RegisterUser(RegisterViewmodel registerViewmodel)
        {
            
            var customer = new Customer();
            customer.UserName = registerViewmodel.UserName;
            customer.Password = registerViewmodel.Password;
            customer.NIC = registerViewmodel.NIC;
            customer.PhoneNumber = registerViewmodel.PhoneNumber;
            customer.Address = registerViewmodel.Address;
            customer.BankType = registerViewmodel.BankType;
            customer.PhoneType = registerViewmodel.PhoneType;
            customer.BlockStatus = (int)RecordStatusEnum.Active;
            customer.UserRole = (int)UserRoleEnum.ProfileUser;
            _applicationContext.Customer.Add(customer);
            _applicationContext.SaveChanges();






        }

    }
}

//var customer = new Customer();
//customer.UserName = registerViewmodel.UserName;
//            customer.Password = registerViewmodel.Password;
//            customer.NIC = registerViewmodel.NIC;
//            customer.PhoneNumber = registerViewmodel.PhoneNumber;
//            customer.Address = registerViewmodel.Address;
//            customer.CardType = registerViewmodel.CardType;
//            customer.CardNumber = registerViewmodel.CardNumber;
//            customer.BlockStatus = (int)RecordStatusEnum.Active;
//            customer.UserRole = (int)UserRoleEnum.ProfileUser;