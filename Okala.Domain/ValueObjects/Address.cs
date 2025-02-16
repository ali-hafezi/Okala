using Microsoft.EntityFrameworkCore;
using Okala.Domain.Common;

namespace Okala.Domain.ValueObjects;

[Owned] 
public class Address : ValueObject
{
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
}


