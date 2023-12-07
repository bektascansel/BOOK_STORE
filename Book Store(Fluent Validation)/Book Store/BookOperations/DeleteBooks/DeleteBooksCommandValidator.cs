using FluentValidation;

namespace Book_Store.BookOperations.DeleteBooks
{
    public class DeleteBooksCommandValidator :  AbstractValidator<DeleteBooksCommand>
    {

        public DeleteBooksCommandValidator() { 
        
          RuleFor(command=>command.id).NotEmpty().GreaterThan(0);
          
        
        }
    }
}
