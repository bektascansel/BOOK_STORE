using Book_Store.BookOperations.CreatBooks;
using FluentValidation;

namespace Book_Store.BookOperations.CreateBooks
{
    public class CreateBooksCommandValidator : AbstractValidator<CreateBooksCommand>
    {

        public CreateBooksCommandValidator() { 
        
        
            RuleFor(command=>command.model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(command=>command.model.PageCount).NotEmpty().GreaterThan(0);
            RuleFor(command=>command.model.PublishedDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command=>command.model.Title).NotEmpty().MinimumLength(3);

        }

    }
}
