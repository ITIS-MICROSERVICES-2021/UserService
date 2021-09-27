using MediatR;
using UserService.Core.Entities;

namespace UserService.Features.UserManagement.Create
{
    public class CreateUserCommand : IRequest<User>
    {
        public CreateUserInputDto CreateUserInputDto { get; }
        
        public CreateUserCommand(CreateUserInputDto createUserInput)
        {
            CreateUserInputDto = createUserInput;
        }
    }
}