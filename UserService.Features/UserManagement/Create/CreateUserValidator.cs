using FluentValidation;
using JetBrains.Annotations;

namespace UserService.Features.UserManagement.Create
{
    [UsedImplicitly]
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        //пример
        public CreateUserValidator()
        {
            RuleFor(x => x.SomeProp).NotEmpty()
                .WithMessage("Sample")
                .WithErrorCode("422");
        }
    }
}