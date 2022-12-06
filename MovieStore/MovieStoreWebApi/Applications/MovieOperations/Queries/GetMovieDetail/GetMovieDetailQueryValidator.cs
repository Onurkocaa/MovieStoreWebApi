using FluentValidation;
using System;
namespace Applications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
         RuleFor(query => query.MovieId).GreaterThan(0);
        }
    }
}