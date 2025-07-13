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
    public class ProductValidator : AbstractValidator<Product>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Validator for Product model to ensure valid data before saving to the repository.
        /// </summary>
        /// <param name="productRepository"></param>
        public ProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Product Name is required.")
                .MaximumLength(100).WithMessage("Name must be under 100 characters.")
                .Must((product, name) => BeUniqueName(product, name))
                .WithMessage("A product with this name already exists.");

            RuleFor(product => product.DefaultWeight)
                .GreaterThan(0).WithMessage("Weight must be a positive number.")
                .When(product => product.DefaultWeight.HasValue);

            RuleFor(product => product.DefaultDimensions)
                .MaximumLength(100).WithMessage("Dimensions text must be under 100 characters.")
                .When(product => !string.IsNullOrEmpty(product.DefaultDimensions));
        }

        private bool BeUniqueName(Product product, string name)
        {
            return !_productRepository.IsNameExists(name, product.Id);
        }
    }
}
