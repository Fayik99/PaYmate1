using PaYmate1.Models;
using PaYmate1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaYmate1.Controllers
{

    
    

    public class HomeController : Controller
    {
        private readonly HomeService _homeService;
        private readonly BankService _bankService;
        private readonly CustomerService _customerService;

        public HomeController(HomeService homeService, BankService bankService, CustomerService customerService)
        {
            _homeService = homeService;
            _bankService = bankService;
            _customerService = customerService;
        }




        public ActionResult Index()
        {
            var customerId= (CustomerViewModel)Session["CustomerDetail"];
           ViewBag.BankUrl= _customerService.GetCustomerDetail(customerId.CustomerId).BankType;

            return View();
        }

        public ActionResult About()
        {
           

            return View();
        }

        public ActionResult Contact()
        {
           

            return View();
        }
        public ActionResult TransactionLog()
        {
            var customerDetail = (CustomerViewModel)Session["CustomerDetail"];
           var result= _homeService.GetTransactionLog(customerDetail);

            return View(result);
        }


        [HttpGet]
        public ActionResult FundTransferReport()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult FundTransferReport(DateTime FromDate, DateTime ToDate)
        {
            var customerDetail = (CustomerViewModel)Session["CustomerDetail"];
            var result = _homeService.GetFundTransferReport(customerDetail, FromDate,ToDate);

            return View(result);
        }
    }
}