using FluentValidation;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Service.Validators
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator() 
        {
            RuleFor(b => b.Name)
                .NotEmpty()
                .WithMessage("Brand name is required");

            RuleFor(b => b.Country)
                .NotEmpty()
                .WithMessage("The country is required");
            ///Falta validacion de nombres repetidos

        }
    }
}
