using Book_Store.Comman;
using Book_Store.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _context;

        public GetBooksQuery(BookStoreDBContext context) { 
        
            _context = context;

        }

        public List<BookViewsModel> Handle()
        {
            List<Book> bookList = new List<Book>();
            bookList = _context.Books.OrderBy(book => book.Id).ToList();

            List<BookViewsModel> vm= new List<BookViewsModel>();
            foreach (Book book in bookList)
            {
                vm.Add(new BookViewsModel()
                {
                    Title = book.Title,
                    pageCount = book.PageCount,
                    publishedDate=book.PublishedDate,
                    Genre=((GenreEnum)book.GenreId).ToString(),

                });

            }
            return vm;
        }
    }

    public class BookViewsModel()
    {
        public string Title { get; set; }
        public DateTime publishedDate { get; set; }
        public int pageCount { get; set; }
        public string Genre { get; set; }
    }
}
