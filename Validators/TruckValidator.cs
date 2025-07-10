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
    public class TruckValidator : AbstractValidator<Truck>
    {
        /// <summary>
        /// Validator for Truck model to ensure data integrity and business rules are followed.
        /// </summary>
        private readonly ITruckRepository _truckRepository;
        public TruckValidator(ITruckRepository truckRepository) {

            _truckRepository = truckRepository;

            RuleFor(truck => truck.TruckNumber)
               .NotEmpty().WithMessage("Truck number is required.")
               .MaximumLength(50).WithMessage("Truck number must be under 50 characters.")
               .Matches(@"^[a-zA-Z0-9\-]+$").WithMessage("Truck number can only contain letters, digits, and dashes.")
               .Must((truck, number) => BeUniqueTruckNumber(truck, number))
               .WithMessage("This truck number is already registered.");

            RuleFor(truck => truck.Model)
                .NotEmpty().WithMessage("Model is required.")
                .MaximumLength(100).WithMessage("Model must be under 100 characters.");

            RuleFor(truck => truck.Capacity)
                .GreaterThan(0).WithMessage("Capacity must be greater than zero.")
                .LessThanOrEqualTo(10000).WithMessage("Capacity cannot exceed 10,000 kg.")
                .Must(capacity => capacity % 1 == 0).WithMessage("Capacity must be a whole number.");

            RuleFor(truck => truck.LicensePlate)
               .NotEmpty().WithMessage("License plate is required.")
               .MaximumLength(50).WithMessage("License plate must be under 50 characters.")
               .Must((truck, license) => BeUniqueLicensePlate(truck, license))
               .WithMessage("This license plate is already registered.");

        }

        /// <summary>
        /// Checks if the truck number is unique in the system, excluding the current truck's ID if it exists.
        /// </summary>
        /// <param name="truck"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool BeUniqueTruckNumber(Truck truck, string number)
        {
            return !_truckRepository.IsTruckNumberExists(number, truck.Id);
        }

        /// <summary>
        /// Checks if the license plate is unique in the system, excluding the current truck's ID if it exists.
        /// </summary>
        /// <param name="truck"></param>
        /// <param name="licensePlate"></param>
        /// <returns></returns>
        private bool BeUniqueLicensePlate(Truck truck, string licensePlate)
        {
            return !_truckRepository.IsLicensePlateExists(licensePlate, truck.Id);
        }
    }
}
