using AutoMapper;
using Book_Store.DBContext;
using Book_Store.Entities;

namespace Book_Store.Application.AuthorOperations.Queries.GetByIdAuthors
{
    public class GetByIdAuthorQuery
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }


        public GetByIdAuthorQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        public GetByIdAuthorModel Handle()
        {
            Author author=_context.Authors.SingleOrDefault(a => a.Id == id);
            if(author == null)
            {
                throw new InvalidOperationException("The Author is not exist");
            }

            GetByIdAuthorModel model = _mapper.Map<GetByIdAuthorModel>(author);

            return model;
        }


    }

    public  class GetByIdAuthorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

    } 
}
