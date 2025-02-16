using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okala.Domain.Entities;

public interface ICryptoRepository: ICommandRepository<Crypto>
{
    Task Add(Crypto crypto, CancellationToken token);

    Task<Crypto> Get(long id, CancellationToken token);
    Task<Crypto> GetByName(string name, CancellationToken token);
    Task<List<Crypto>> GetListByName(string name, CancellationToken token);

}
