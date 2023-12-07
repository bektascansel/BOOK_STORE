using Book_Store.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.DBOperations
{
    public class DataGenerator
    {

        //verileri insert eden Initialize metodu 
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }


                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishedDate = new DateTime(2003, 06, 22)
                    },
                      new Book
                      {
                          //Id = 2,
                          Title = "Merland",
                          GenreId = 2,
                          PageCount = 250,
                          PublishedDate = new DateTime(2005, 07, 19),

                      },
                      new Book
                      {
                          //Id = 3,
                          Title = "Dune",
                          GenreId = 3,
                          PageCount = 500,
                          PublishedDate = new DateTime(2009, 08, 15),
                      }
                    );


                context.SaveChanges();



            }


        }




    }
}
