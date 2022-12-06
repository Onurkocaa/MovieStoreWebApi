using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieStoreWebApi.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStoreWebApi.Application.CustomerOperations.Commands.DeleteCustomer;
using MovieStoreWebApi.Application.CustomerOperations.CreateCustomer;
using MovieStoreWebApi.Application.TokenOperations.Models;
using MovieStoreWebApi.Applications.CustomerOperations.CreateToken;
using MovieStoreWebApi.Applications.CustomerOperations.RefreshToken;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CustomerController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult AddCustomer([FromBody] CreateCustomerModel model)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = model;

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = id;
            
            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {

            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;

        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {

            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefrehToken = token;
            var result = command.Handle();
            return result;
        }
    }
}