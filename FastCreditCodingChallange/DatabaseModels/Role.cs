using System;
using System.Collections.Generic;

namespace FastCreditCodingChallange.DatabaseModels;

public partial class Role
{
    public short Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
