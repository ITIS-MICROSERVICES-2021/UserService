namespace UserService.Features.UserManagement.TelegramBotHelper
{
    /// <summary>
    /// Dto для ввода пользовательских данных при первом взаимодействии с Telegram-ботом
    /// </summary>
    public class InputUserDataDto
    {
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