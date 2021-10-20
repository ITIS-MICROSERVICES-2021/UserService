using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.Testing.Moq;
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
        
        private UserServiceDbContext MockedDbContext { get; set; }

        private CreateUserHandler Handler { get; set; }

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<UserServiceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            MockedDbContext = Create.MockedDbContextFor<UserServiceDbContext>(dbContextOptions);
            Handler = new CreateUserHandler(MockedDbContext, null);
        }

        [Test]
        public async Task HandlingAddsUserToTheDatabase()
        {
            var command = new CreateUserCommand(Dto);
            var userEntity = await Handler.Handle(command, default);
            Assert.NotNull(MockedDbContext.Users.FirstOrDefault(user => user.Id == userEntity.Id));
        }
    }
}