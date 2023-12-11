using FluentValidation;

namespace Book_Store.Application.GenreOperations.Queries.GetByIdGenres
{
    public class GetByIdGenreQueryValidator : AbstractValidator<GetByIdGenreQuery>
    {
         
        public GetByIdGenreQueryValidator()
        {
            RuleFor(X=>X.GenreId).GreaterThan(0);

        }


    }
}
