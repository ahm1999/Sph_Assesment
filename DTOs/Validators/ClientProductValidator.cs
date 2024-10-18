using DAL.Entities;
using FluentValidation;

namespace DTOs.Validators
{
    public class ClientProductValidator:AbstractValidator<ClientProduct>
    {
        public ClientProductValidator()
        {
            RuleFor(clientProduct => clientProduct.ClientCode).NotNull();
            RuleFor(clientProduct => clientProduct.ProductId).NotNull();
            RuleFor(clientProduct => clientProduct.License).NotNull();
            RuleFor(clientProduct => clientProduct.StartData).NotNull();
            RuleFor(clientProduct => clientProduct.EndData).NotNull();
        }

    }
}
