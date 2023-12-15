﻿using AutoMapper;
using Book_Store.DBContext;
using Book_Store.TokenOperations.Models;
using Book_Store.TokenOperations.TokenHandler;

namespace Book_Store.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {

        public CreateTokenModel Model { get; set; }
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenCommand (BookStoreDBContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user =_context.Users.FirstOrDefault(x=>x.Email==Model.Email&& x.Password==Model.Password);
            if (user is not null){

                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("User name , password is wrong ");
            }
        }


    }
    public class CreateTokenModel()
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
