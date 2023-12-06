using Book_Store.Comman;
using Book_Store.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.BookOperations.GetByIdBooks
{
    public class GetByIdQuery
    {
        private readonly BookStoreDBContext _context;
        public int id;
        public GetByIdQuery(BookStoreDBContext context)
        {
            _context = context;
        }

        public GetByIdViewsModel Handle()
        {

            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
                throw new InvalidOperationException("The book is not exist");



            GetByIdViewsModel model = new GetByIdViewsModel();
            model.Title= book.Title;
            model.publishedDate= book.PublishedDate;
            model.Genre = ((GenreEnum)book.GenreId).ToString();
            model.pageCount= book.PageCount;
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
