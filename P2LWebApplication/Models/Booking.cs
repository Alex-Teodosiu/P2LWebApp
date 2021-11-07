using System;
using System.ComponentModel.DataAnnotations;

namespace P2LWebApplication.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }      
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public int BookedQuantity { get; set; }
        public int ResourceId{ get; set; }
    }
}