using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApplication.Movie_logic;
using MovieApplication.Movie_logic.Models;

namespace MovieApplication.Movie_Controller
{
    [Route("api/movie")]
    [ApiController]
    public class movie_controller : ControllerBase
    {

        readonly IMovieLogic  movieService;

        public movie_controller(IMovieLogic movieService)
        {
            this.movieService = movieService;   
        }


        [HttpGet("/all")]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                return Ok(await this.movieService.GetMovieList());
            }

            catch (Exception ex)
            {
                return Content(ex);
            }
        }

       

        [HttpPost("/add_movie")]
        public async Task<IActionResult> AddMovie(CreateMovieModel model)
        {
            try
            {
                return Ok(await this.movieService.AddNewMovie(model));
            }

            catch (Exception ex)
            {
                return Content(ex);
            }
        }

        [HttpPost("/update_movie")]
        public async Task<IActionResult> UpdateMovie(CreateMovieModel model)
        {
            try
            {
                return Ok(await this.movieService.UpdateMovie(model));
            }

            catch (Exception ex)
            {
                return Content(ex);
            }
        }

        private IActionResult Content(Exception ex)
        {
            throw new NotImplementedException();
        }


    }
}
