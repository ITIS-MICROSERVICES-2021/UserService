using System;

namespace UserService.Features.UserManagement.Base
{
    public abstract class UserInputBase
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// ФИО генерального директора
        /// </summary>
        public string ManagerFullName { get; set; }

        /// <summary>
        /// Полное наименование компании
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Заработная плата
        /// </summary>
        public long Salary { get; set; }

        /// <summary>
        /// Дата приема работу
        /// </summary>
        public DateTime RecruitmentDate { get; set; }
    }
}