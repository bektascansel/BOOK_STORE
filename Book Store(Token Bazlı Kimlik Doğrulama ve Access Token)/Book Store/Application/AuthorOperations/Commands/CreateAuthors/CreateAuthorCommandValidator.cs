using FluentValidation;

namespace Book_Store.Application.AuthorOperations.Commands.CreateAuthors
{
    public class CreateAuthorCommandValidator: AbstractValidator<CreateAuthorsCommand>
    {

        public CreateAuthorCommandValidator() {
        
           RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(3);
           RuleFor(x => x.Model.LastName).NotEmpty().MinimumLength(3);
           RuleFor(x => x.Model.BirthDate.Date).NotEmpty().LessThan(DateTime.Now.Date);

        }

    }
}
