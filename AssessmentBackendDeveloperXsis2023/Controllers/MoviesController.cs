using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssessmentBackendDeveloperXsis2023.Interface;
using AssessmentBackendDeveloperXsis2023.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentBackendDeveloperXsis2023.Controllers
{
    [Route("[controller]")]
    
   
    public class MoviesController : Controller
    {
        private readonly IRepositories _repository;
        public MoviesController(IRepositories repositories) {
            _repository = repositories;
        }


        // GET: Movies
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return _repository.movies();
        }

        // GET: Movies/1
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movies = _repository.movies();
            var movie = movies.Find(m => m.Id == id);
            if (movie == null) return NotFound();
            return movie; 
        }

        
        // POST: Movies
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie newMovie)
        {
            if (newMovie == null) return BadRequest();
            var movies = _repository.movies();
            int newMovieId = movies.Count + 1;
            newMovie.Id = newMovieId;
            _repository.AddOrUpdateMovie(newMovie);
            return CreatedAtAction("Get", new { id = newMovieId }, newMovie);
        }

        // PATCH: Movies/1
        [HttpPatch("{id}")]
        public ActionResult<Movie> Patch(int id, [FromBody] Movie updatedMovie)
        {
            var movies = _repository.movies();
            var findMovie = movies.Find(m => m.Id == id);
            if (findMovie == null) return NotFound();
            updatedMovie.Updated_At = DateTime.Now;
            _repository.AddOrUpdateMovie(updatedMovie);
            return Ok(updatedMovie); 
        }

        // DELETE: Movies/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movies = _repository.movies();
            var movieId = movies.Find(m => m.Id == id);
            if (movieId == null) return NotFound();
            _repository.DeleteMovie(movieId.Id);
            return NoContent(); 
        }
    }


}

