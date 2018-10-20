using PaYmate1.Models;
using PaYmate1.Services;
using RedWillow.MvcToastrFlash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaYmate1.Controllers
{
    public class BankController : Controller
    {
        private readonly BankService _bankService;
        private readonly CustomerService _customerService;

        // GET: Bank
        public BankController(BankService bankService,CustomerService customerService)
        {

            _bankService = bankService;
            _customerService = customerService;

        }
        public ActionResult GetBankBalance()
        {
            var customerDetail = (CustomerViewModel)Session["CustomerDetail"];
            var bankResult = _bankService.GetBankBalance(customerDetail);
            bankResult.UserName = customerDetail.UserName;
            return View(bankResult);
        }
        [HttpGet]
        public ActionResult FundTransfer()
        {
            var customerId = (CustomerViewModel)Session["CustomerDetail"];
            ViewBag.BankUrl = _customerService.GetCustomerDetail(customerId.CustomerId).BankType;

            return View();
        }


        [HttpPost]
        public ActionResult FundTransfer(BankViewModel bankViewModel)
        {
            if (bankViewModel.TransferAmount < 1)
            {

                this.Flash(Toastr.ERROR, "Failed", "Enter a valid amount");
                return RedirectToAction("FundTransfer");

                
            }
            var customerDetail = (CustomerViewModel)Session["CustomerDetail"];
            var transactionStatus = _bankService.FundTransfer(customerDetail, bankViewModel);
            
            if(transactionStatus==1)
            {
                //  this.Flash(Toastr.SUCCESS,"Success","Fund Transfer Successful");
                return Redirect(customerDetail.BankType);
            }
           else if (transactionStatus == 2)
            {
                this.Flash(Toastr.ERROR, "Failed", "Invalid Account Number");
            }
            else
            {
                this.Flash(Toastr.ERROR, "Failed", "Insufficient Balance");
            }
            return View();
        }
    }
}