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
    public class MovieController : ControllerBase
    {
        readonly MovieService _movieService = new MovieService(new MovieRepository());
        [HttpGet]
        public ICollection<Movie> GetMovieList()
        {
            return _movieService.GetMovieList();
        }

        [HttpGet("{id}")]
        public Movie GetMovieById(int id)
        {
            return _movieService.GetMovieById(id);
        }
        [Route("[action]/{movieId}")]
        [HttpGet]
        public ICollection<Director> GetMovieDirectors(int movieId)
        {
            return _movieService.MovieDirectors(movieId);
        }


        [Route("[action]")]
        [HttpPut]
        public void Update([FromBody] Movie movie)
        {
            _movieService.Update(movie);
        }
        
        [Route("[action]")]
        [HttpPost]
        public void AddMovie([FromBody] Movie movie)
        {
            _movieService.Add(movie);
        }

        [Route("[action]")]
        [HttpPut]
        public void Delete([FromBody] Movie movie)
        {
            _movieService.SoftDelete(movie);
        }

    }
}