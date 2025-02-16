using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okala.Application.Queries.Users;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserDto>
{
    public Task<GetUserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        GetUserDto getUserDto = new GetUserDto(2, "sadsad");

        return Task.FromResult(getUserDto);
    }
}
