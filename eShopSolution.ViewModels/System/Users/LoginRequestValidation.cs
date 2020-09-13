using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class LoginRequestValidation : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidation()
        {
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(x=>x.PassWord).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 characters");
        }
    }
}
