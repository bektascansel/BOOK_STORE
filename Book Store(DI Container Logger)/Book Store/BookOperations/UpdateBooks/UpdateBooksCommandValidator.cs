using Book_Store.Comman;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Book_Store.BookOperations.UpdateBooks
{
    public class UpdateBooksCommandValidator : AbstractValidator<UpdateBooksCommand>
    {

           public UpdateBooksCommandValidator() { 
        
                     RuleFor(command=>command.Model.PublishedDate).LessThan(DateTime.Now.Date);
                     RuleFor(command => command.Model.Title).MinimumLength(3);
                     RuleFor(command => command.Model.GenreId).GreaterThan(0);
                     RuleFor(command => command.Model.PageCount).GreaterThan(0);
                     RuleFor(command=>command.id).NotEmpty().GreaterThan(0);

        
        
           }
        
    }
}
