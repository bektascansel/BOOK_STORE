using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Entities
{
    public class Author
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Book> BookList { get; set;}



    }
}
