using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserService.Core.Base.Handler;
using UserService.Core.Entities;

namespace UserService.Features.UserManagement.TelegramBotHelper
{
    public class InputUserDataHandler : HandlerBase<InputUserDataCommand, User>
    {
        public InputUserDataHandler(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<User> Handle(InputUserDataCommand request, CancellationToken cancellationToken)
        {
            InputSurname(request.User, request.InputUserDataDto.Surname);
            InputName(request.User, request.InputUserDataDto.Name);
            InputPatronymic(request.User, request.InputUserDataDto.Patronymic);
            InputManager(request.User, request.InputUserDataDto.ManagerFullName);
            InputPosition(request.User, request.InputUserDataDto.Post);
            InputCompanyFullname(request.User, request.InputUserDataDto.CompanyFullName);

            await DbContext.SaveChangesAsync(cancellationToken);
            return request.User;
        }

        private void InputSurname(User user, string surname)
        {
            if (!string.IsNullOrEmpty(surname) && user.Surname != surname)
            {
                user.ChangeSurname(surname);
            }
        }

        private void InputName(User user, string name)
        {
            if (!string.IsNullOrEmpty(name) && user.Name != name)
            {
                user.ChangeName(name);
            }
        }
        
        private void InputPatronymic(User user, string patronymic)
        {
            if (!string.IsNullOrEmpty(patronymic) && user.Patronymic != patronymic)
            {
                user.ChangePatronymic(patronymic);
            }
        }

        private void InputManager(User user, string manager)
        {
            if (!string.IsNullOrEmpty(manager) && user.ManagerFullName != manager)
            {
                user.ChangeManager(manager);
            }
        }

        private void InputPosition(User user, string position)
        {
            if (!string.IsNullOrEmpty(position) && user.Position != position)
            {
                user.ChangePosition(position);
            }
        }
        
        private void InputCompanyFullname(User user, string companyFullName)
        {
            if (!string.IsNullOrEmpty(companyFullName) && user.CompanyFullName != companyFullName)
            {
                user.ChangeCompanyName(companyFullName);
            }
        }
    }
}