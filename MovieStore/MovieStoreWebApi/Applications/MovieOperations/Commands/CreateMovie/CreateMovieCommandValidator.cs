using System;
using FluentValidation;

namespace Applications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
    public CreateMovieCommandValidator()
    {
    RuleFor(command => command.Model.GenreID).NotEmpty().GreaterThan(0);
    RuleFor(command => command.Model.Price).NotEmpty().GreaterThan(0);
    RuleFor(command => command.Model.Year).NotEmpty().MinimumLength(4).MaximumLength(4);
    RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);
    RuleFor(command => command.Model.Actors).NotEmpty().MinimumLength(2); 
    RuleFor(command => command.Model.Director).NotEmpty().MinimumLength(2); 
      
    }
    }
}