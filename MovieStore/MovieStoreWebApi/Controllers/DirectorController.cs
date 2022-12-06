using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.Application.DirectorOperations.Commands.DeleteDirector;
using MovieStoreWebApi.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreWebApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreWebApi.Application.DirectorOperations.Queries.GetDirectors;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetDirectors()
        {
            GetDirectorQuery query = new GetDirectorQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);

        }
         [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context,_mapper);
            query.DirectorId=id;

            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorModel model)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = model;

            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorModel model)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context, _mapper);

            command.DirectorId = id;
            command.Model = model;

            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = id;
            
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}