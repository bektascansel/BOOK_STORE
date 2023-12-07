using AutoMapper;
using Book_Store.BookOperations.CreatBooks;
using Book_Store.BookOperations.GetBooks;
using Book_Store.BookOperations.GetByIdBooks;
using Book_Store.BookOperations.UpdateBooks;
using Book_Store.Comman;

namespace Book_Store.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile() {

            //<source,target>
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewsModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString())); ;
            CreateMap<Book,GetByIdViewsModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString())); ;
            CreateMap<UpdateBookModel, Book>();
        }


    }
}
