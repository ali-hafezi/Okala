using MediatR;

namespace Okala.Application.Queries.Users;

public record GetUserQuery(long Id) : IRequest<GetUserDto>;