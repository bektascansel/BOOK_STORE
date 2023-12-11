using AutoMapper;
using Book_Store.Application.AuthorOperations.Commands.CreateAuthors;
using Book_Store.Application.AuthorOperations.Commands.DeleteAuthors;
using Book_Store.Application.AuthorOperations.Commands.UpdateAuthors;
using Book_Store.Application.AuthorOperations.Queries.GetAuthors;
using Book_Store.Application.AuthorOperations.Queries.GetByIdAuthors;
using Book_Store.DBContext;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDBContext _context;


        public AuthorController (IMapper mapper, BookStoreDBContext context)
        {
            _mapper = mapper;
            _context = context;

        }


        [HttpGet]
        public IActionResult GetBooks() {

            GetAuthorsQuery getAuthorsQuery = new GetAuthorsQuery(_context,_mapper);
            var result=getAuthorsQuery.Handle();

            return Ok(result);
        
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
        
             GetByIdAuthorQuery getByIdAuthorQuery= new GetByIdAuthorQuery(_context,_mapper);
             getByIdAuthorQuery.id = id;

             GetByIdAuthorQueryValidator validator= new GetByIdAuthorQueryValidator();
             validator.ValidateAndThrow(getByIdAuthorQuery);

             var result=getByIdAuthorQuery.Handle();
             return Ok(result);
        
        }


        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorModel Model)
        {
            CreateAuthorsCommand createAuthorsCommand = new CreateAuthorsCommand(_context, _mapper);
            createAuthorsCommand.Model = Model;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(createAuthorsCommand);

            createAuthorsCommand.Handle();
            return Ok();


        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody]UpdateAuthorModel Model)
        {
            UpdateAuthorCommand updateAuthorCommand= new UpdateAuthorCommand(_context, _mapper);
            updateAuthorCommand.id = id;
            updateAuthorCommand.Model = Model;

            UpdateAuthorCommandValidator validator= new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(updateAuthorCommand);

            updateAuthorCommand.Handle();
            return Ok();

        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            DeleteAuthorCommand deleteAuthorCommand = new DeleteAuthorCommand(_context);
            deleteAuthorCommand.id = id;

            DeleteAuthorCommandValidator validator= new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(deleteAuthorCommand);

            deleteAuthorCommand.Handle();
            return Ok();
        }




    }
}
