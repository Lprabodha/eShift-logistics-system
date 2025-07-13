using eShift_Logistics_System.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Validators
{
    public class JobValidator : AbstractValidator<Job>
    {
        /// <summary>
        /// Validator for Job model to ensure valid data before saving to the repository.
        /// </summary>
        public JobValidator()
        {
            RuleFor(job => job.CustomerId)
                .GreaterThan(0).WithMessage("A valid customer must be associated with the job.");

            RuleFor(job => job.PickupLocation)
                .NotEmpty().WithMessage("Pickup location cannot be empty.")
                .MaximumLength(500).WithMessage("Pickup location text is too long.");

            RuleFor(job => job.DeliveryLocation)
                .NotEmpty().WithMessage("Delivery location cannot be empty.")
                .MaximumLength(500).WithMessage("Delivery location text is too long.");

            RuleFor(job => job.RequestedDate)
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("The requested pickup date cannot be in the past.");

            RuleFor(job => job.JobProducts)
                .NotEmpty().WithMessage("Please add at least one product to the shipment list.");
        }
    }
}
