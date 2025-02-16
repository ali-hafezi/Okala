using Okala.Domain.Common;

namespace Okala.Domain.Entities;

public class Crypto:BaseEntity
{
    public string Name {  get; set; }
    public string Symbol {  get; set; }
    public double PriceUSD { get; set; }
    public double? PriceEUR { get; set; }
    public double? PriceBRL { get; set; }
    public double? PriceGBP { get; set; }
    public double? PriceAUD { get; set; }
    public DateTime DateTime { get; set; }
}
