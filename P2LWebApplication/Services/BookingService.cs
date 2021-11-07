using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using P2LWebApplication.Models;

namespace P2LWebApplication.Services
{
    public class BookingService: IBookingService
    {
        private HttpClient client;
        private string uri = "https://localhost:5003";

        public BookingService()
        {
            client = new HttpClient();
        }
        
        public async Task AddBookingAsync(Booking booking, int resourceId)
        {
            string authorJson = JsonSerializer.Serialize(booking);
            HttpContent content = new StringContent(authorJson, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Booking/{resourceId}", content);
        }
        
    }
}