using FluentValidation;

namespace Book_Store.Application.GenreOperations.Commands.CreateGenres
{
    public class CreateGenresCommandValidator : AbstractValidator<CreateGenresCommand>
    {
       public CreateGenresCommandValidator() { 
        
          RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(3);
        
        }


    }
}
