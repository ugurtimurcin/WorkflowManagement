using FluentValidation;
using WorkflowManagement.DTO.DTOs.UrgencyDTOs;

namespace WorkflowManagement.Business.ValidationRules.FluentValidation
{
    public class UrgencyEditValidator: AbstractValidator<UrgencyEditDTO>
    {
        public UrgencyEditValidator()
        {
            RuleFor(a => a.Title).NotNull().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
