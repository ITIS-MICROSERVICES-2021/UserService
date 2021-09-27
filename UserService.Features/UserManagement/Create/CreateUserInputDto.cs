using System;

namespace UserService.Features.UserManagement.Create
{
    public class CreateUserInputDto
    {
        /// <summary>
        /// Идентификатор пользователя в Telegram
        /// </summary>
        public Guid TelegramId { get; set; } //TODO: уточнить тип
        
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; protected set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; protected set; }
        
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; protected set; }
        
        /// <summary>
        /// Должность в компании
        /// </summary>
        public string Post { get; protected set; }
        
        /// <summary>
        /// ФИО генерального директора
        /// </summary>
        public string ManagerFullName { get; protected set; }
        
        /// <summary>
        /// Полное наименование компании
        /// </summary>
        public string CompanyFullName { get; protected set; }
    }
}