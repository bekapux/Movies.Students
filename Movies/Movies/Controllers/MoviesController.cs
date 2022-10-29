using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Movies.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie> {
            new Movie
            {
                Id = 1,
                Title = "Interstellar",
                AuthorFirstName = "Chris",
                AuthorLastName = "Nolan",
                Description = "Some movie",
                ImageUrl = "https://images.unsplash.com/photo-1623579197998-a236e1ccc5f8?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1334&q=80",
                IMDBRating = 8.8f,
                ReleaseYear = 2014
            },
            new Movie
            {
                Id = 1,
                Title = "Inception",
                AuthorFirstName = "Chris",
                AuthorLastName = "Nolan",
                Description = "Some movie",
                ImageUrl = "https://images.unsplash.com/photo-1623579197998-a236e1ccc5f8?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1334&q=80",
                IMDBRating = 8.2f,
                ReleaseYear = 2011
            }
        };

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return Ok(movies);
        }

        [HttpGet("get-by-id/{ID}")]
        public async Task<ActionResult<Movie>> GetMovieByID(int ID)
        {
            var movie = movies.FirstOrDefault(x=> x.Id == ID);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost("add-movie")]
        public async Task<ActionResult<Movie>> GetMovieByID(Movie newMovie)
        {
            newMovie.Id = movies[^1].Id + 1;
            movies.Add(newMovie);
            return Accepted();
        }

        [HttpDelete("delete/{ID}")]
        public async Task<ActionResult<Movie>> DeleteMovieByID(int ID)
        {
            var movie = movies.FirstOrDefault(x => x.Id == ID);
            if (movie == null) return NotFound();
            movies.Remove(movie);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult<Movie>> UpdateMovie(Movie movieToUpdate)
        {
            var movie = movies.FirstOrDefault(x => x.Id == movieToUpdate.Id);
            movie.AuthorFirstName = movieToUpdate.AuthorFirstName;
            movie.AuthorLastName = movieToUpdate.AuthorLastName;
            movie.IMDBRating = movieToUpdate.IMDBRating;
            movie.Description = movieToUpdate.Description;
            movie.ImageUrl = movieToUpdate.ImageUrl;
            movie.Title = movieToUpdate.Title;
            movie.ReleaseYear = movieToUpdate.ReleaseYear;
            return Ok();
        }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Description { get; set; }
        public float IMDBRating { get; set; }
        public string ImageUrl { get; set; }
    }
}