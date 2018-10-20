using PaYmate1.Database;
using PaYmate1.Entities;
using PaYmate1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaYmate1.Services
{
    public class RoomService
    {
        private readonly ApplicationContext _applicationContext;

        public RoomService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;

        }

        public List<RoomViewModel> GetRooms()
        {
            var result = _applicationContext.Room.Select(x => new RoomViewModel

            {
                RoomNumber = x.RoomNumber,
                Price = x.Price,
                RoomType = x.RoomType
            }).ToList();

            return result;






        }
    }
}