using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bilge_Adam_Core_Project.BLL.Concreate;
using Bilge_Adam_Core_Project.Dal.Concreate;
using Bilge_Adam_Core_Project.Model.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bilge_Adam_Core_Project.Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class DirectorController : ControllerBase
    {
        readonly DirectorService _directorService = new DirectorService(new DirectorRepository());
        // GET: api/
        [HttpGet]
        public ICollection<Director> GetDirectorList()
        {
            return _directorService.GetDirectorList();
        }

        // GET: api/Director/5
        [HttpGet("{id}")]
        public Director GetDirectorById(int id)
        {
            return _directorService.GetDirectorById(id);
        }

        // GET: api/DirectorMovies/5
        [Route("[action]/{id}")]
        [HttpGet]
        public ICollection<Movie> DirectorMovies(int id)
        {
            return _directorService.DirectorMovies(id);
        }

        // POST: api/Director
        [Route("[action]")]
        [HttpPost]
        public void Add([FromBody] Director value)
        {
            _directorService.Add(value);
        }

        // PUT: api/Director/5
        [Route("[action]")]
        [HttpPut]
        public void Update([FromBody] Director value)
        {
            _directorService.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [Route("[action]")]
        [HttpPut]
        public void Delete(Director director)
        {
            _directorService.SoftDelete(director);
        }
    }
}
