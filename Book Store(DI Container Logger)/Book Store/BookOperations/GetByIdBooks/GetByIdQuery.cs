using AutoMapper;
using Book_Store.Comman;
using Book_Store.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.BookOperations.GetByIdBooks
{
    public class GetByIdQuery
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public int id;
        public GetByIdQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }

        public GetByIdViewsModel Handle()
        {

            var book = _context.Books.SingleOrDefault(x => x.Id == id);

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
        public DateTime publishedDate { get; set; }
        public int pageCount { get; set; }
        public string Genre { get; set; }
    }
}
