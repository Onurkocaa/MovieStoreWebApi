using FluentValidation;

namespace MovieStoreWebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.FilmsDirected).NotEmpty();
            RuleFor(command => command.DirectorId).GreaterThan(0);
        }
    }
}