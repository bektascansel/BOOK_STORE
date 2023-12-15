using FluentValidation;

namespace Book_Store.Application.AuthorOperations.Queries.GetByIdAuthors
{
    public class GetByIdAuthorQueryValidator: AbstractValidator<GetByIdAuthorQuery>
    {

        public GetByIdAuthorQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().GreaterThan(0);
        }
    }
}
