using FluentValidation;

namespace Applications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidator :AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
          RuleFor(command => command.MovieId).GreaterThan(0);
        }
    }
}