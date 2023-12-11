
using FluentValidation;

namespace Book_Store.Application.AuthorOperations.Commands.DeleteAuthors
{
    public class DeleteAuthorCommandValidator: AbstractValidator<DeleteAuthorCommand>
    {

       

            public DeleteAuthorCommandValidator()
            {

                RuleFor(x => x.id).NotEmpty().GreaterThan(0);

            }
       

    }
}
