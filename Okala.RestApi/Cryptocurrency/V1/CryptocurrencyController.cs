using Microsoft.AspNetCore.Mvc;
using Okala.Application.Commands.Cryptoes;
using Okala.Application.Queries.Cryptoes;
using Okala.OnlineDataReader;
using Okala.RestApi.Common;

namespace Okala.RestApi.Cryptocurrency.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class CryptocurrencyController :BaseController
{
    private readonly IFetchData fetchData;
    public CryptocurrencyController(IFetchData fetchData)
    {
        this.fetchData = fetchData;
    }


    [HttpGet]
    public async Task<ActionResult<GetCryptoDto>> Get([FromQuery] GetCryptoQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
    [HttpGet("by-name")]
    public async Task<ActionResult<GetCryptoDto>> Get([FromQuery] GetCryptoByNameQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("Update-DataBase-With-The-Latest")]
    public async Task<ActionResult<GetCryptoDto>> Post()
    {

        List<CreateCryptoCommand> command =await fetchData.GetDataOnline();

        foreach (CreateCryptoCommand item in command)
        {
            await Mediator.Send(item);
        }

        return Ok();
    }


}
