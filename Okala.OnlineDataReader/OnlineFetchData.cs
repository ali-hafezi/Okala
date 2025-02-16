using Okala.Application.Commands.Cryptoes;
using Okala.Application.Commands.Cryptoes.Response;
using System.Text.Json;

namespace Okala.OnlineDataReader;

public class OnlineFetchData : IFetchData
{
    public async Task<List<CreateCryptoCommand>> GetDataOnline()
    {
        string coinMarketCapApiKey = "1b3afbc4-b9ec-4e06-9350-040179acfd97";
        string exchangeRatesApiKey = "95ebbb6930f4bd2e024b9710057f9df2";

        string cryptoApiUrl = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";
        string forexApiUrl = $"https://api.exchangeratesapi.io/v1/latest?access_key={exchangeRatesApiKey}&symbols=USD,EUR,BRL,GBP,AUD";

        List<CreateCryptoCommand> cryptoes = new List<CreateCryptoCommand>();

        using (HttpClient client = new HttpClient())
        {

            // Fetch cryptocurrency data
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", coinMarketCapApiKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage cryptoResponse = await client.GetAsync(cryptoApiUrl);
            cryptoResponse.EnsureSuccessStatusCode();
            string cryptoResponseBody = await cryptoResponse.Content.ReadAsStringAsync();

            CoinMarketCapResponse cryptoData = JsonSerializer.Deserialize<CoinMarketCapResponse>(cryptoResponseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Fetch exchange rates data
            HttpResponseMessage forexResponse = await client.GetAsync(forexApiUrl);
            forexResponse.EnsureSuccessStatusCode();
            string forexResponseBody = await forexResponse.Content.ReadAsStringAsync();

            ExchangeRatesResponse forexData = JsonSerializer.Deserialize<ExchangeRatesResponse>(forexResponseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            foreach (var coin in cryptoData.Data)
            {
                decimal usdPrice = coin.Quote.USD.Price;


                cryptoes.Add(new CreateCryptoCommand
                {
                    Name = coin.Name,
                    Symbol = coin.Symbol,
                    PriceUSD = (double)coin.Quote.USD.Price,
                    PriceAUD = (double)(usdPrice * forexData.Rates["AUD"]),
                    PriceBRL = (double)(usdPrice * forexData.Rates["BRL"]),
                    PriceEUR = (double)(usdPrice * forexData.Rates["EUR"]),
                    PriceGBP = (double)(usdPrice * forexData.Rates["GBP"]),

                });
            }

            return cryptoes;
        }
    }
}
