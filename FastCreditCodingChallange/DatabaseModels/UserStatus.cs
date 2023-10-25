using System;
using System.Collections.Generic;

namespace FastCreditCodingChallange.DatabaseModels;

public partial class UserStatus
{
    public short Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
