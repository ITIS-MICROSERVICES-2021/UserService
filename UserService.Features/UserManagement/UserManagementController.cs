using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Core.Base;
using UserService.Core.Entities;
using UserService.Features.UserManagement.Create;
using UserService.Features.UserManagement.Edit;

namespace UserService.Features.UserManagement
{
    public class UserManagementController : ApiControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserManagementController(IMediator mediator, UserManager<User> userManager) : base(mediator)
        {
            _userManager = userManager;
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(new UserDTO
            {
                Id = Guid.Parse("9d0b0de0-2c46-40ee-a21f-eab63b2b7a31"),
                UserRoles = new [] { UserRole.Employee },
                DepartmentId = Guid.Parse("d073367e-4044-465b-ba39-ba594d409ead"),
                BossId = Guid.Parse("7635c212-ded4-46f6-8294-2ec2dffea72e"),
                FirstName = "Иван",
                LastName = "Иванов",
                Patronymic = "Иванович"
            });
        }

        [HttpGet, Route("{id}/status")]
        public IActionResult GetVacationStatusById(string id)
        {
            return Ok(new VacationStatusDTO
            {
                VacationDays = 28,
                Colleagues = new []{new UserDTO
                {
                    Id = Guid.Parse("1e609245-c1ee-4eb5-a162-047e97c00478"),
                    UserRoles = new [] { UserRole.Employee },
                    DepartmentId = Guid.Parse("fc52fe22-97d0-45a6-a7dd-458a7873837b"),
                    BossId = Guid.Parse("7d83828c-b66d-4d4e-a7eb-5ce09e582520"),
                    FirstName = "Петр",
                    LastName = "Петров",
                    Patronymic = "Петрович"
                }}
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserInputDto input)
        {
            var command = new CreateUserCommand(input);
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditUserInputDto input)
        {
            var user = await _userManager.GetUserAsync(User);
            var command = new EditUserCommand(input, user);
            return Ok(await Mediator.Send(command));
        }
    }
}