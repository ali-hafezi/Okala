using MediatR;
using Okala.Application.Queries.Users;
using Okala.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okala.Application.Queries.Cryptoes;

public class GetCryptoQueryHandler : 
    IRequestHandler<GetCryptoQuery, GetCryptoDto>,
    IRequestHandler<GetCryptoByNameQuery, GetCryptoDto>
{
    private readonly ICryptoRepository cryptoRepository;
    public GetCryptoQueryHandler(ICryptoRepository cryptoRepository)
    {
        this.cryptoRepository = cryptoRepository;
    }

    public async Task<GetCryptoDto> Handle(GetCryptoQuery request, CancellationToken cancellationToken)
    {
        
       var result= await cryptoRepository.Get(request.Id, cancellationToken);
        GetCryptoDto getCryptoDto = new GetCryptoDto 
        { Id=result.Id , Symbol=result.Symbol,Price=result.PriceUSD,DateTime=result.DateTime };

        return getCryptoDto;
    }

    public async Task<GetCryptoDto> Handle(GetCryptoByNameQuery request, CancellationToken cancellationToken)
    {
        var result = await cryptoRepository.GetByName(request.Symbol, cancellationToken);
        GetCryptoDto getCryptoDto = new GetCryptoDto
        { Id = result.Id, Symbol = result.Symbol, Price = result.PriceUSD, DateTime = result.DateTime };

        return getCryptoDto;
    }
}
