using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserService.Core.Base.Handler;
using UserService.Core.Entities;

namespace UserService.Features.UserManagement.Edit
{
    public class EditUserHandler : HandlerBase<EditUserCommand, User>
    {
        public EditUserHandler(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<User> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            ChangeSurname(request.EditUserInputDto.Surname, request.User);
            ChangeName(request.EditUserInputDto.Name, request.User);
            ChangeManager(request.EditUserInputDto.ManagerFullName, request.User);
            ChangePosition(request.EditUserInputDto.Position, request.User);

            await DbContext.SaveChangesAsync(cancellationToken);
            return request.User;
        }

        private void ChangeSurname(string surname, User user)
        {
            if (!string.IsNullOrEmpty(surname))
            {
                user.ChangeSurname(surname);
            }
        }

        private void ChangeName(string name, User user)
        {
            if (!string.IsNullOrEmpty(name))
            {
                user.ChangeName(name);
            }
        }

        private void ChangeManager(string manager, User user)
        {
            if (!string.IsNullOrEmpty(manager))
            {
                user.ChangeManager(manager);
            }
        }

        private void ChangePosition(string position, User user)
        {
            if (!string.IsNullOrEmpty(position))
            {
                user.ChangePosition(position);
            }
        }
    }
}