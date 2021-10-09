using System;
using System.Linq;
using NUnit.Framework;
using UserService.Features.UserManagement.Create;

namespace UserService.Test.Unit
{
    [TestFixture]
    public class CreateUserTest
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
        public void ValidationFailsIfSurnameIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.Surname), null);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfSurnameLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Surname), IncorrectValue);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfNameIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.Name), null);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfNameLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Name), IncorrectValue);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfPatronymicIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.Patronymic), null);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfPatronymicLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Patronymic), IncorrectValue);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfPositionIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.Position), null);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfPositionLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Position), IncorrectValue);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfManagerFullNameIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.ManagerFullName), null);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfManagerFullNameLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.ManagerFullName), IncorrectValue);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfCompanyNameIsNull()
        {
            var dto = GenerateWrongDto<string>(nameof(CreateUserInputDto.CompanyName), null);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfCompanyNameLengthGreaterThanSixtyFour()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.CompanyName), IncorrectValue);
            CheckIfPropertyIsCorrect(dto);
        }

        [Test]
        public void ValidationFailsIfSalaryEqualToZero()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Salary), 0);
            CheckIfPropertyIsCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfSalaryLessThanZero()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Salary), -15400);
            CheckIfPropertyIsCorrect(dto);
        }

        [Test]
        public void ValidationFailsIfRecruitmentDateGreaterThanNow()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.RecruitmentDate), DateTime.UtcNow.Date.AddMonths(1));
            CheckIfPropertyIsCorrect(dto);
        }

        [Test]
        public void ValidationFailsIfTelegramIdIsEmpty()
        {
            var dto = GenerateWrongDto(nameof(CreateUserInputDto.Salary), Guid.Empty);
            CheckIfPropertyIsCorrect(dto);
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

        private void CheckIfPropertyIsCorrect(CreateUserInputDto dto)
        {
            var command = new CreateUserCommand(dto);
            var result = Validator.Validate(command);
            Assert.False(result.IsValid);
        }
    }
}