using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Core.Base;
using UserService.Core.Entities;
using UserService.Features.UserManagement.Create;
using UserService.Features.UserManagement.Edit;
using UserService.Features.UserManagement.TelegramBotHelper;

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

        [Authorize]
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(EditUserInputDto input)
        {
            var user = await _userManager.GetUserAsync(User);
            var command = new EditUserCommand(input, user);
            return Ok(await Mediator.Send(command));
        }
        
        [Authorize]
        [HttpPost("inputuserdata")]
        public async Task<IActionResult> Edit(InputUserDataDto input)
        {
            var user = await _userManager.GetUserAsync(User);
            var command = new InputUserDataCommand(input, user);
            return Ok(await Mediator.Send(command));
        }
    }
}