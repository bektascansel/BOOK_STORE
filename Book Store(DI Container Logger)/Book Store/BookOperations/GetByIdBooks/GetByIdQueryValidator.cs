using FluentValidation;

namespace Book_Store.BookOperations.GetByIdBooks
{
    public class GetByIdQueryValidator: AbstractValidator<GetByIdQuery>
    {

        public GetByIdQueryValidator()
        {
            RuleFor(query=>query.id).NotEmpty().GreaterThan(0);
        }
    }
}
