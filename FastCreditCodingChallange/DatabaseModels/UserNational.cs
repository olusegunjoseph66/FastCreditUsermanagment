using System;
using System.Collections.Generic;

namespace FastCreditCodingChallange.DatabaseModels;

public partial class UserNational
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public short NationalId { get; set; }

    public virtual National National { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
