using AutoMapper;
using Book_Store.DBContext;
using Book_Store.Entities;

namespace Book_Store.Application.GenreOperations.Commands.CreateGenres
{
    public class CreateGenresCommand
    {

        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public CreateGenreModel Model { get; set; }

        public CreateGenresCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        public void Handle()
        {
            var existGenre=_context.Genres.FirstOrDefault(x=>x.Name==Model.Name);

            if (existGenre is not null)
                throw new InvalidOperationException("The genre is exist");

            existGenre=new Genre();
            existGenre=_mapper.Map<Genre>(Model);
            _context.Genres.Add(existGenre);
            _context.SaveChanges();
                            
        }



    }

    public class CreateGenreModel()
    {
        public string Name { get; set; }


    }
}
