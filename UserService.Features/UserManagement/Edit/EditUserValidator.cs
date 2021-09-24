using FluentValidation;

namespace UserService.Features.UserManagement.Edit
{
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.EditUserInputDto.Name).MaximumLength(64)
                .WithMessage(nameof(EditUserCommand.EditUserInputDto.Name) + " was longer than 64 symbols")
                .WithErrorCode("422");
            
            RuleFor(x => x.EditUserInputDto.Surname).MaximumLength(64)
                .WithMessage(nameof(EditUserCommand.EditUserInputDto.Surname) + " was longer than 64 symbols")
                .WithErrorCode("422");
            
            RuleFor(x => x.EditUserInputDto.Patronymic).MaximumLength(64)
                .WithMessage(nameof(EditUserCommand.EditUserInputDto.Patronymic) + " was longer than 64 symbols")
                .WithErrorCode("422");
            
            RuleFor(x => x.EditUserInputDto.Position).MaximumLength(64)
                .WithMessage(nameof(EditUserCommand.EditUserInputDto.Position) + " was longer than 64 symbols")
                .WithErrorCode("422");
            
            RuleFor(x => x.EditUserInputDto.CompanyName).MaximumLength(64)
                .WithMessage(nameof(EditUserCommand.EditUserInputDto.CompanyName) + " was longer than 64 symbols")
                .WithErrorCode("422");
            
            RuleFor(x => x.EditUserInputDto.ManagerFullName).MaximumLength(64)
                .WithMessage(nameof(EditUserCommand.EditUserInputDto.ManagerFullName) + " was longer than 64 symbols")
                .WithErrorCode("422");
        }
    }
}