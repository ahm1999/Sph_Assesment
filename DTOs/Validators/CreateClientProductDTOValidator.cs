using FluentValidation;
using DTOs.ClientProductDTOs;

namespace DTOs.Validators
{
    public class CreateClientProductDTOValidator:AbstractValidator<CreateClientProductDTO>
    {

        public CreateClientProductDTOValidator()
        {
            RuleFor(clientProduct => clientProduct.ClientCode).NotNull();
            RuleFor(clientProduct => clientProduct.ProductId).NotNull();
            RuleFor(clientProduct => clientProduct.License).NotNull();
            RuleFor(clientProduct => clientProduct.StartData).NotNull();
            RuleFor(clientProduct => clientProduct.EndData).NotNull();
        }
    }
}
