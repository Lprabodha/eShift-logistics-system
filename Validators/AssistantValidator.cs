using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using FluentValidation;

namespace eShift_Logistics_System.Validators
{
    /// <summary>
    /// Validator for the Assistant model.
    /// </summary>
    public class AssistantValidator : AbstractValidator<Assistant>
    {
        private readonly IAssistantRepository _assistantRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssistantValidator"/> class.
        /// </summary>
        /// <param name="assistantRepository"></param>
        public AssistantValidator(IAssistantRepository assistantRepository)
        {
            _assistantRepository = assistantRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must be under 100 characters.");

            RuleFor(x => x.Phone)
                .MaximumLength(20).WithMessage("Phone number must be under 20 characters.")
                .Matches(@"^\+?[0-9\s\-]+$").WithMessage("Phone number contains invalid characters.")
                .Must((assistant, phone) => BeUniquePhoneNumber(assistant, phone))
                .WithMessage("This phone number is already registered.")
                .When(assistant => !string.IsNullOrEmpty(assistant.Phone));

            RuleFor(x => x.Address)
                .MaximumLength(500).WithMessage("Address must be under 500 characters.")
                .When(assistant => !string.IsNullOrEmpty(assistant.Address));

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid status selected.");
        }

        private bool BeUniquePhoneNumber(Assistant assistant, string phone)
        {
            return !_assistantRepository.IsPhoneNumberExists(phone, assistant.Id);
        }
    }
}