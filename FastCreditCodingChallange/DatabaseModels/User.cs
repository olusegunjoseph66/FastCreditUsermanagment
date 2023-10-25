using System;
using System.Collections.Generic;

namespace FastCreditCodingChallange.DatabaseModels;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Password { get; set; }

    public string? EmailAddress { get; set; }

    public string? UserName { get; set; }

    public string? PhoneNumber { get; set; }

    public short UserStatusId { get; set; }

    public string? Gender { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? PasswordExpiryDate { get; set; }

    public DateTime? DateCreated { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? DateModified { get; set; }

    public int? ModifiedByUserId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? DeletedByUserId { get; set; }

    public DateTime? LockedOutDate { get; set; }
    public virtual UserNational UserNationals { get; set; } = new UserNational();


    //public virtual ICollection<UserNational> UserNationals { get; set; } = new List<UserNational>();

    public virtual UserRole UserRoles { get; set; } = new UserRole();

    public virtual UserStatus UserStatus { get; set; } = null!;
}
