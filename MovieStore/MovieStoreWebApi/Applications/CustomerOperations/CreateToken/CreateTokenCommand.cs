using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MovieStoreWebApi.Application.TokenOperations;
using MovieStoreWebApi.Application.TokenOperations.Models;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Applications.CustomerOperations.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model;

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (customer != null)
            {

                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Experation.AddMinutes(5);

                _context.SaveChanges();
                return token;

            }
            else
            throw new InvalidOperationException("Email veya Şifre Hatalı !");
        }

    }
    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}