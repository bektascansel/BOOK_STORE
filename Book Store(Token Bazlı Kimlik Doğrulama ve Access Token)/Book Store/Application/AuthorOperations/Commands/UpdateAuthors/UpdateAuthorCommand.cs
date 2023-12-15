using AutoMapper;
using Book_Store.DBContext;
using Book_Store.Entities;

namespace Book_Store.Application.AuthorOperations.Commands.UpdateAuthors
{
    public class UpdateAuthorCommand
    {

        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public UpdateAuthorModel Model { get; set; }
        public int id { get; set; }


        public UpdateAuthorCommand( BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }


        public void Handle()
        {
            var author= _context.Authors.SingleOrDefault(x=> x.Id==id);

            if(author is null) {
                throw new InvalidOperationException("The Author is not exist");
            }

           if (_context.Authors.Any(x => x.Name.ToLower() == Model.Name.ToLower() ))
            {
                if (_context.Authors.Any(x => x.LastName.ToLower() == Model.LastName.ToLower())) 
                    throw new InvalidOperationException("The Author which has same name and lastName is exist");
            }

            author = _mapper.Map(Model,author);
            _context.SaveChanges();

        }


    }



    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
