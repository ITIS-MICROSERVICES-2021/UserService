using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using UserService.Core.Entities;
using UserService.Data;
using UserService.Features.UserManagement.Create;
using UserService.Features.UserManagement.Edit;

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

        private DbContextMock<UserServiceDbContext> Mock { get; set; }

        private CreateUserHandler Handler { get; set; }

        private EditUserHandler EditHandler { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock = new DbContextMock<UserServiceDbContext>(new DbContextOptions<UserServiceDbContext>());
            Mock.CreateDbSetMock(context => context.Users, new List<User>());
            Handler = new CreateUserHandler(Mock.Object, null);
        }

        [Test]
        public async Task EditSurname()
        {
            await AddUser();

            var user = Mock.Object.Users.FirstOrDefault();
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

            Assert.AreEqual(Mock.Object.Users.FirstOrDefault().Surname, NewUser.Surname);
        }

        [Test]
        public async Task EditName()
        {
            await AddUser();

            var user = Mock.Object.Users.FirstOrDefault();
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

            Assert.AreEqual(Mock.Object.Users.FirstOrDefault().Name, NewUser.Name);
        }

        [Test]
        public async Task EditPatronymic()
        {
            await AddUser();

            var user = Mock.Object.Users.FirstOrDefault();
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

            Assert.AreEqual(Mock.Object.Users.FirstOrDefault().Patronymic, NewUser.Patronymic);
        }

        [Test]
        public async Task EditPosition()
        {
            await AddUser();

            var user = Mock.Object.Users.FirstOrDefault();
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

            Assert.AreEqual(Mock.Object.Users.FirstOrDefault().Position, NewUser.Position);
        }

        [Test]
        public async Task EditManagerFullName()
        {
            await AddUser();

            var user = Mock.Object.Users.FirstOrDefault();
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

            Assert.AreEqual(Mock.Object.Users.FirstOrDefault().ManagerFullName, NewUser.ManagerFullName);
        }

        [Test]
        public async Task EditCompanyName()
        {
            await AddUser();

            var user = Mock.Object.Users.FirstOrDefault();
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

            Assert.AreEqual(Mock.Object.Users.FirstOrDefault().CompanyFullName, NewUser.CompanyFullName);
        }

        [Test]
        public async Task EditSalary()
        {
            await AddUser();

            var user = Mock.Object.Users.FirstOrDefault();
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

            Assert.AreEqual(Mock.Object.Users.FirstOrDefault().Salary, NewUser.Salary);
        }

        [Test]
        public async Task EditRecruitmentDate()
        {
            await AddUser();

            var user = Mock.Object.Users.FirstOrDefault();
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

            Assert.AreEqual(Mock.Object.Users.FirstOrDefault().RecruitmentDate, NewUser.RecruitmentDate);
        }

        private async Task EditUser(User user, EditUserInputDto EditDto)
        {
            EditHandler = new EditUserHandler(Mock.Object, null);

            var editCommand = new EditUserCommand(EditDto, user);
            await EditHandler.Handle(editCommand, default);
        }

        private async Task AddUser()
        {
            var command = new CreateUserCommand(Dto);
            await Handler.Handle(command, default);
        }
    }
}