using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2LWebServer.DataAccess;
using P2LWebServer.Model;

namespace P2LWebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController: ControllerBase
    {
        private ResourceDBContext _resourceDbContext;

        public BookingController(ResourceDBContext _resourceDbContext)
        {
            this._resourceDbContext = _resourceDbContext;
        }
        
        [HttpPost]
        [Route("{resourceId}")]
        public async Task<ActionResult<DateTime>> AddResourceAsync([FromBody] Booking booking, [FromRoute] int resourceId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Resource resourceToChange = await _resourceDbContext.Resources
                    .Include(r => r.BookedDates)
                    .FirstAsync(r => r.Id == resourceId);
                
                //Set FK for booking
                booking.ResourceId = resourceToChange.Id;
                
                //Add a booking
                await _resourceDbContext.Bookings.AddAsync(booking);
                await _resourceDbContext.SaveChangesAsync();
                
                //Update the resource with that booking
                Console.WriteLine(booking.ResourceId);
                
                resourceToChange.BookedDates.Add(booking);
                _resourceDbContext.Update(resourceToChange);
                
                await _resourceDbContext.SaveChangesAsync(); 

                Resource res = await _resourceDbContext.Resources
                    .Include(r => r.BookedDates)
                    .FirstAsync(r => r.Id == resourceId);
                
                Booking createdBooking = res.BookedDates.OrderByDescending(u => u.Id).FirstOrDefault();

                Console.WriteLine($"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {createdBooking.Id}");
                return Created($"/{resourceToChange.Name}", createdBooking);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        
        
    }
}