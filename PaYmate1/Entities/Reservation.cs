using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaYmate1.Entities
{
    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int? RoomNumber { get; set; }
        public DateTime? Date { get; set; }
        public int Status { get; set; }
    }
}