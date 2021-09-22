using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Core.Base;
using UserService.Features.UserManagement.Create;

namespace UserService.Features.UserManagement
{
    public class UserManagementController : ApiControllerBase
    {
        public UserManagementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserInputDto input)
        {
            var command = new CreateUserCommand(input);
            return Ok(await Mediator.Send(command));
        }
    }
}