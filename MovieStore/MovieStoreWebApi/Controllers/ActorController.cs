using Application.ActorOperations.Queries.GetActorDetail;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Application.ActorOperations.Commands.CreateActor;
using MovieStoreWebApi.Application.ActorOperations.Commands.DeleteActor;
using MovieStoreWebApi.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreWebApi.Application.ActorOperations.Queries.GetActors;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetActors()
        {
            GetActorsQuery query = new GetActorsQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);

        }
         [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context,_mapper);
            query.ActorId=id;

            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorModel model)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = model;

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel model)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context, _mapper);

            command.ActorId = id;
            command.Model = model;

            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = id;
            
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}