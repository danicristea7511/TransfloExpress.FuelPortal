using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransfloExpress.FuelPortal.Application.Contract.Persistence;

namespace TransfloExpress.FuelPortal.Application.Features.CustomerType.Commands.CreateCustomerType
{
    public class CreateCustomerTypeCommandValidator: AbstractValidator<CreateCustomerTypeCommand>
    {
        private readonly ICustomerTypeRepository _customerTypeRepository;

        public CreateCustomerTypeCommandValidator(ICustomerTypeRepository customerTypeRepository)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(q => q)
                .MustAsync(CustomerTypeNameUnique)
                .WithMessage("Customer Type already exists");

            _customerTypeRepository = customerTypeRepository;
        }

        private Task<bool> CustomerTypeNameUnique(CreateCustomerTypeCommand command, CancellationToken token)
        {
            return _customerTypeRepository.IsCustomerTypeUnique(command.Name);
        }
    }
}
