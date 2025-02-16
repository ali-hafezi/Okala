using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okala.Domain.Entities;

public interface IQueryCryptoRepository
{
    Task<Crypto> Get(long id, CancellationToken token);
    Task<Crypto> GetByName(string name, CancellationToken token);
}
