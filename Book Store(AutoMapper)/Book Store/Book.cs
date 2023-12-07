using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store
{
    public class Book
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }

        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }

        public Book(int ıd, string title, int genreId, int pageCount, DateTime publishedDate)
        {
            Id = ıd;
            Title = title;
            GenreId = genreId;
            PageCount = pageCount;
            PublishedDate = publishedDate;
        }

        public Book()
        {

        }
    }
}
