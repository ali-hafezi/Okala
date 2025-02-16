using Okala.Domain.Entities;

namespace Okala.Command.EF.CryptoRepo;

public class CryptoRepository : ICryptoRepository
{
    private readonly CommandDbContext ctx;
    public CryptoRepository(CommandDbContext ctx) 
    {
        this.ctx = ctx;
    }
    public Task Add(Crypto crypto, CancellationToken token)
    {
        ctx.Add(crypto);
        return Task.CompletedTask;
    }

    public Task<Crypto> Get(long id, CancellationToken token)
    {
        return Task.FromResult(ctx.cryptos.Find(id) ?? throw new KeyNotFoundException());
    }

    public Task<Crypto> GetByName(string name, CancellationToken token)
    {
        return Task.FromResult( ctx.cryptos.Where(c=>c.Symbol.ToLower() == name.ToLower()).LastOrDefault()
            ?? throw new KeyNotFoundException());
    }
    public Task<List<Crypto>> GetListByName(string name, CancellationToken token)
    {
        return Task.FromResult(ctx.cryptos.Where(c => c.Symbol.ToLower() == name.ToLower())
            .OrderByDescending(c=>c.DateTime).Take(10).ToList()
            ?? throw new KeyNotFoundException());
    }

    public long SaveChanges()
    {
        int result=ctx.SaveChanges();
        return result;
    }
}
