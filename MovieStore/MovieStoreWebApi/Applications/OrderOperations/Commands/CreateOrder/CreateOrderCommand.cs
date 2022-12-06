using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            var movies = _dbContext.Movies.SingleOrDefault(s => s.ID == Model.MovieId);

            if (customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı!");
            if (movies is null)
                throw new InvalidOperationException("Film bulunamadı!");
           

            var result = _mapper.Map<Order>(Model);
            result.purchasedTime = DateTime.Now;

            _dbContext.Orders.Add(result);
            _dbContext.SaveChanges();
        }
    }
    public class CreateOrderModel
    {
    public int MovieId { get; set; }
    public int CustomerId { get; set; }
    DateTime purchasedTime = DateTime.Now;
    }
}