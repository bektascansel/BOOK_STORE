using AutoMapper;
using Book_Store.Application.BookOperations.Commands.CreateBooks;
using Book_Store.Application.BookOperations.Commands.UpdateBooks;
using Book_Store.Application.BookOperations.Queries.GetBooks;
using Book_Store.Application.BookOperations.Queries.GetByIdBooks;
using Book_Store.Application.GenreOperations.Commands.CreateGenres;
using Book_Store.Application.GenreOperations.Commands.UpdateGenres;
using Book_Store.Application.GenreOperations.Queries.GetGenres;
using Book_Store.Application.GenreOperations.Queries.GetByIdGenres;

using Book_Store.Entities;
using Book_Store.Application.AuthorOperations.Queries.GetByIdAuthors;
using Book_Store.Application.AuthorOperations.Queries.GetAuthors;
using Book_Store.Application.AuthorOperations.Commands.CreateAuthors;
using Book_Store.Application.AuthorOperations.Commands.UpdateAuthors;
using Book_Store.Application.UserOperations.Commands.CreateUser;


namespace Book_Store.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile() {

            //<source,target>
            CreateMap<CreateBookModel, Book>();

            CreateMap<Book, BookViewsModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.LastName));

            CreateMap<Book, GetByIdViewsModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name+" "+src.Author.LastName));

            CreateMap<UpdateBookModel, Book>()
             .ForMember(dest => dest.Title, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Title)))
             .ForMember(dest => dest.PageCount, opt => opt.Condition(src => src.PageCount != 0))
             .ForMember(dest => dest.PublishedDate, opt => opt.Condition(src => src.PublishedDate != DateTime.MinValue))
             .ForMember(dest => dest.GenreId, opt => opt.Condition(src => src.GenreId != 0))
             .ForMember(dest => dest.AuthorId, opt => opt.Condition(src => src.AuthorId != 0));





            CreateMap<Genre, GetViewsModel>();


            CreateMap<Genre, GetByIdViewModel>();
            CreateMap<CreateGenreModel, Genre>();
      
            CreateMap<UpdateGenreModel, Genre>().ForMember(dest => dest.Name, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Name)));
            

            CreateMap<Author, GetByIdAuthorModel>();
            CreateMap<Author, AuthorViewsModel>();
            CreateMap<CreateAuthorModel, Author>();
            //CreateMap<UpdateAuthorModel, Author>();
            CreateMap<UpdateAuthorModel, Author>()
             .ForMember(dest => dest.Name, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Name)))
              .ForMember(dest => dest.LastName, opt => opt.Condition(src => !string.IsNullOrEmpty(src.LastName)));



            CreateMap<CreateUserModel, User>();

        }

      

    }
}
