using Book_Store.DBContext;
using Book_Store.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Application.BookOperations.Commands.DeleteBooks
{
    public class DeleteBooksCommand
    {
        private readonly BookStoreDBContext _context;
        public int id { get; set; }
        public DeleteBooksCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            Book book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
                throw new InvalidDataException("the book is not exist");

            _context.Books.Remove(book);
            _context.SaveChanges();

        }




    }
}
