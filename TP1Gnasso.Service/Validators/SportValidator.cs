using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Service.Validators
{
    public class SportValidator: AbstractValidator<Sport>
    {
        public SportValidator()
        {
            RuleFor(s => s.Name)
                     .NotEmpty()
                     .WithMessage("The sport name is required");

        }


    }
}
