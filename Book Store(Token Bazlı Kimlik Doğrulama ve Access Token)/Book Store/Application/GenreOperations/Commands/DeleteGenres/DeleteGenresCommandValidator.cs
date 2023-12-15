using FluentValidation;

namespace Book_Store.Application.GenreOperations.Commands.DeleteGenres
{
    public class DeleteGenresCommandValidator : AbstractValidator<DeleteGenresCommand>
    {

        public DeleteGenresCommandValidator() { 
           
            RuleFor(x=>x.GenreId).NotEmpty().GreaterThan(0);
        
        }
    }
}
