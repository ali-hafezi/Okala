namespace Okala.Application.Commands.Cryptoes.Response;

public class CoinMarketCapResponse
{
    public Coin[] Data { get; set; }
}

public class Coin
{
    public string Name { get; set; }
    public string Symbol { get; set; }
    public Quote Quote { get; set; }
}

public class Quote
{
    public USD USD { get; set; }
}

public class USD
{
    public decimal Price { get; set; }
}

public class ExchangeRatesResponse
{
    public Dictionary<string, decimal> Rates { get; set; }
}