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
    public class AdminController : Controller
    {
        // GET: Admin
       
        private readonly AdminService _adminService;

        // GET: Bank
        public AdminController(AdminService adminService)
        {

            _adminService = adminService;

        }

        public ActionResult Admin()
        {
              

            return View();
        }
        [HttpPost]
        public ActionResult SearchUsers(CustomerViewModel customerViewModel)
        {

           var result= _adminService.SearchUsers(customerViewModel);
            return View(result);


        }

        public ActionResult GetAllUsers()
        {
          var list= _adminService.GetAllUsers();
            return View(list);
        }

        public ActionResult UnBlockUser(int id)
        {
            _adminService.UnBlockUser(id);
            this.Flash(Toastr.SUCCESS, "Success", "User Unblocked successfully");
            return RedirectToAction("GetAllBlockedUsers");
        }

        public ActionResult GetAllBlockedUsers()
        {
            var list = _adminService.GetAllBlockedUsers();
            return View(list);
        }
    }
}