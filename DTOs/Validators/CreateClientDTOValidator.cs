using FluentValidation;
using DTOs.ClientDTOS;

namespace DTOs.Validators
{
    public class CreateClientDTOValidator:AbstractValidator<CreateCLientDTO>
    {
        public CreateClientDTOValidator()
        {
            RuleFor(client => client.Name).NotNull();
            RuleFor(client => client.State).NotNull();
            RuleFor(client => client.CLientClass).NotNull();
        }
    }
}
