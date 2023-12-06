using Book_Store.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.BookOperations.UpdateBooks
{
    public class UpdateBooksCommand
    {

        private readonly BookStoreDBContext _context;
        public UpdateBookModel Model { get; set; }
        public int id { get; set; }

        public UpdateBooksCommand(BookStoreDBContext dbContext)
        {
            _context = dbContext;
        }


        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
          
            if (book is null)
                throw new InvalidOperationException("The book is not exist");


            book.GenreId = Model.GenreId == default ? book.GenreId : Model.GenreId;
            book.Title = Model.Title == default ? book.Title : Model.Title;
            book.PublishedDate = Model.PublishedDate == default ? book.PublishedDate : Model.PublishedDate;
            book.PageCount = Model.PageCount == default ? book.PageCount : Model.PageCount;

            _context.SaveChanges();

        }


    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public int GenreId { get; set; }

    }
}
