using AutoMapper;
using Book_Store.DBContext;
using Book_Store.Entities;

namespace Book_Store.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<AuthorViewsModel> Handle()
        {
            List<Author> authors=_context.Authors.OrderBy(x=>x.Id).ToList();
            List<AuthorViewsModel> _authors = _mapper.Map<List<AuthorViewsModel>>(authors);
            return _authors;
        }

    }

    public class AuthorViewsModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; } 
    }
}
