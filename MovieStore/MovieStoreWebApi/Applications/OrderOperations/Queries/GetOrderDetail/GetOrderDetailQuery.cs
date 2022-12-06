using System.Collections.Generic;
using MovieStoreWebApi.DBOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MovieStoreWebApi.Application.OrderOperations.Queries.GetOrderDetail
{
        public class GetOrderDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int OrderId;

        public GetOrderDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OrderViewModel Handle()
        {
            var customer = _context.Customers.Include(i => i.Orders).ThenInclude(t => t.Movie).SingleOrDefault(s => s.Id == OrderId);
            OrderViewModel vm = _mapper.Map<OrderViewModel>(customer);

            return vm;
        }
    }
     public class OrderViewModel
    {
        public string NameSurname { get; set; }
        public IReadOnlyCollection<string> Movies { get; set; }
        public IReadOnlyCollection<string> Price { get; set; }
        public IReadOnlyCollection<string> PurchasedDate { get; set; }
    }
}