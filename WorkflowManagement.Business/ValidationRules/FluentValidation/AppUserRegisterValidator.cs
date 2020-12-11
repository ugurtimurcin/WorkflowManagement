using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.DTO.DTOs.AppUserDTOs;

namespace WorkflowManagement.Business.ValidationRules.FluentValidation
{
    public class AppUserRegisterValidator: AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(a => a.FirstName).NotNull().WithMessage("İsim alanı boş bırakılamaz");
            RuleFor(a => a.LastName).NotNull().WithMessage("Soyisim alanı boş bırakılamaz");
            RuleFor(a => a.UserName).NotNull().WithMessage("Kullanıcı adı alanı boş bırakılamaz");
            RuleFor(a => a.Password).NotNull().WithMessage("Şifre alanı boş bırakılamaz");
            RuleFor(a => a.RePassword).NotNull().WithMessage("Şifre tekrar alanı boş bırakılamaz");
            RuleFor(a => a.RePassword).Equal(a => a.Password).WithMessage("Parolalar eşleşmiyor");
            RuleFor(a => a.Email).NotNull().WithMessage("E-posta alanı boş bırakılamaz").EmailAddress().WithMessage("Geçersiz e-posta girdiniz");
        }
    }
}
