using System;
using Microsoft.AspNetCore.Identity;

namespace UserService.Core.Entities
{
    public class User : IdentityUser<long>
    {
        protected User()
        {
        }

        public User(string surname, string name, string patronymic, string position, string managerFullName,
            string companyFullName, long salary, DateTime recruitmentDate)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Position = position;
            ManagerFullName = managerFullName;
            CompanyFullName = companyFullName;
            Salary = salary;
            RecruitmentDate = recruitmentDate;
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

        /// <summary>
        /// Заработная плата
        /// </summary>
        public long Salary { get; protected set; }

        /// <summary>
        /// Дата приема работу
        /// </summary>
        public DateTime RecruitmentDate { get; protected set; }

        #region EditProperties

        public void ChangeSurname(string surname)
        {
            Surname = surname;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangePatronymic(string patronymic)
        {
            Patronymic = patronymic;
        }

        public void ChangePosition(string position)
        {
            Position = position;
        }

        public void ChangeManager(string manager)
        {
            ManagerFullName = manager;
        }

        public void ChangeCompanyName(string companyName)
        {
            CompanyFullName = companyName;
        }

        public void ChangeSalary(long salary)
        {
            Salary = salary;
        }

        public void ChangeRecruitmentDate(DateTime recruitmentDate)
        {
            RecruitmentDate = recruitmentDate;
        }

        #endregion
    }
}
