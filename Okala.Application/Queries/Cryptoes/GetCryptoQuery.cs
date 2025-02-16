using MediatR;

namespace Okala.Application.Queries.Cryptoes;
public record GetCryptoQuery(long Id) : IRequest<GetCryptoDto>;
