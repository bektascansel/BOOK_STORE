using Book_Store.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.BookOperations.CreatBooks
{

    public class CreateBooksCommand
    {

        public CreateBookModel model {  get; set; }
        private readonly BookStoreDBContext _context;

        public CreateBooksCommand(BookStoreDBContext context)
        {
            _context=context;
        }

        public void Handle()
        {
            var existBook = _context.Books.SingleOrDefault(x => x.Title == model.Title);
            if (existBook is not null)
            {
                throw new InvalidOperationException("The book is already exist");
            }

            _context.Books.Add(new Book()
            {
                Title = model.Title,
                PageCount = model.PageCount,
                PublishedDate=model.PublishedDate,
                GenreId=model.GenreId,

            });
            _context.SaveChanges();
        }




    }

    public class CreateBookModel()
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishedDate { get; set; }

    }
}
