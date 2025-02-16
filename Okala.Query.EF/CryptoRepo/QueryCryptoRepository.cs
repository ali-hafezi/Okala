using Okala.Domain.Entities;
using Okala.Query.EF;

namespace Okala.Command.EF.CryptoRepo;

public class QueryCryptoRepository : IQueryCryptoRepository
{
    private readonly QueryDbContext ctx;
    public QueryCryptoRepository(QueryDbContext ctx) 
    {
        this.ctx = ctx;
    }

    public Task<Crypto> Get(long id, CancellationToken token)
    {
        return Task.FromResult(ctx.cryptos.Find(id) ?? throw new KeyNotFoundException());
    }
    public Task<Crypto> GetByName(string name, CancellationToken token)
    {
        return Task.FromResult(ctx.cryptos.Where(c=>c.Symbol==name).FirstOrDefault()
            ?? throw new KeyNotFoundException());
    }

}
