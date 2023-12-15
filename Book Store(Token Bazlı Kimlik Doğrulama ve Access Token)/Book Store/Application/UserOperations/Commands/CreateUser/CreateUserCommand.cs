using AutoMapper;
using Book_Store.Application.BookOperations.Commands.CreateBooks;
using Book_Store.DBContext;
using Book_Store.Entities;

namespace Book_Store.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel model { get; set; }
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var existUser = _context.Users.SingleOrDefault(x => x.Email == model.Email);
            if (existUser is not null)
            {
                throw new InvalidOperationException("The book is already exist");
            }

            existUser = new User();
            //Map<target>(source)
            existUser = _mapper.Map<User>(model);
            _context.Users.Add(existUser);
            _context.SaveChanges();


        }



    }

    public class CreateUserModel()
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
