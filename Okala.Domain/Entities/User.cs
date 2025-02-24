﻿using Okala.Domain.Common;
using Okala.Domain.ValueObjects;

namespace Okala.Domain.Entities;

public class User:BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public Address Address { get; set; }
}
