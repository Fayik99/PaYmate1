using PaYmate1.Database;
using PaYmate1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaYmate1.Services
{
    public class AdminService
    {
        private readonly ApplicationContext _applicationContext;
        public AdminService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;

        }
        public List<AdminViewModel> GetAllUsers()
        {
            return _applicationContext.Customer.Where(x=>x.UserRole!=1).Select(x => new AdminViewModel
            {
                BlockStatus = x.BlockStatus == 1 ? "Active" : (x.BlockStatus == 2 ? "Deleted" : "Blocked"),
                PhoneNumber = x.PhoneNumber,
                UserId = x.CustomerId,
                UserName = x.UserName
            }).ToList();



        }

        public List<AdminViewModel> GetAllBlockedUsers()
        {
            return _applicationContext.Customer.Where(x => x.UserRole != 1 && x.BlockStatus==3).Select(x => new AdminViewModel
            {
                BlockStatus = "Blocked".ToString(),
                PhoneNumber = x.PhoneNumber,
                UserId = x.CustomerId,
                UserName = x.UserName
            }).ToList();



        }


        public List<CustomerViewModel> SearchUsers(CustomerViewModel customerViewModel)
        {
            return _applicationContext.Customer.Where(x => x.CustomerId == customerViewModel.CustomerId).Select(x=>new CustomerViewModel
           
            {
               CustomerId=x.CustomerId,
               UserName=x.UserName,
               NIC=x.NIC,
               PhoneNumber=x.PhoneNumber,
               Address=x.Address


                

            }).ToList();

            
            
        }
        }
    }

