using AutoMapper;
using Book_Store.DBContext;

namespace Book_Store.Application.GenreOperations.Commands.DeleteGenres
{
    public class DeleteGenresCommand
    {
        private readonly BookStoreDBContext _context;
        
        public int GenreId { get; set; }

        public DeleteGenresCommand(BookStoreDBContext context)
        {
            _context = context;
           
        }

        public void Handle()
        {
            var genre=_context.Genres.FirstOrDefault(x=>x.Id==GenreId);

            if (genre == null)
            {
                throw new InvalidOperationException("The Genre is not exist");
            }

            _context.Genres.Remove(genre);
            _context.SaveChanges();

        }



    }
}
