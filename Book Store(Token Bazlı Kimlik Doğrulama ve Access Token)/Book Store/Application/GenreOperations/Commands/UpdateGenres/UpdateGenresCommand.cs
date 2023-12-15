using AutoMapper;
using Book_Store.DBContext;
using Book_Store.Entities;

namespace Book_Store.Application.GenreOperations.Commands.UpdateGenres
{
    public class UpdateGenresCommand
    {

        private readonly BookStoreDBContext _context;

        private readonly IMapper _mapper;
        public UpdateGenreModel Model { get; set; }

        public int GenreId { get; set; }

        public UpdateGenresCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        public void Handle()
        {
            var genre= _context.Genres.SingleOrDefault(x=>x.Id==GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("The Genre is not Exist");

            }
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id!= GenreId))
            {
                throw new InvalidOperationException("The genre which has same name is exist");
            }


            genre = _mapper.Map(Model, genre);
            _context.SaveChanges();

        }




    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }



    }
}
