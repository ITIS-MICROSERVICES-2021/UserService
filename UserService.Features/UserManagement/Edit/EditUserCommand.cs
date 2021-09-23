using MediatR;
using UserService.Core.Entities;

namespace UserService.Features.UserManagement.Edit
{
    public class EditUserCommand : IRequest<User>
    {
        public User User { get; set; }
        public EditUserInputDto EditUserInputDto { get; set; }
        public EditUserCommand(EditUserInputDto editUserInputDto, User user)
        {
            EditUserInputDto = editUserInputDto;
            User = user;
        }
    }
}