using AutoMapper;
using Book_Store.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.BookOperations.UpdateBooks
{
    public class UpdateBooksCommand
    {

        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public UpdateBookModel Model { get; set; }
        public int id { get; set; }

        public UpdateBooksCommand(BookStoreDBContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }


        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
          
            if (book is null)
                throw new InvalidOperationException("The book is not exist");

            
           book= _mapper.Map(Model, book);
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
