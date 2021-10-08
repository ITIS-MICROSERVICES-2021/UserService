using NUnit.Framework;
using UserService.Features.UserManagement.Create;

namespace UserService.Test.Unit
{
    [TestFixture]
    public class CreateUserTest
    {
        private CreateUserValidator Validator { get; set; }
        
        [SetUp]
        public void Setup()
        {
            Validator = new CreateUserValidator();
        }
        
        [Test]
        public void ValidationFailsIfSurnameIsNull()
        {
            var dto = new CreateUserInputDto
            {
                Name = "Name",
                Patronymic = "Patronymic",
                Position = "Position",
                ManagerFullName = "ManagerFullName",
                CompanyName = "CompanyName"
            };
            CheckWhetherIsPropertyCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfNameIsNull()
        {
            var dto = new CreateUserInputDto
            {
                Surname = "Surname",
                Patronymic = "Patronymic",
                Position = "Position",
                ManagerFullName = "ManagerFullName",
                CompanyName = "CompanyName"
            };
            CheckWhetherIsPropertyCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfPatronymicIsNull()
        {
            var dto = new CreateUserInputDto
            {
                Name = "Name",
                Surname = "Surname",
                Position = "Position",
                ManagerFullName = "ManagerFullName",
                CompanyName = "CompanyName"
            };
            CheckWhetherIsPropertyCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfPositionIsNull()
        {
            var dto = new CreateUserInputDto
            {
                Name = "Name",
                Surname = "Surname",
                Patronymic = "Patronymic",
                ManagerFullName = "ManagerFullName",
                CompanyName = "CompanyName"
            };
            CheckWhetherIsPropertyCorrect(dto);;
        }
        
        [Test]
        public void ValidationFailsIfManagerFullNameIsNull()
        {
            var dto = new CreateUserInputDto
            {
                Name = "Name",
                Surname = "Surname",
                Patronymic = "Patronymic",
                Position = "Position",
                CompanyName = "CompanyName"
            };
            CheckWhetherIsPropertyCorrect(dto);
        }
        
        [Test]
        public void ValidationFailsIfCompanyNameIsNull()
        {
            var dto = new CreateUserInputDto
            {
                Name = "Name",
                Surname = "Surname",
                Patronymic = "Patronymic",
                Position = "Position",
                ManagerFullName = "ManagerFullName"
            };
            CheckWhetherIsPropertyCorrect(dto);
        }

        private void CheckWhetherIsPropertyCorrect(CreateUserInputDto dto)
        {
            var command = new CreateUserCommand(dto);
            var result = Validator.Validate(command);
            Assert.False(result.IsValid);
        }
    }
}