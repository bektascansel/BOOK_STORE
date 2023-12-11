using Book_Store.DBContext;
using Book_Store.Entities;
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
                          PublishedDate = new DateTime(2003, 06, 22),
                          AuthorId = 1,
                      },
                      new Book
                      {
                          //Id = 2,
                          Title = "Merland",
                          GenreId = 2,
                          PageCount = 250,
                          PublishedDate = new DateTime(2005, 07, 19),
                          AuthorId = 2,

                      },
                      new Book
                      {
                          //Id = 3,
                          Title = "Dune",
                          GenreId = 3,
                          PageCount = 500,
                          PublishedDate = new DateTime(2009, 08, 15),
                          AuthorId = 3,
                      }
                    );

                context.Genres.AddRange(

                    new Genre
                    {
                        Name = "Personal Growth",


                    },

                    new Genre
                    {
                        Name = "Science Fiction",

                    },
                    new Genre
                    {
                        Name = "Romance",

                    }
                   );


                /*
                context.Authors.AddRange(

                    new Author
                    {
                        Name = "Steve",
                        LastName = "Blank",
                        BirthDate= new DateTime(2009, 08, 15),
                    },

                    new Author
                    {
                         Name = "Paula",
                         LastName = "King",
                         BirthDate = new DateTime(2009, 08, 15),
                    },

                    new Author
                    {
                        Name = "Frank",
                        LastName = "Helbert",
                        BirthDate = new DateTime(2009, 08, 15),
                    }

                     );
              
              */

                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Steve",
                        LastName = "Blank",
                        BirthDate = new DateTime(2009, 08, 15),
                        BookList = new List<Book>
                        {
                            new Book
                            {
                                Title = "deneme 1",
                                GenreId = 1,
                                PageCount = 200,
                                PublishedDate = new DateTime(2003, 06, 22)
                            }
                            // Diğer kitaplar buraya eklenebilir
                        }
                    },
                    new Author
                    {
                        Name = "Paula",
                        LastName = "King",
                        BirthDate = new DateTime(2009, 08, 15),
                        BookList = new List<Book>
                        {
                            new Book
                            {
                                Title = "deneme2",
                                GenreId = 2,
                                PageCount = 250,
                                PublishedDate = new DateTime(2005, 07, 19)
                            }
                            // Diğer kitaplar buraya eklenebilir
                        }
                    },
                    new Author
                    {
                        Name = "Frank",
                        LastName = "Helbert",
                        BirthDate = new DateTime(2009, 08, 15),
                        BookList = new List<Book>
                        {
                            new Book
                            {
                                Title = "deneme3",
                                GenreId = 3,
                                PageCount = 500,
                                PublishedDate = new DateTime(2009, 08, 15)
                            }
                            // Diğer kitaplar buraya eklenebilir
                        }
                    });


                context.SaveChanges();



            }


        }




    }
}
