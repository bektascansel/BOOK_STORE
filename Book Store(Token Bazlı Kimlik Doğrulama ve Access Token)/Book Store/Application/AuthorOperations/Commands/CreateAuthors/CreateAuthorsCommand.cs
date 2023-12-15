using AutoMapper;
using Book_Store.DBContext;
using Book_Store.Entities;

namespace Book_Store.Application.AuthorOperations.Commands.CreateAuthors
{
    public class CreateAuthorsCommand
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorModel Model { get; set; }

        public CreateAuthorsCommand( BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=>x.Name==Model.Name && x.LastName==Model.LastName);
            if (author is not null) {
                throw new InvalidOperationException("The Author is exist");
            }

            author = new Author();
            author=_mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
       


    }

    public  class CreateAuthorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
