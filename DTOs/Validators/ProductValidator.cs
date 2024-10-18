using DAL.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Validators
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotNull();
            RuleFor(product => product.ProductId).NotNull();
            RuleFor(product => product.Description).NotNull();
            RuleFor(product => product.IsActive).NotNull();
        }


    }
}
