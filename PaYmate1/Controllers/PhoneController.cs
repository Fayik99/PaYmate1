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
    public class PhoneController : Controller
    {
        private readonly Phone _phoneService;
        private readonly CustomerService _customerService;

        public PhoneController(Phone phone, CustomerService customerService)
        {
            _phoneService = phone;
            _customerService = customerService;
        }
        // GET: Phone
        [HttpGet]
        public ActionResult Index()
        {
            var customerDetail = (CustomerViewModel)Session["CustomerDetail"];
            var phoneBill = _phoneService.GetPhoneBill(customerDetail);

            return View(phoneBill);
        }
      


        [HttpPost]
        public ActionResult phonebillpay(PhoneViewModel phoneViewModel)
        {
            if(phoneViewModel.PayingAmount<1)
            {
                this.Flash(Toastr.ERROR, "Failed", "Enter a valid amount");
                return RedirectToAction("Index");


            }
            var customerDetail = (CustomerViewModel)Session["CustomerDetail"];
           var result =_phoneService.PayPhoneBill(customerDetail, phoneViewModel);
            if(result==1)
            {
                //  this.Flash(Toastr.SUCCESS, "Success", "Bill Payment Successful");
                var customerId = (CustomerViewModel)Session["CustomerDetail"];
                var PhoneUrl = _customerService.GetCustomerDetail1(customerId.CustomerId).PhoneType;
                return Redirect(PhoneUrl);
            
            }
            else
            {
                this.Flash(Toastr.ERROR, "Failed", "Insufficient Bank Balance");

            }



            return RedirectToAction("Index");
        }
    }
}