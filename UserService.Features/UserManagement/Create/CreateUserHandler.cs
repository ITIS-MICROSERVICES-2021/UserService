using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Core.Base.Handler;
using UserService.Core.Entities;

namespace UserService.Features.UserManagement.Create
{
    [UsedImplicitly]
    public class CreateUserHandler : HandlerBase<CreateUserCommand, User>
    {
        public CreateUserHandler(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            (
                request.CreateUserInputDto.Surname,
                request.CreateUserInputDto.Name,
                request.CreateUserInputDto.Patronymic,
                request.CreateUserInputDto.Post,
                request.CreateUserInputDto.ManagerFullName,
                request.CreateUserInputDto.CompanyFullName
            );
            
            var userEntry = DbContext.Set<User>().Add(user);
            await DbContext.SaveChangesAsync(cancellationToken);
            return userEntry.Entity;
        }
    }
}