using Book_Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private static List<Book> books = new List<Book>()
        {
          new Book
          {
              Id=1,
              Title="Lean Startup",
              GenreId=1,
              PageCount=200,
              PublishedDate=new DateTime(2003,06,22)
          },
          new Book
          {
              Id=2,
              Title="Merland",
              GenreId=2,
              PageCount =250,
              PublishedDate=new DateTime(2005,07,19),

          },
          new Book
          {
              Id=3,
              Title="Dune",
              GenreId=3,
              PageCount=500,
              PublishedDate=new DateTime(2009,08,15),
          }
      
         };


        
        [HttpGet]
        public List<Book> GetBooks()
        {
            ////Id degerine göre sıralar.
            /*List<Book> bookList = new List<Book>();
            bookList=books.OrderBy(book => book.Id).ToList();
            return bookList;*/

            return books;

        }
     

        
        //Route üzerinden parametre alarak;
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book =books.Where(book=>book.Id==id).FirstOrDefault();
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
            var existBook=books.SingleOrDefault(x=>x.Title==book.Title);
            if (existBook is not null)
            {
                return BadRequest();
            }
            books.Add(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody]Book updatedbook)
        {
            var book=books.SingleOrDefault(x=>x.Id==id);
            if(book is  null)  
              return BadRequest();


             book.GenreId=updatedbook.GenreId==default ? book.GenreId : updatedbook.GenreId;
             book.Title=updatedbook.Title==default ? book.Title : updatedbook.Title;
             book.PublishedDate=updatedbook.PublishedDate==default ? book.PublishedDate : updatedbook.PublishedDate;
             book.PageCount=updatedbook.PageCount==default ? book.PageCount : updatedbook.PageCount;

             return Ok();



        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) {  
            
            var book=books.SingleOrDefault(x=>x.Id==id);

            if(book is null)
                return BadRequest();

            books.Remove(book);
            return Ok(); }
    }
}
