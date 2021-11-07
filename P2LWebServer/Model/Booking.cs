
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;

namespace P2LWebServer.Model
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