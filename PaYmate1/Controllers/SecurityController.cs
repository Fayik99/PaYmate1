using PaYmate1.Models;
using PaYmate1.Services;
using RedWillow.MvcToastrFlash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PaYmate1.Controllers
{
    public class SecurityController : Controller
    {
        private readonly SecurityService _securityService;
        public SecurityController(SecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel == null || loginViewModel.Password == null || loginViewModel.Username == null)
            {
                this.Flash(Toastr.ERROR, "Failed", "Invalid Username/Password");
                // return RedirectToAction("Login", "Security");
                return View(new LoginViewModel());
            }
            loginViewModel.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(loginViewModel.Password, "SHA1");
            var loginresult = _securityService.AuthenticateUser(loginViewModel);


            if (loginresult != null && loginresult.UserRole == 2 && loginresult.BlockStatus == 1)

            {
                Session.Timeout = 200000;
                Session["CustomerDetail"] = loginresult;
                Session["LoggedInAs"] = loginresult.UserName;
                return RedirectToAction("Index", "Home");
            }
            else if (loginresult != null && loginresult.UserRole == 1)
            {

                return RedirectToAction("Admin", "Admin");
            }

            else if (loginresult != null && loginresult.UserRole == 2 && loginresult.BlockStatus == 3)
            {

                this.Flash(Toastr.ERROR, "Failed", "This User is Blocked");
                return RedirectToAction("Login", "Security");

            }
            else
            {

                this.Flash(Toastr.ERROR, "Failed", "Invalid Username/Password");
                return RedirectToAction("Login", "Security");

            }

        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewmodel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewmodel registerViewmodel)
        {
            if (!string.IsNullOrEmpty(registerViewmodel.PhoneNumber))
                if (registerViewmodel.PhoneNumber.Length != 10 || registerViewmodel.PhoneNumber.Any(x => char.IsLetter(x)))
                {
                    this.Flash(Toastr.ERROR, "Failed", "Enter numbers only for phone");
                    return RedirectToAction("Login", registerViewmodel);
                }

            if (ModelState.IsValid)
            {
                registerViewmodel.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(registerViewmodel.Password, "SHA1");
                _securityService.RegisterUser(registerViewmodel);
                this.Flash(Toastr.SUCCESS, "Success", "Registered Successfully");
                return RedirectToAction("Login");

            }
            this.Flash(Toastr.ERROR, "Failed", "Fields cannot be blank");
            return RedirectToAction("Login", registerViewmodel);


        }
    }
}