using Book_Store;
using Book_Store.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDBContext _dbContext;

        public BookController(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

     
        
        [HttpGet]
        public List<Book> GetBooks()
        {
            ////Id degerine göre sıralar.
            List<Book> bookList = new List<Book>();
            bookList= _dbContext.Books.OrderBy(book => book.Id).ToList();
            

            return bookList;

        }
     

        
        //Route üzerinden parametre alarak;
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _dbContext.Books.Where(book=>book.Id==id).FirstOrDefault();
            return book;
        }
        

        /*
        //Query üzerinden parametre alarak;
        [HttpGet]
        public Book GetById([FromQuery] string id)
        {
            var book = books.Where(book => book.Id == Convert.ToInt32(id)).FirstOrDefault();
            return book;
        }
        */


        [HttpPost]
        public IActionResult AddBook([FromBody]Book book)
        {
            var existBook= _dbContext.Books.SingleOrDefault(x=>x.Title==book.Title);
            if (existBook is not null)
            {
                return BadRequest();
            }
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody]Book updatedbook)
        {
            var book= _dbContext.Books.SingleOrDefault(x=>x.Id==id);
            if(book is  null)  
              return BadRequest();


             book.GenreId=updatedbook.GenreId==default ? book.GenreId : updatedbook.GenreId;
             book.Title=updatedbook.Title==default ? book.Title : updatedbook.Title;
             book.PublishedDate=updatedbook.PublishedDate==default ? book.PublishedDate : updatedbook.PublishedDate;
             book.PageCount=updatedbook.PageCount==default ? book.PageCount : updatedbook.PageCount;

            _dbContext.SaveChanges();
             return Ok();



        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) {  
            
            var book= _dbContext.Books.SingleOrDefault(x=>x.Id==id);

            if(book is null)
                return BadRequest();

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            return Ok(); }
    }
}
