
using MediatR;

namespace Okala.Application.Commands.Users;

public class CreateUserCommand : IRequest<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

}
