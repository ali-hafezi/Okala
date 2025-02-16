using MediatR;
using Okala.Domain.Entities;

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
        {
            Id = result.Id,
            Symbol = result.Symbol,
            PriceUSD = result.PriceUSD,
            PriceAUD = result.PriceAUD ?? 0,
            PriceBRL = result.PriceBRL ?? 0,
            PriceEUR = result.PriceEUR ?? 0,
            PriceGBP = result.PriceGBP ?? 0,
            DateTime = result.DateTime
        };

        return getCryptoDto;
    }

    public async Task<GetCryptoDto> Handle(GetCryptoByNameQuery request, CancellationToken cancellationToken)
    {
        var result = await cryptoRepository.GetByName(request.Symbol, cancellationToken);
        GetCryptoDto getCryptoDto = new GetCryptoDto
        {
            Id = result.Id,
            Symbol = result.Symbol,
            PriceUSD = result.PriceUSD,
            PriceAUD = result.PriceAUD ?? 0,
            PriceBRL = result.PriceBRL ?? 0,
            PriceEUR = result.PriceEUR ?? 0,
            PriceGBP = result.PriceGBP ?? 0,
            DateTime = result.DateTime
        };

        return getCryptoDto;
    }
}
