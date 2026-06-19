using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Service.Validators
{
    public class SizeValidator :AbstractValidator<Size>
    {
        public SizeValidator()
        {
            RuleFor(s => s.Number)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("The size number must be greater than zero");


        }
    }
}
