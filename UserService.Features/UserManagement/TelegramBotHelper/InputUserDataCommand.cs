using MediatR;
using UserService.Core.Entities;

namespace UserService.Features.UserManagement.TelegramBotHelper
{
    public class InputUserDataCommand : IRequest<User>
    {
        public User User { get; set; }
        public InputUserDataDto InputUserDataDto { get; set; }
        
        public InputUserDataCommand(InputUserDataDto inputUserDataDto, User user)
        {
            InputUserDataDto = inputUserDataDto;
            User = user;
        }
    }
}