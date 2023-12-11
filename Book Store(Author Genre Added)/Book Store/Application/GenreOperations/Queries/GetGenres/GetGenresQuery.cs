using AutoMapper;
using Book_Store.Application.BookOperations.Queries.GetBooks;
using Book_Store.DBContext;
using Book_Store.Entities;

namespace Book_Store.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {

        private readonly BookStoreDBContext _context;
        private IMapper _mapper;

        public GetGenresQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public List<GetViewsModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive == true).OrderBy(x => x.Id);
            List<GetViewsModel> returnObj = _mapper.Map<List<GetViewsModel>>(genres);
            return returnObj;

        }
    }
     public class GetViewsModel()
    {
       
        public string Name { get; set; }
       

    }
}
