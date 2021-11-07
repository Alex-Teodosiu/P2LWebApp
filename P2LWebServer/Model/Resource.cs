using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P2LWebServer.Model
{
    public class Resource
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Quantity{ get; set; }
        public ICollection<Booking>? BookedDates{ get; set; }
    }
}