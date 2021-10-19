using System;
using System.Linq;
using NUnit.Framework;
using UserService.Features.UserManagement.Create;

namespace UserService.Test.Unit
{
    [TestFixture]
    public class CreateUserValidationTest
    {
        private static CreateUserInputDto Dto => new()
        {
            Surname = nameof(CreateUserInputDto.Surname),
            Name = nameof(CreateUserInputDto.Name),
            Patronymic = nameof(CreateUserInputDto.Patronymic),
            Position = nameof(CreateUserInputDto.Position),
            ManagerFullName = nameof(CreateUserInputDto.ManagerFullName),
            CompanyName = nameof(CreateUserInputDto.CompanyName),
            Salary = 15400,
            RecruitmentDate = DateTime.UtcNow.Date,
            TelegramId = Guid.NewGuid()
        };
        
        private string IncorrectValue { get; set; }
        
        private CreateUserValidator Validator { get; set; }
        
        [SetUp]
        public void Setup()
        {
            Validator = new CreateUserValidator();
            IncorrectValue = new string(Enumerable.Repeat('a', 65).ToArray());
        }

        [Test]
        public void ValidationFailsIfDtoIsNull()
        {
            CheckWhetherValidationFails(null, true);
        }
        
        [Test]
        public void ValidationFailsIfSurnameIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.Surname), null);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfSurnameLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Surname), IncorrectValue);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfNameIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.Name), null);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfNameLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Name), IncorrectValue);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfPatronymicIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.Patronymic), null);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfPatronymicLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Patronymic), IncorrectValue);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfPositionIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.Position), null);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfPositionLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Position), IncorrectValue);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfManagerFullNameIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.ManagerFullName), null);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfManagerFullNameLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.ManagerFullName), IncorrectValue);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfCompanyNameIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.CompanyName), null);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfCompanyNameLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.CompanyName), IncorrectValue);
            CheckWhetherValidationFails(dto, true);
        }

        [Test]
        public void ValidationFailsIfSalaryEqualToZero()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Salary), 0);
            CheckWhetherValidationFails(dto, true);
        }
        
        [Test]
        public void ValidationFailsIfSalaryLessThanZero()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Salary), -15400);
            CheckWhetherValidationFails(dto, true);
        }

        [Test]
        public void ValidationFailsIfRecruitmentDateGreaterThanNow()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.RecruitmentDate), DateTime.UtcNow.Date.AddMonths(1));
            CheckWhetherValidationFails(dto, true);
        }

        [Test]
        public void ValidationFailsIfTelegramIdIsEmpty()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.TelegramId), Guid.Empty);
            CheckWhetherValidationFails(dto, true);
        }

        [Test]
        public void ValidationDoesNotFailIfDtoIsCorrect()
        {
            CheckWhetherValidationFails(Dto, false);
        }

        private static CreateUserInputDto GenerateWrongDto<T>(string incorrectPropertyName, T incorrectValue)
        {
            var dto = Dto;
            switch (incorrectPropertyName)
            {
                case nameof(CreateUserInputDto.Surname):
                    dto.Surname = incorrectValue as string;
                    break;
                case nameof(CreateUserInputDto.Name):
                    dto.Name = incorrectValue as string;
                    break;
                case nameof(CreateUserInputDto.Patronymic):
                    dto.Patronymic = incorrectValue as string;
                    break;
                case nameof(CreateUserInputDto.Position):
                    dto.Position = incorrectValue as string;
                    break;
                case nameof(CreateUserInputDto.ManagerFullName):
                    dto.ManagerFullName = incorrectValue as string;
                    break;
                case nameof(CreateUserInputDto.CompanyName):
                    dto.CompanyName = incorrectValue as string;
                    break;
                case nameof(CreateUserInputDto.Salary):
                    dto.Salary = Convert.ToInt64(incorrectValue);
                    break;
                case nameof(CreateUserInputDto.RecruitmentDate):
                    dto.RecruitmentDate = Convert.ToDateTime(incorrectValue);
                    break;
                case nameof(CreateUserInputDto.TelegramId):
                    dto.TelegramId = (Guid)(incorrectValue as object);
                    break;
                default:
                    throw new ArgumentException("Parameter incorrectPropertyName isn't right");
            }

            return dto;
        }

        private void CheckWhetherValidationFails(CreateUserInputDto dto, bool condition)
        {
            var command = new CreateUserCommand(dto);
            var result = Validator.Validate(command);
            if (condition)
                Assert.False(result.IsValid);
            else
                Assert.True(result.IsValid);
        }
    }
}