using FluentValidation;
using DAL.Entities;

namespace DTOs.Validators
{
    public class ClientValidator:AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(client => client.Name).NotNull();
            RuleFor(client => client.Code).NotNull();
            RuleFor(client => client.State).NotNull();
            RuleFor(client => client.CLientClass).NotNull();
        }
    }
}
