using MediatR;
using Okala.Application.Commands.Users;
using Okala.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okala.Application.Commands.Cryptoes;

public class CreateCryptoCommandHandler : IRequestHandler<CreateCryptoCommand,long>
{
    private readonly ICryptoRepository cryptoRepository;
    public CreateCryptoCommandHandler(ICryptoRepository cryptoRepository)
    {
        this.cryptoRepository = cryptoRepository;
    }

    public async Task<long> Handle(CreateCryptoCommand request, CancellationToken cancellationToken)
    {
        Crypto crypto = new Crypto
        {
            Name = request.Name,
            Symbol = request.Symbol,
            PriceUSD = request.PriceUSD,
            PriceGBP = request.PriceGBP,
            PriceEUR = request.PriceEUR,
            PriceAUD = request.PriceAUD,
            PriceBRL = request.PriceBRL,
            DateTime = DateTime.Now
            
        };
        
        await cryptoRepository.Add(crypto, cancellationToken);
        return cryptoRepository.SaveChanges();
    }
}
