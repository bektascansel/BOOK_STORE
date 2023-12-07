﻿using AutoMapper;
using Book_Store;
using Book_Store.BookOperations.CreatBooks;
using Book_Store.BookOperations.DeleteBooks;
using Book_Store.BookOperations.GetBooks;
using Book_Store.BookOperations.GetByIdBooks;
using Book_Store.BookOperations.UpdateBooks;
using Book_Store.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;
      

        public BookController(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

     
        
        [HttpGet]
        public IActionResult GetBooks()
        {

            GetBooksQuery getBooksQuery = new GetBooksQuery(_dbContext,_mapper);
            var result = getBooksQuery.Handle();

            return Ok(result);

        }



        //Route üzerinden parametre alarak;
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetByIdQuery getByIdQuery = new GetByIdQuery(_dbContext, _mapper);
            getByIdQuery.id = id;
            try
            {
              var result = getByIdQuery.Handle();
              return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            

        }
        


        [HttpPost]
        public IActionResult AddBook([FromBody]CreateBookModel bookModel)
        {
           CreateBooksCommand createBooksCommand=new CreateBooksCommand(_dbContext,_mapper);
            try
            {
                createBooksCommand.model = bookModel;
                createBooksCommand.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody]UpdateBookModel updateBookModel)
        {
            UpdateBooksCommand updateBooksCommand=new UpdateBooksCommand(_dbContext, _mapper);
            try { 
             updateBooksCommand.Model = updateBookModel;
             updateBooksCommand.id = id;
             updateBooksCommand.Handle() ;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();



        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) {


            DeleteBooksCommand deleteBooksCommand = new DeleteBooksCommand(_dbContext);
            try
            {
                deleteBooksCommand.id = id;
                deleteBooksCommand.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }
    }
}
