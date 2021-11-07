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
    public class ResourceController: ControllerBase
    {
        private ResourceDBContext _resourceDbContext;

        public ResourceController(ResourceDBContext _resourceDbContext)
        {
            this._resourceDbContext = _resourceDbContext;
        }
        
        [HttpPost]
        public async Task<ActionResult<Resource>> AddResourceAsync([FromBody] Resource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _resourceDbContext.Resources.AddAsync(resource);
                await _resourceDbContext.SaveChangesAsync();
                return Created($"/{resource.Name}", resource);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Resource>>> getResources()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                List<Resource> res = new List<Resource>();
                
                res = await _resourceDbContext.Resources
                    .ToListAsync();
                return Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetResourceAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Resource resource = _resourceDbContext.Resources
                    .First(r =>r.Id == id);
                    
                if (resource == null)
                {
                    return NotFound(id);
                }
                
                return Ok(resource);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    }
}