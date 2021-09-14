using FluentValidation;
using static CarRentalSystem.Domain.Models.ModelConstants.Common;
using static CarRentalSystem.Domain.Models.ModelConstants.PhoneNumber;

namespace CarRentalSystem.Application.Features.Identity.Commands.RegisterUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            this.RuleFor(u => u.Email)
            .MinimumLength(MinEmailLength)
            .MaximumLength(MaxEmailLength)
            .EmailAddress()
            .NotEmpty();

            this.RuleFor(u => u.Password)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.PhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .Matches(PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}
