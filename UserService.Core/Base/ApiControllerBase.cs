using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Core.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase: ControllerBase
    {
        protected readonly IMediator Mediator;

        public ApiControllerBase(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}