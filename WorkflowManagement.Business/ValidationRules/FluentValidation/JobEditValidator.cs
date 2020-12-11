using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.DTO.DTOs.JobDTOs;

namespace WorkflowManagement.Business.ValidationRules.FluentValidation
{
    public class JobEditValidator: AbstractValidator<JobEditDTO>
    {
        public JobEditValidator()
        {
            RuleFor(a => a.Title).NotNull().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(a => a.Description).NotNull().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(a => a.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz");
        }
    }
}
