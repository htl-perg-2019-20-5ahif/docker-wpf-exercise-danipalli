using System;
using System.ComponentModel.DataAnnotations;

namespace CarBookingAPI.Model
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int CarID { get; set; }

        public Car Car { get; set; }


        [Required]
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
