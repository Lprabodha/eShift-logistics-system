using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Validators
{
    class TransportUnitValidator : AbstractValidator<TransportUnit>
    {
        private readonly IUnitRepository _unitRepository;

        /// <summary>
        /// Validator for TransportUnit model to ensure valid data before saving to the repository.
        /// </summary>
        /// <param name="unitRepository"></param>
        public TransportUnitValidator(IUnitRepository unitRepository) {

            _unitRepository = unitRepository;


            RuleFor(unit => unit.TruckId)
                .GreaterThan(0).WithMessage("Please select a truck.");

            RuleFor(unit => unit.DriverId)
                .GreaterThan(0).WithMessage("Please select a driver.");

            RuleFor(unit => unit.AssistantId)
                 .GreaterThan(0).WithMessage("Please select an assistant.");

            RuleFor(unit => unit.Status)
                .IsInEnum().WithMessage("Invalid status selected.");

        }
    }
}
