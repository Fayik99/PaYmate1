using PaYmate1.Common;
using PaYmate1.Database;
using PaYmate1.Entities;
using PaYmate1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<bool> ReserveRoom(DateTime? dateTime, int? roomNumber, int customerId)

        {

            var result = await _applicationContext
                .Reservation
                .FirstOrDefaultAsync(f => DbFunctions.TruncateTime(f.Date) == dateTime && f.RoomNumber == roomNumber && f.Status == (int)ReservationStatus.booked);
            if (result != null)
            {
                return false;
            }
            else
            {
                var newReservation = new Reservation
                {
                    CustomerId = customerId,
                    Date = dateTime,
                    RoomNumber = roomNumber,
                    Status = (int)ReservationStatus.booked
                };
                _applicationContext.Reservation.Add(newReservation);
                await _applicationContext.SaveChangesAsync();
                return true;
            }
        }
    }
}