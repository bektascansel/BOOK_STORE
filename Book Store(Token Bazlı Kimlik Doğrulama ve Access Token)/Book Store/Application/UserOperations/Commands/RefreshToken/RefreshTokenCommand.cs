using AutoMapper;
using Book_Store.DBContext;
using Book_Store.TokenOperations.Models;
using Book_Store.TokenOperations.TokenHandler;

namespace Book_Store.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
      

            public string RefreshToken { get; set; }
            private readonly BookStoreDBContext _context;
            private readonly IConfiguration _configuration;
            public RefreshTokenCommand(BookStoreDBContext context, IConfiguration configuration)
            {
                _context = context;
                
                _configuration = configuration;
            }

            public Token Handle()
            {
                var user = _context.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken&& x.RefreshTokenExpireDate>DateTime.Now);
                if (user is not null)
                {

                    TokenHandler handler = new TokenHandler(_configuration);
                    Token token = handler.CreateAccessToken(user);

                    user.RefreshToken = token.RefreshToken;
                    user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                    _context.SaveChanges();
                    return token;
                }
                else
                {
                    throw new InvalidOperationException("Valid refresh token is not exist ");
                }
            }


        }
      


    }

