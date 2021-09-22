using Microsoft.AspNetCore.Identity;

namespace UserService.Core.Entities
{
    public class User : IdentityUser<long>
    {
        protected User()
        {
        }
        
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
        /// Должность
        /// </summary>
        public string Position { get; protected set; }
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