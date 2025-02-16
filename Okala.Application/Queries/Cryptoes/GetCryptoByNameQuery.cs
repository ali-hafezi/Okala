using MediatR;

namespace Okala.Application.Queries.Cryptoes;
public record GetCryptoByNameQuery(string Symbol) : IRequest<GetCryptoDto>;
