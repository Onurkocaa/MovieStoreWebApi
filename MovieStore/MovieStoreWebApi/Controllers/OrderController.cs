using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Application.OrderOperations.Commands.CreateOrder;
using MovieStoreWebApi.Application.OrderOperations.Commands.DeleteOrder;
using MovieStoreWebApi.Application.OrderOperations.Commands.UpdateOrder;
using MovieStoreWebApi.Application.OrderOperations.Queries.GetListOrder;
using MovieStoreWebApi.Application.OrderOperations.Queries.GetOrderDetail;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetLists()
        {
            GetOrderQuery query = new GetOrderQuery(_context, _mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetDetail(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            query.OrderId = id;
            
            GetOrderDetailQueryValidator validator = new GetOrderDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderModel model)
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = model;

            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromBody] UpdateOrderModel model, int Id)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_context, _mapper);
            command.Model = model;
            command.OrderId = Id;

            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteOrder(int Id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.OrderId = Id;
             
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}