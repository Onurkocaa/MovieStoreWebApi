using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Application.OrderOperations.Queries.GetOrderDetail;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.OrderOperations.Queries.GetListOrder
{
    public class GetOrderQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetOrderQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OrderViewModel> Handle()
        {
            List<Customer> list = _context.Customers.Include(i => i.Orders).ThenInclude(t => t.Movie).OrderBy(x => x.Id).ToList();
            List<OrderViewModel> vm = _mapper.Map<List<OrderViewModel>>(list);
            return vm;
        }
    }
}