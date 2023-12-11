using AutoMapper;
using Book_Store.DBContext;
using Book_Store.Entities;

namespace Book_Store.Application.GenreOperations.Queries.GetByIdGenres
{
    public class GetByIdGenreQuery
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }

        public GetByIdGenreQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public GetByIdViewModel Handle()
        {
            Genre genre = _context.Genres.SingleOrDefault(x=> x.Id == GenreId);
            if (genre == null)
            {
                throw new InvalidOperationException("Genre is not exist");
            }
            else if (genre.IsActive == false)
            {
                    throw new InvalidOperationException("Genre is not active");
            }

            GetByIdViewModel getByIdViewsModel = _mapper.Map<GetByIdViewModel>(genre);
            return getByIdViewsModel;

       

        }


      



    }

    public class GetByIdViewModel()
    {
        public String Name { get; set; }
    }

}
