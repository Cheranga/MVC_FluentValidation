using System;
using FluentValidation;
using MVC_FluentValidation_Intermediate.Models;
using MVC_FluentValidation_Intermediate.Repositories;

namespace MVC_FluentValidation_Intermediate.Validators
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        private readonly IRegisterModelRepository _registerModelRepository;

        public RegisterModelValidator(IRegisterModelRepository registerModelRepository)
        {
            if (registerModelRepository == null)
            {
                throw new ArgumentNullException(nameof(registerModelRepository), "The repository cannot be null");
            }

            _registerModelRepository = registerModelRepository;

            RuleFor(model => model).Custom((model, context) =>
            {
                //
                // TODO: Move to separate methods
                //
                if (string.IsNullOrEmpty(model.UserName))
                {
                    context.AddFailure(nameof(model.UserName), "Please provide a user name");
                }
                else
                {
                    var profileExists = _registerModelRepository.GetUserProfileByUserName(model.UserName) != null;
                    if (profileExists)
                    {
                        context.AddFailure(nameof(model.UserName), "Please choose another user name");
                    }
                }

                if (string.IsNullOrEmpty(model.Password))
                {
                    context.AddFailure(nameof(model.Password), "Please provide a password");
                }
                else if (model.Password.Length < 6 || model.Password.Length > 100)
                {
                    context.AddFailure(nameof(model.Password), "Please enter a password between 6-100 characters");
                }
                if (string.IsNullOrEmpty(model.ConfirmPassword))
                {
                    context.AddFailure(nameof(model.ConfirmPassword), "Please confirm the password");
                }
                if (string.Equals(model.Password, model.ConfirmPassword) == false)
                {
                    context.AddFailure(nameof(model.ConfirmPassword), "Passwords do not match");
                }
            });

            //RuleFor(model => model.UserName).NotNull().WithMessage("Please provide a user name");
            //RuleFor(model => model.Password).NotNull().WithMessage("Please provide a password")
            //    .Length(6, 100).WithMessage("Please enter a password between 6-100 characters");
            //RuleFor(model => model.ConfirmPassword).NotNull().WithMessage("Please confirm the password")
            //    .Equal(x => x.Password).WithMessage("Passwords do not match");
        }
    }
}