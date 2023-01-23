using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Está faltando a descrição do produto!");

            RuleFor(p => p.FabricationDate)
                .LessThan(p => p.LimitDate)
                    .WithMessage("A data de fabricação não pode ser posterior a data de validade!");

            RuleFor(p => p.LimitDate)
                .GreaterThan(p => p.FabricationDate)
                    .WithMessage("A data de validade não pode ser anterior a data de fabricação!");
        }
    }
}
