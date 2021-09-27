using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using UserService.Core.Base.Handler;
using UserService.Core.Entities;

namespace UserService.Features.UserManagement.Edit
{
    [UsedImplicitly]
    public class EditUserHandler : HandlerBase<EditUserCommand, User>
    {
        public EditUserHandler(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<User> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            ChangeProperty(request.EditUserInputDto.Name,
                newName => ValidateFunc(newName, request.User.Name),
                newName => request.User.ChangeName(newName));

            ChangeProperty(request.EditUserInputDto.Surname,
                newSurname => ValidateFunc(newSurname, request.User.Surname),
                newSurname => request.User.ChangePatronymic(newSurname));

            ChangeProperty(request.EditUserInputDto.Patronymic,
                newPatronymic => ValidateFunc(newPatronymic, request.User.Patronymic),
                newPatronymic => request.User.ChangeSurname(newPatronymic));

            ChangeProperty(request.EditUserInputDto.ManagerFullName,
                newManagerFullName => ValidateFunc(newManagerFullName, request.User.ManagerFullName),
                newManagerFullName => request.User.ChangeManager(newManagerFullName));

            ChangeProperty(request.EditUserInputDto.Position,
                newPosition => ValidateFunc(newPosition, request.User.Position),
                newPosition => request.User.ChangePosition(newPosition));

            ChangeProperty(request.EditUserInputDto.CompanyName,
                newCompanyName => ValidateFunc(newCompanyName, request.User.Position),
                newCompanyName => request.User.ChangeCompanyName(newCompanyName));

            ChangeProperty(request.EditUserInputDto.Salary,
                newSalary => newSalary != request.EditUserInputDto.Salary && newSalary > 0,
                newSalary => request.User.ChangeSalary(newSalary));

            ChangeProperty(request.EditUserInputDto.CompanyName,
                newCompanyName => ValidateFunc(newCompanyName, request.User.Position),
                newCompanyName => request.User.ChangePosition(newCompanyName));

            ChangeProperty(request.EditUserInputDto.RecruitmentDate,
                newRecruitmentDate => newRecruitmentDate <= DateTime.UtcNow.Date,
                newRecruitmentDate => request.User.ChangeRecruitmentDate(newRecruitmentDate));


            await DbContext.SaveChangesAsync(cancellationToken);
            return request.User;
        }

        private void ChangeProperty<T>(T newPropertyValue, Func<T, bool> validateFunc, Action<T> changingFunc)
        {
            if (validateFunc(newPropertyValue))
            {
                changingFunc(newPropertyValue);
            }
        }

        private bool ValidateFunc(string newValue, string oldValue)
        {
            return !string.IsNullOrEmpty(newValue) && newValue != oldValue;
        }
    }
}