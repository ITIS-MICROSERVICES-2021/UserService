using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Core.Base.Handler;

namespace UserService.Features.UserManagement.Create
{
    [UsedImplicitly]
    public class CreateUserHandler : HandlerBase<CreateUserCommand, Unit?>
    {
        public CreateUserHandler(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override Task<Unit?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}