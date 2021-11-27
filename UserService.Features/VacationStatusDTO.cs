using System;

namespace UserService.Features
{
    public class VacationStatusDTO
    {
        public int VacationDays { get; set; }
        public UserDTO[] Colleagues { get; set; }
    }
}