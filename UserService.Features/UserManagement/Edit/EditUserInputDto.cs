namespace UserService.Features.UserManagement.Edit
{
    public class EditUserInputDto
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
    }
}