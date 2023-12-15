using AutoMapper;
using Book_Store.DBContext;
using Book_Store.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Application.BookOperations.Commands.CreateBooks
{

    public class CreateBooksCommand
    {

        public CreateBookModel model { get; set; }
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateBooksCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var existBook = _context.Books.SingleOrDefault(x => x.Title == model.Title);
            if (existBook is not null)
            {
                throw new InvalidOperationException("The book is already exist");
            }

            existBook = new Book();
            //Map<target>(source)
            existBook = _mapper.Map<Book>(model);
            _context.Books.Add(existBook);
            _context.SaveChanges();
           

        }




    }

    public class CreateBookModel()
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
    }
}
