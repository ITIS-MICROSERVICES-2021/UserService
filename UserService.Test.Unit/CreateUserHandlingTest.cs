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

namespace UserService.Test.Unit
{
    [TestFixture]
    public class CreateUserHandlingTest
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
        
        private DbContextMock<UserServiceDbContext> Mock { get; set; }

        private CreateUserHandler Handler { get; set; }
        
        [SetUp]
        public void Setup()
        {
            Mock = new DbContextMock<UserServiceDbContext>(new DbContextOptions<UserServiceDbContext>());
            Mock.CreateDbSetMock(context => context.Users, new List<User>());
            Handler = new CreateUserHandler(Mock.Object, null);
        }

        [Test]
        public async Task HandlingAddsUserToTheDatabase()
        {
            var command = new CreateUserCommand(Dto);
            await Handler.Handle(command, default);
            Assert.NotNull(Mock.Object.Users.FirstOrDefault());
        }
    }
}