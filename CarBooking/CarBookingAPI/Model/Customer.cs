using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarBookingAPI.Model
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }


        public List<Booking> Bookings { get; set; }
    }
}
