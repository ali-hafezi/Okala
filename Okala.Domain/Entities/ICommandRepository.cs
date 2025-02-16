using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okala.Domain.Entities;

public interface ICommandRepository<T>
{
    long SaveChanges();
}
