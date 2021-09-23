using Microsoft.AspNetCore.Identity;

namespace UserService.Core.Entities
{
    public class User : IdentityUser<long>
    {
        protected User()
        {
        }

        public User(string surname, string name, string patronymic, string position, string managerFullName,
            string companyFullName)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Position = position;
            ManagerFullName = managerFullName;
            CompanyFullName = companyFullName;
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

        public void ChangeSurname(string surname)
        {
            Surname = surname;
        }
        
        public void ChangeName(string name)
        {
            Name = name;
        }
        
        public void ChangePosition(string position)
        {
            Position = position;
        }
        
        public void ChangeManager(string manager)
        {
            ManagerFullName = manager;
        }
    }
}