using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.OrderOperations.Commands.UpdateOrder
{
     public class UpdateOrderCommand
    {
        public UpdateOrderModel Model { get; set; }
        public int OrderId;
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            Customer customer = _context.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            Movie movies = _context.Movies.SingleOrDefault(s => s.ID == Model.MovieId);
           
            Order order = _context.Orders.SingleOrDefault(s => s.Id == OrderId);

            if (customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı!");
            else if (movies is null)
                throw new InvalidOperationException("Film bulunamadı!");
            else if (order is null)
                throw new InvalidOperationException("Kayıt bulunamadı!");
                
            _mapper.Map<UpdateOrderModel, Order>(Model, order);

            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
        public class UpdateOrderModel
    {
        public int MovieId { get; set; }
        public int CustomerId { get; set; }

    }
}
