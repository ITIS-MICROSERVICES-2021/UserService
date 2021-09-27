using System.Linq;
using FluentValidation;
using JetBrains.Annotations;
using UserService.Core.Entities;

namespace UserService.Features.UserManagement.Create
{
    [UsedImplicitly]
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleForEach(userFields => typeof(User).GetProperties().ToList()).NotNull();
        }
    }
}