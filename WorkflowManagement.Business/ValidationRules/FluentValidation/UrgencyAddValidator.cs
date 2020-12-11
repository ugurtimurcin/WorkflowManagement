using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.DTO.DTOs.UrgencyDTOs;

namespace WorkflowManagement.Business.ValidationRules.FluentValidation
{
    public class UrgencyAddValidator: AbstractValidator<UrgencyAddDTO>
    {
        public UrgencyAddValidator()
        {
            RuleFor(a => a.Title).NotNull().WithMessage("Aciliyet başlığı giriniz.");
        }
    }
}
