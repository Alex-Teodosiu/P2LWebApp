using System.Collections.Generic;
using System.Threading.Tasks;
using P2LWebApplication.Models;

namespace P2LWebApplication.Services
{
    public interface IBookingService
    {
        Task AddBookingAsync(Booking booking, int resourceId);
    }
}