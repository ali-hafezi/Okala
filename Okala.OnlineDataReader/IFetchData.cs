using Okala.Application.Commands.Cryptoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okala.OnlineDataReader;

public interface IFetchData
{
    Task<List<CreateCryptoCommand>> GetDataOnline();
}
