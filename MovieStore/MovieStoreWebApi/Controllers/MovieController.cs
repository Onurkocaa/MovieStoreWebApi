using Application.MovieOperations.Commands.UpdateMovie;
using Applications.MovieOperations.Commands.CreateMovie;
using Applications.MovieOperations.Commands.DeleteMovie;
using Applications.MovieOperations.Commands.UpdateMovie;
using Applications.MovieOperations.Queries.GetMovieDetail;
using Applications.MovieOperations.Queries.GetMovies;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetMovies()
        {
            GetMovieQuery query = new GetMovieQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context,_mapper);
            query.MovieId=id;

            GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context,_mapper);
            command.Model = newMovie;

            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id,[FromBody] UpdateMovieModel updateMovie)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context,_mapper);
            command.MovieId=id;
            command.Model=updateMovie;

            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId=id;
            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}