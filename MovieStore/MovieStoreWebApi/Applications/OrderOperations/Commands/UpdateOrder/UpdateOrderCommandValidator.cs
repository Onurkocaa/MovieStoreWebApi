using FluentValidation;

namespace MovieStoreWebApi.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(command => command.OrderId).GreaterThan(0).NotEmpty();
            RuleFor(command => command.Model.MovieId).GreaterThan(0).NotEmpty();
            RuleFor(command => command.Model.CustomerId).GreaterThan(0).NotEmpty();
        }
    }
}