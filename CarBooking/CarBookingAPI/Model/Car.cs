using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarBookingAPI.Model
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public String Make { get; set; }

        [Required]
        public String Model { get; set; }


        public List<Booking> Bookings { get; set; }
    }
}
