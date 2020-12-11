using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.DTO.DTOs.AppUserDTOs;

namespace WorkflowManagement.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator: AbstractValidator<AppUserLoginDTO>
    {
        public AppUserLoginValidator()
        {
            RuleFor(a => a.UserName).NotNull().WithMessage("Kullanıcı adınızı giriniz");
            RuleFor(a => a.Password).NotNull().WithMessage("Şifrenizi giriniz");
        }
    }
}
