using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
        var customer = _context.Customers.SingleOrDefault(x => x.Email == Model.Email);

            if (customer is not null)
                throw new InvalidOperationException("Film zaten mevcut.");

        customer = _mapper.Map<Customer>(Model);

        _context.Customers.Add(customer);
        _context.SaveChanges();
        }
    }
    public class CreateCustomerModel
    {  
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}