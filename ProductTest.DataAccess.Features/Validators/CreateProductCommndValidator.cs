using FluentValidation;
using ProductTest.DataAccess.Features.ProductFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.DataAccess.Features.Validators
{
    public class CreateProductCommndValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommndValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(5).MaximumLength(10);
            RuleFor(c => c.MRP).NotEmpty().GreaterThan(10).LessThan(50);
        }
    }
}
