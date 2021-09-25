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