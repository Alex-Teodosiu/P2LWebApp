using System.Collections.Generic;
using System.Threading.Tasks;
using P2LWebApplication.Models;

namespace P2LWebApplication.Services
{
    public interface IResourceService
    {
        Task<List<Resource>> GetResourcesAsync();
        Task<Resource> GetResourceByIdAsync(int id);
        Task AddResourceAsync(Resource resource);
    }
}