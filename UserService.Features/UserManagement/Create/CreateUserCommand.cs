using MediatR;

namespace UserService.Features.UserManagement.Create
{
    public class CreateUserCommand : IRequest<Unit?>
    {
        public CreateUserCommand(object someProp)
        {
            SomeProp = someProp;
        }

        public object SomeProp { get; protected set; }
    }
}