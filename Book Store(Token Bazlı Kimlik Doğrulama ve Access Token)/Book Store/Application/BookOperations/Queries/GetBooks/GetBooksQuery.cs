using AutoMapper;

using Book_Store.DBContext;
using Book_Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDBContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;

        }

        public List<BookViewsModel> Handle()
        {
            List<Book> bookList = new List<Book>();
            bookList = _context.Books.Include(x => x.Genre).Include(x=>x.Author).OrderBy(book => book.Id).ToList();
            List<BookViewsModel> vm = _mapper.Map<List<BookViewsModel>>(bookList);

            return vm;
        }
    }

    public class BookViewsModel()
    {
        public string Title { get; set; }
        public string PublishedDate { get; set; }
        public int pageCount { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}
