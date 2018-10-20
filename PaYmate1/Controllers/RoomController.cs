using PaYmate1.Database;
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
    public class RoomController : Controller
    {
        // GET: Room

        private readonly RoomService _roomService;
        private readonly CustomerService _customerService;

        public RoomController(RoomService roomService, CustomerService customerService)
        {
            _roomService = roomService;
            _customerService = customerService;
        }
        public ActionResult Room()
        {
            return View();
        }

        // GET: Room
        public ActionResult GetRoomDetails(RoomViewModel roomViewModel)
        {
            var result = _roomService.GetRooms();
            return View(result);
        }
        [HttpPost]
        public ActionResult ReserveRoom(DateTime? reservationDate, int? roomNumber)
        {
            if (reservationDate == null || roomNumber == null || reservationDate?.Date <= DateTime.Now.Date)
            {
                this.Flash(Toastr.ERROR, "Failed", "Reservation date or room number is not valid");
                return RedirectToAction("GetRoomDetails");
            }




            return View("GetRoomDetails");
        }
    }
}