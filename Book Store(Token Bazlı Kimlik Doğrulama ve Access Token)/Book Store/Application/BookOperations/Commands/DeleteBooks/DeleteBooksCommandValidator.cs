using FluentValidation;

namespace Book_Store.Application.BookOperations.Commands.DeleteBooks
{
    public class DeleteBooksCommandValidator : AbstractValidator<DeleteBooksCommand>
    {

        public DeleteBooksCommandValidator()
        {

            RuleFor(command => command.id).NotEmpty().GreaterThan(0);


        }
    }
}
