using MediatR;
using Microsoft.AspNetCore.Mvc;
using Okala.Application.Commands.Users;
using Okala.Application.Queries.Users;
using Okala.RestApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okala.RestApi.User.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetUserDto>> Get([FromQuery] GetUserQuery query)
    {
        var result= await Mediator.Send(query);
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<long>> Post(CreateUserCommand command)
    {
        var result=await Mediator.Send(command);
        return Ok(result);
    }

}
