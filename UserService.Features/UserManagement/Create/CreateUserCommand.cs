using MediatR;
using UserService.Core.Entities;

namespace UserService.Features.UserManagement.Create
{
    public class CreateUserCommand : IRequest<User>
    {
        public User User { get; set; }
        public CreateUserInputDto CreateUserInputDto { get; set; }
        
        public CreateUserCommand(CreateUserInputDto createUserInput)
        {
            CreateUserInputDto = createUserInput;
        }
    }
}