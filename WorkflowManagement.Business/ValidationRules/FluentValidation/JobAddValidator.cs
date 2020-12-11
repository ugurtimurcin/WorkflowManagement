using FluentValidation;
using WorkflowManagement.DTO.DTOs.JobDTOs;

namespace WorkflowManagement.Business.ValidationRules.FluentValidation
{
    public class JobAddValidator: AbstractValidator<JobAddDTO>
    {
        public JobAddValidator()
        {
            RuleFor(a => a.Title).NotNull().WithMessage("Görev alanı boş bırakılamaz");
            RuleFor(a => a.Description).NotNull().WithMessage("Lütfen görev açıklaması giriniz");
            RuleFor(a => a.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz");
        }
    }
}
