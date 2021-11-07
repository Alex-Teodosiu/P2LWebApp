using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using P2LWebApplication.Models;

namespace P2LWebApplication.Services
{
    public class ResourceService: IResourceService
    {
        private HttpClient client;
        private string uri = "https://localhost:5003/Resource";

        public ResourceService()
        {
            client = new HttpClient();
        }

        public async Task<Resource> GetResourceByIdAsync(int id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + $"/{id}");
            string message = await stringAsync;
            var resource = JsonSerializer.Deserialize<Resource>(message);
            return resource;
        }

        public async Task AddResourceAsync(Resource resource)
        {
            string teamJson = JsonSerializer.Serialize(resource);
            HttpContent content = new StringContent(teamJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }

        public async Task<List<Resource>> GetResourcesAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri);
            string message = await stringAsync;
            
            List<Resource> resources = JsonSerializer.Deserialize<List<Resource>>(message, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return resources;
        }
        
        
    }
}