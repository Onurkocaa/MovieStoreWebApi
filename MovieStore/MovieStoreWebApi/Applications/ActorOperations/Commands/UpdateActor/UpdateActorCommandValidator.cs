using FluentValidation;

namespace MovieStoreWebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.PlayedMovies).NotEmpty();
            RuleFor(command => command.ActorId).GreaterThan(0);
        }
    }
}