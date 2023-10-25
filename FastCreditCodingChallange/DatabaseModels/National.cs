using System;
using System.Collections.Generic;

namespace FastCreditCodingChallange.DatabaseModels;

public partial class National
{
    public short Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<UserNational> UserNationals { get; set; } = new List<UserNational>();
}
