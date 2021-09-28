using System.Linq;
using System.Reflection;
using FluentValidation;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using UserService.Core.Entities;

namespace UserService.Features.UserManagement.Create
{
    [UsedImplicitly]
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            var baseProperties = typeof(IdentityUser).GetProperties().Select(x => x.Name);
            var properties = typeof(User).GetProperties()
                .Where(x => !baseProperties.Contains(x.Name))
                .ToList();
            RuleFor(x => properties).NotNull();
        }
    }
}