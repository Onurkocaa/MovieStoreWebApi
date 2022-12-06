using FluentValidation;

namespace MovieStoreWebApi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.PlayedMovies).NotEmpty();
        }
    }
}