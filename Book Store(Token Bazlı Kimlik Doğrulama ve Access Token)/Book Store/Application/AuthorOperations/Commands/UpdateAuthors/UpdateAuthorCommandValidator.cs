using FluentValidation;

namespace Book_Store.Application.AuthorOperations.Commands.UpdateAuthors
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator() {

            RuleFor(x=>x.id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(3).When(x => x.Model.Name != string.Empty);
            RuleFor(x => x.Model.LastName).MinimumLength(3).When(x => x.Model.LastName != string.Empty);
            RuleFor(x => x.Model.BirthDate.Date).NotEmpty().LessThan(DateTime.Now.Date);

        }
    
    }
}
