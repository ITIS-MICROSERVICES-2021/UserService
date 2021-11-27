using System;

namespace UserService.Features
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public UserRole[] UserRoles { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid BossId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
    }
}