using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using MVC_FluentValidation.ViewModels;

namespace MVC_FluentValidation.Validators
{
    public class AddMovieViewModelValidator : AbstractValidator<AddMovieFluentViewModel>
    {
        public AddMovieViewModelValidator()
        {
            RuleFor(model => model.Title).NotEmpty().WithMessage("Please enter a title");
            RuleFor(model => model.ReleaseDate).NotNull().WithMessage("Please enter a release date");
            RuleFor(model => model.RunningTimeMinutes).NotNull().WithMessage("Please enter the duration of the movie")
                .GreaterThan(0).WithMessage("Please enter a duration greater than zero");

            RuleFor(model => model.LeadingActor).NotNull().WithMessage("Please enter the leading actor name")
                .NotEqual(model => model.SupportingActor).WithMessage("Both leading and supporting actors cannot be the same");

        }
    }
}