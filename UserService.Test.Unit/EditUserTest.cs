using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using UserService.Core.Entities;
using UserService.Data;
using UserService.Features.UserManagement.Create;
using UserService.Features.UserManagement.Edit;
using EntityFrameworkCore.Testing.Moq;

namespace UserService.Test.Unit
{
    [TestFixture]
    public class EditUserTest
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

        private User NewUser = new("NewSurname", "NewName", "NewSurname", "Newposition", "NewmanagerFullName",
            "NewcompanyFullName", 123456, DateTime.UtcNow.Date);

        private CreateUserHandler Handler { get; set; }

        private EditUserHandler EditHandler { get; set; }

        private UserServiceDbContext MockedDbContext { get; set; }

        [SetUp]
        public void Setup()
        {

            var dbContextOptions = new DbContextOptionsBuilder<UserServiceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            MockedDbContext = Create.MockedDbContextFor<UserServiceDbContext>(dbContextOptions);
            Handler = new CreateUserHandler(MockedDbContext, null);
        }

        [Test]
        public async Task EditSurname()
        {
            var user = await AddUser();

            var EditDto = new EditUserInputDto()
            {
                Surname = NewUser.Surname,
                Name = nameof(CreateUserInputDto.Name),
                Patronymic = nameof(CreateUserInputDto.Patronymic),
                Position = nameof(CreateUserInputDto.Position),
                ManagerFullName = nameof(CreateUserInputDto.ManagerFullName),
                CompanyName = nameof(CreateUserInputDto.CompanyName),
                Salary = 15400,
                RecruitmentDate = DateTime.UtcNow.Date
            };

            await EditUser(user, EditDto);

            Assert.AreEqual(MockedDbContext.Users.FirstOrDefault().Surname, NewUser.Surname);
        }

        [Test]
        public async Task EditName()
        {
            var user = await AddUser();

            var EditDto = new EditUserInputDto()
            {
                Surname = nameof(CreateUserInputDto.Surname),
                Name = NewUser.Name,
                Patronymic = nameof(CreateUserInputDto.Patronymic),
                Position = nameof(CreateUserInputDto.Position),
                ManagerFullName = nameof(CreateUserInputDto.ManagerFullName),
                CompanyName = nameof(CreateUserInputDto.CompanyName),
                Salary = 15400,
                RecruitmentDate = DateTime.UtcNow.Date
            };

            await EditUser(user, EditDto);

            Assert.AreEqual(MockedDbContext.Users.FirstOrDefault().Name, NewUser.Name);
        }

        [Test]
        public async Task EditPatronymic()
        {
            var user = await AddUser();

            var EditDto = new EditUserInputDto()
            {
                Surname = nameof(CreateUserInputDto.Surname),
                Name = nameof(CreateUserInputDto.Name),
                Patronymic = NewUser.Patronymic,
                Position = nameof(CreateUserInputDto.Position),
                ManagerFullName = nameof(CreateUserInputDto.ManagerFullName),
                CompanyName = nameof(CreateUserInputDto.CompanyName),
                Salary = 15400,
                RecruitmentDate = DateTime.UtcNow.Date
            };

            await EditUser(user, EditDto);

            Assert.AreEqual(MockedDbContext.Users.FirstOrDefault().Patronymic, NewUser.Patronymic);
        }

        [Test]
        public async Task EditPosition()
        {
            var user = await AddUser();

            var EditDto = new EditUserInputDto()
            {
                Surname = nameof(CreateUserInputDto.Surname),
                Name = nameof(CreateUserInputDto.Name),
                Patronymic = nameof(CreateUserInputDto.Patronymic),
                Position = NewUser.Position,
                ManagerFullName = nameof(CreateUserInputDto.ManagerFullName),
                CompanyName = nameof(CreateUserInputDto.CompanyName),
                Salary = 15400,
                RecruitmentDate = DateTime.UtcNow.Date
            };

            await EditUser(user, EditDto);

            Assert.AreEqual(MockedDbContext.Users.FirstOrDefault().Position, NewUser.Position);
        }

        [Test]
        public async Task EditManagerFullName()
        {
            var user = await AddUser();

            var EditDto = new EditUserInputDto()
            {
                Surname = nameof(CreateUserInputDto.Surname),
                Name = nameof(CreateUserInputDto.Name),
                Patronymic = nameof(CreateUserInputDto.Patronymic),
                Position = nameof(CreateUserInputDto.Position),
                ManagerFullName = NewUser.ManagerFullName,
                CompanyName = nameof(CreateUserInputDto.CompanyName),
                Salary = 15400,
                RecruitmentDate = DateTime.UtcNow.Date
            };

            await EditUser(user, EditDto);

            Assert.AreEqual(MockedDbContext.Users.FirstOrDefault().ManagerFullName, NewUser.ManagerFullName);
        }

        [Test]
        public async Task EditCompanyName()
        {
            var user = await AddUser();

            var EditDto = new EditUserInputDto()
            {
                Surname = nameof(CreateUserInputDto.Surname),
                Name = nameof(CreateUserInputDto.Name),
                Patronymic = nameof(CreateUserInputDto.Patronymic),
                Position = nameof(CreateUserInputDto.Position),
                ManagerFullName = nameof(CreateUserInputDto.ManagerFullName),
                CompanyName = NewUser.CompanyFullName,
                Salary = 15400,
                RecruitmentDate = DateTime.UtcNow.Date
            };

            await EditUser(user, EditDto);

            Assert.AreEqual(MockedDbContext.Users.FirstOrDefault().CompanyFullName, NewUser.CompanyFullName);
        }

        [Test]
        public async Task EditSalary()
        {
            var user = await AddUser();

            var EditDto = new EditUserInputDto()
            {
                Surname = nameof(CreateUserInputDto.Surname),
                Name = nameof(CreateUserInputDto.Name),
                Patronymic = nameof(CreateUserInputDto.Patronymic),
                Position = nameof(CreateUserInputDto.Position),
                ManagerFullName = nameof(CreateUserInputDto.ManagerFullName),
                CompanyName = nameof(CreateUserInputDto.CompanyName),
                Salary = NewUser.Salary,
                RecruitmentDate = DateTime.UtcNow.Date
            };

            await EditUser(user, EditDto);

            Assert.AreEqual(MockedDbContext.Users.FirstOrDefault().Salary, NewUser.Salary);
        }

        [Test]
        public async Task EditRecruitmentDate()
        {
            var user = await AddUser();

            var EditDto = new EditUserInputDto()
            {
                Surname = nameof(CreateUserInputDto.Surname),
                Name = nameof(CreateUserInputDto.Name),
                Patronymic = nameof(CreateUserInputDto.Patronymic),
                Position = nameof(CreateUserInputDto.Position),
                ManagerFullName = nameof(CreateUserInputDto.ManagerFullName),
                CompanyName = nameof(CreateUserInputDto.CompanyName),
                Salary = 15400,
                RecruitmentDate = NewUser.RecruitmentDate
            };

            await EditUser(user, EditDto);

            Assert.AreEqual(MockedDbContext.Users.FirstOrDefault().RecruitmentDate, NewUser.RecruitmentDate);
        }

        private async Task EditUser(User user, EditUserInputDto EditDto)
        {
            EditHandler = new EditUserHandler(MockedDbContext, null);

            var editCommand = new EditUserCommand(EditDto, user);
            await EditHandler.Handle(editCommand, default);
        }

        private async Task<User> AddUser()
        {
            var command = new CreateUserCommand(Dto);
            await Handler.Handle(command, default);

            var userEntity = await Handler.Handle(command, default);

            return MockedDbContext.Users.FirstOrDefault(user => user.Id == userEntity.Id);
        }
    }
}