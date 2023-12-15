using AutoMapper;
using Book_Store.Application.UserOperations.Commands.CreateToken;
using Book_Store.Application.UserOperations.Commands.CreateUser;
using Book_Store.Application.UserOperations.Commands.RefreshToken;
using Book_Store.DBContext;
using Book_Store.TokenOperations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserController(BookStoreDBContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }



        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command =new CreateUserCommand(_context,_mapper);
            command.model = newUser;

            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command=new CreateTokenCommand(_context,_mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        [HttpGet]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
          RefreshTokenCommand command =new RefreshTokenCommand(_context, _configuration);
          command.RefreshToken = token;
          var resultToken=command.Handle();
           return resultToken;
        }
    }
}
