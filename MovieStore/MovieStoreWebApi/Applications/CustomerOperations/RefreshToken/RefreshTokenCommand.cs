using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MovieStoreWebApi.Application.TokenOperations;
using MovieStoreWebApi.Application.TokenOperations.Models;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Applications.CustomerOperations.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefrehToken;

        private readonly IMovieStoreDbContext _context;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IMovieStoreDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.RefreshToken == RefrehToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (customer is not null)
            {

                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Experation.AddMinutes(5);

                _context.SaveChanges();
                return token;

            }
            else
            throw new InvalidOperationException("Valid bir refresh token bulunamadı !");
        }

    }
}