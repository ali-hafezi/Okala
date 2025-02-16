namespace Okala.Application.Queries.Cryptoes;

public record GetCryptoDto
{
    public long Id { get; set; }
    public string Symbol { get; set; }
    public double Price { get; set; }
    public DateTime DateTime { get; set; }

}
