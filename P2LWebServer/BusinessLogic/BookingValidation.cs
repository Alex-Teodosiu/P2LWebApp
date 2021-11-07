using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P2LWebServer.DataAccess;
using P2LWebServer.Model;

namespace P2LWebServer.BusinessLogic
{
    public class BookingValidation
    {
        private ResourceDBContext _resourceDbContext;
        
        public BookingValidation(ResourceDBContext resourceDbContext)
        {
            _resourceDbContext = resourceDbContext;
        }

        public bool isAvailable(int resourceId, Booking booking)
        {
            Resource resourceToCheck = _resourceDbContext.Resources
                .First(r => r.Id == resourceId);
            
            List<Booking> bookings = new List<Booking>();
                
            bookings = _resourceDbContext.Bookings
                .ToList();
            
            if (booking.BookedQuantity > resourceToCheck.Quantity)
            {
                return false;
            }

            foreach (var b in bookings)
            {
                if ((booking.DateFrom > b.DateFrom && booking.DateFrom < b.DateTo) || (booking.DateTo > b.DateFrom && booking.DateTo < b.DateTo) || (booking.DateFrom < b.DateFrom && booking.DateTo > b.DateTo))
                {
                    return false;
                }
            }
            return true;
        }
        
        

    }
}