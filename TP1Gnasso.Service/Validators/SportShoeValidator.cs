using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Service.Validators
{
    public class SportShoeValidator: AbstractValidator<SportShoe>
    {
        public SportShoeValidator()
        {
            RuleFor(s => s.Model).NotEmpty().WithMessage("Model is required");
            RuleFor(s => s.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero");
            //RuleFor(s => s.Brand)
            //    .NotEmpty()
            //    .WithMessage("Brand is required");
            //RuleFor(s => s.Sport)
            //    .NotEmpty()
            //    .WithMessage("Sport is required");
            //RuleFor(s => s.Size)
            //    .NotEmpty()
            //    .WithMessage("The size is required");
            RuleFor(s => s.BrandId)
            .GreaterThan(0)
            .WithMessage("Brand is required");

            RuleFor(s => s.SportId)
                .GreaterThan(0)
                .WithMessage("Sport is required");

            RuleFor(s => s.SizeId)
                .GreaterThan(0)
                .WithMessage("Size is required");
        }

    }
}
