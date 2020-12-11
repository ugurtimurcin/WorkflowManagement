using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.DTO.DTOs.ReportDTOs;

namespace WorkflowManagement.Business.ValidationRules.FluentValidation
{
    public class ReportAddValidator: AbstractValidator<ReportAddDTO>
    {
        public ReportAddValidator()
        {
            RuleFor(a => a.Title).NotNull().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(a => a.Description).NotNull().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
