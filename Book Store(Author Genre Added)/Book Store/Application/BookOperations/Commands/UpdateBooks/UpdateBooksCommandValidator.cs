
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Book_Store.Application.BookOperations.Commands.UpdateBooks
{
    public class UpdateBooksCommandValidator : AbstractValidator<UpdateBooksCommand>
    {

        public UpdateBooksCommandValidator()
        {
          
            RuleFor(command => command.Model.PublishedDate).LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).MinimumLength(3).When(x => x.Model.Title != string.Empty);
            RuleFor(command => command.Model.GenreId).GreaterThan(0).When(x => x.Model.GenreId != 0);
            RuleFor(command => command.Model.AuthorId).GreaterThan(0).When(x => x.Model.AuthorId != 0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0).When(x => x.Model.PageCount != 0);
            RuleFor(command => command.id).NotEmpty().GreaterThan(0);



        }

    }
}
