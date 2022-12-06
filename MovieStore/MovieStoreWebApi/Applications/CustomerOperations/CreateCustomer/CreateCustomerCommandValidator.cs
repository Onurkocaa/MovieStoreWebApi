using FluentValidation;
using MovieStoreWebApi.Application.CustomerOperations.Commands.CreateCustomer;

namespace MovieStoreWebApi.Application.CustomerOperations.CreateCustomer
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Email).NotEmpty();
            RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(5);
        }
    }
}