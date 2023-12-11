using AutoMapper;

using Book_Store.DBContext;
using Book_Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Application.BookOperations.Queries.GetByIdBooks
{
    public class GetByIdQuery
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public int id;
        public GetByIdQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetByIdViewsModel Handle()
        {

            var book = _context.Books.Include(x=>x.Genre).Include(x=>x.Author).Where(x => x.Id == id).SingleOrDefault();

            if (book is null)
                throw new InvalidOperationException("The book is not exist");

            GetByIdViewsModel model = new GetByIdViewsModel();
            model = _mapper.Map<GetByIdViewsModel>(book);
            return model;
        }



    }

    public class GetByIdViewsModel()
    {
        public string Title { get; set; }
        public string publishedDate { get; set; }
        public int pageCount { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}
