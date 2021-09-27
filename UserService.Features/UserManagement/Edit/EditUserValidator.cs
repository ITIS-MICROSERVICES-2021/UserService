using FluentValidation;
using JetBrains.Annotations;

namespace UserService.Features.UserManagement.Edit
{
    [UsedImplicitly]
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        private const int MaxLength = 64;
        private const string LengthValidationMessage = "Длина поля {0} не должна привышать {1} символа";
        public EditUserValidator()
        {
            RuleFor(x => x.EditUserInputDto.Name)
                .MaximumLength(64)
                .WithMessage(GenerateLengthErrorMessage(nameof(EditUserCommand.EditUserInputDto.Name)))
                .WithErrorCode("422");
            
            RuleFor(x => x.EditUserInputDto.Surname)
                .MaximumLength(64)
                .WithMessage(GenerateLengthErrorMessage(nameof(EditUserCommand.EditUserInputDto.Surname)))
                .WithErrorCode("422");
            
            RuleFor(x => x.EditUserInputDto.Patronymic)
                .MaximumLength(64)
                .WithMessage(GenerateLengthErrorMessage(nameof(EditUserCommand.EditUserInputDto.Patronymic)))
                .WithErrorCode("422");
            
            RuleFor(x => x.EditUserInputDto.Position)
                .MaximumLength(64)
                .WithMessage(GenerateLengthErrorMessage(nameof(EditUserCommand.EditUserInputDto.Position)))
                .WithErrorCode("422");
            
            RuleFor(x => x.EditUserInputDto.CompanyName)
                .MaximumLength(64)
                .WithMessage(GenerateLengthErrorMessage(nameof(EditUserCommand.EditUserInputDto.CompanyName)))
                .WithErrorCode("422");
            
            RuleFor(x => x.EditUserInputDto.ManagerFullName)
                .MaximumLength(64)
                .WithMessage(GenerateLengthErrorMessage(nameof(EditUserCommand.EditUserInputDto.ManagerFullName)))
                .WithErrorCode("422");
        }

        private string GenerateLengthErrorMessage(string propertyName, int maxLength = MaxLength)
        {
            return string.Format(LengthValidationMessage, propertyName, maxLength);
        }
    }
}