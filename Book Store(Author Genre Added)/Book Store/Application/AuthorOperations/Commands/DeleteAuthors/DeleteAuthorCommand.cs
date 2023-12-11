using AutoMapper;
using Book_Store.DBContext;
using Book_Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Application.AuthorOperations.Commands.DeleteAuthors
{
    public class DeleteAuthorCommand
    {

        private readonly BookStoreDBContext _context;
        public int id;


        public DeleteAuthorCommand(BookStoreDBContext context)
        {
            _context = context;

        }

        public void Handle()
        {

            var author = _context.Authors
                   .Include(a => a.BookList) // Burada BookList, Author sınıfındaki ilişkili özelliktir
                    .SingleOrDefault(x => x.Id == id);
            if (author == null)
            {
               
                throw new InvalidOperationException("The Author is not exist");
            }


            List<Book> books = author.BookList;
            foreach (Book book in books)
            {
                if (book.IsPublished == true)
                    throw new InvalidOperationException("Not Permission To Delete The Author Who Have Book Which Is Publish");
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();

        }



    }
}
