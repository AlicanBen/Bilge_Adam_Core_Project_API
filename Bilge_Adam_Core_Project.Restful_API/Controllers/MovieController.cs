using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bilge_Adam_Core_Project.BLL.Concreate;
using Bilge_Adam_Core_Project.Dal.Concreate;
using Bilge_Adam_Core_Project.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bilge_Adam_Core_Project.Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieService _movieService = new MovieService(new MovieRepository());
        [HttpGet]
        public IEnumerable<Movie> GetMovieList()
        {
            return _movieService.GetMovieList();
        }
        [HttpGet("{id}", Name = "GetMovieById")]
        public Movie GetMovieById(int id)
        {
            return _movieService.GetMovieById(id);
        }
    }
}