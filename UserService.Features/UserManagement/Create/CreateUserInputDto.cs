using System;
using UserService.Features.UserManagement.Base;

namespace UserService.Features.UserManagement.Create
{
    public class CreateUserInputDto : UserInputBase
    {
        /// <summary>
        /// Идентификатор пользователя в Telegram
        /// </summary>
        public Guid TelegramId { get; set; } //TODO: уточнить тип
    }
}