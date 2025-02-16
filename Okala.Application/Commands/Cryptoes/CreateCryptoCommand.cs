using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okala.Application.Commands.Cryptoes;

public record CreateCryptoCommand: IRequest<long>
{
    public string Name { get; set; }
    public string Symbol { get; set; }
    public double PriceUSD { get; set; }
    public double? PriceEUR { get; set; }
    public double? PriceBRL { get; set; }
    public double? PriceGBP { get; set; }
    public double? PriceAUD { get; set; }

}
