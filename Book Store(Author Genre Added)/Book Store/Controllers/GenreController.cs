using AutoMapper;
using Book_Store.Application.GenreOperations.Commands.CreateGenres;
using Book_Store.Application.GenreOperations.Commands.DeleteGenres;
using Book_Store.Application.GenreOperations.Commands.UpdateGenres;
using Book_Store.Application.GenreOperations.Queries.GetByIdGenres;
using Book_Store.Application.GenreOperations.Queries.GetGenres;
using Book_Store.DBContext;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDBContext dbContext, IMapper mapper)
        {            
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
       
        public IActionResult GetBooks()
        {
            GetGenresQuery getGenresQuery = new GetGenresQuery(_dbContext, _mapper);
            var results = getGenresQuery.Handle();

            return Ok(results);
        }


        [HttpGet("{id}")]
        
        public IActionResult GetById(int id)
        {
            GetByIdGenreQuery getByIdGenreQuery = new GetByIdGenreQuery(_dbContext, _mapper);
            getByIdGenreQuery.GenreId= id;

            GetByIdGenreQueryValidator validator= new GetByIdGenreQueryValidator();
            validator.ValidateAndThrow(getByIdGenreQuery);

            var result= getByIdGenreQuery.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel Model)
        {
            CreateGenresCommand createGenresCommand = new CreateGenresCommand(_dbContext, _mapper);
            createGenresCommand.Model = Model;

            CreateGenresCommandValidator validator = new CreateGenresCommandValidator();
            validator.ValidateAndThrow(createGenresCommand);

            createGenresCommand.Handle();
            return Ok();

        }


        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel Model)
        {
            UpdateGenresCommand updateGenresCommand =new UpdateGenresCommand(_dbContext, _mapper);
            updateGenresCommand.GenreId= id;
            updateGenresCommand.Model = Model;

            UpdateGenresCommandValidator validator = new UpdateGenresCommandValidator();
            validator.ValidateAndThrow(updateGenresCommand);

            updateGenresCommand.Handle();
            return Ok();
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id) {

            DeleteGenresCommand deleteGenresCommand = new DeleteGenresCommand(_dbContext);
            deleteGenresCommand.GenreId = id;

            DeleteGenresCommandValidator validator = new DeleteGenresCommandValidator();
            validator.ValidateAndThrow(deleteGenresCommand); 

            deleteGenresCommand.Handle();
            return Ok();
        
        }
    }
}
