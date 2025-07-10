using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using eShift_Logistics_System.Repository.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Validators
{
    public class DriverValidator : AbstractValidator<Driver>
    {
        private readonly IDriverRepository _driverRepository;

        /// <summary>
        /// Validator for Driver model.
        /// </summary>
        /// <param name="driverRepository"></param>
        public DriverValidator(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;

            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(100).WithMessage("Name must be under 100 characters.");

            RuleFor(x => x.LicenseNumber)
                .NotEmpty().WithMessage("License number is required.")
                .MaximumLength(50).WithMessage("License number must be under 50 characters.")
                .Must((driver, license) => BeUniqueLicenseNumber(driver, license))
                .WithMessage("This license number is already registered.");

            RuleFor(x => x.Phone)
                .MaximumLength(20).WithMessage("Phone number must be under 20 characters.")
                .Matches(@"^\+?[0-9\s\-]+$").WithMessage("Phone number contains invalid characters.")
                .Must((driver, phone) => BeUniquePhoneNumber(driver, phone))
                .WithMessage("This phone number is already registered.")
                .When(driver => !string.IsNullOrEmpty(driver.Phone));

            RuleFor(x => x.Address)
                .MaximumLength(500).WithMessage("Address must be under 500 characters.")
                .When(driver => !string.IsNullOrEmpty(driver.Address));

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid status selected.");
        }

        /// <summary>
        /// Checks if the phone number is unique in the repository, excluding the current driver's ID.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        private bool BeUniquePhoneNumber(Driver driver, string phone)
        {
            return !_driverRepository.IsPhoneNumberExists(phone, driver.Id);
        }

        /// <summary>
        /// Checks if the license number is unique in the repository, excluding the current driver's ID.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="licenseNumber"></param>
        /// <returns></returns>
        private bool BeUniqueLicenseNumber(Driver driver, string licenseNumber)
        {
            return !_driverRepository.IsLicenseNumberExists(licenseNumber, driver.Id);
        }
    }
}
