using DAL.Entities;
using DTOs.ProductDTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Validators
{
    public class CreateProductDTOValidator:AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(product => product.Name).NotNull();
            RuleFor(product => product.Description).NotNull();
            RuleFor(product => product.IsActive).NotNull();
        }
    }
}
