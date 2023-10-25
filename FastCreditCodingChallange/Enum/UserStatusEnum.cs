using System.ComponentModel;

namespace FastCreditCodingChallange.Enum
{
    public enum UserStatusEnum
    {
        [Description("Active")]
        Active = 1,

        [Description("Inactive")]
        Inactive = 2,

        [Description("Expired")]
        Expired = 3,

        [Description("Locked Out")]
        Locked = 4
    }
}
