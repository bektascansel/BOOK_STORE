using FluentValidation;

namespace Book_Store.Application.GenreOperations.Commands.UpdateGenres
{
    public class UpdateGenresCommandValidator : AbstractValidator<UpdateGenresCommand>
    {

        public UpdateGenresCommandValidator() { 
        
           RuleFor(x => x.GenreId).NotEmpty().GreaterThan(0);
           RuleFor(x=>x.Model.Name).MinimumLength(4).When(x=>x.Model.Name!=string.Empty); 

        }
    }
}
