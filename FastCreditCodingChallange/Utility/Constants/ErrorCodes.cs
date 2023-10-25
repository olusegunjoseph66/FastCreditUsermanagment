namespace FastCreditCodingChallange.Utility.Constants
{
    public class ErrorCodes
    {
        public const string INCOMPLETE_INPUT = "Error-A-01";
        public const string DEFAULT_VALIDATION_CODE = "Error-A-02";
        public const string USERNAME_ALEADY_EXIST = "Error-A-03";
        public const string EMAIL_ALEADY_EXIST = "Error-A-04";
        public const string USER_NOT_FOUND = "E04";
        public const string ACCOUNT_LOCKED_RESET_PASSWORD = "Error-A-13";
        public const string USERNAME_PASSWORD_NOT_EXIST = "Error-A-12";
        public const string ACCOUNT_EXPIRED_RESET_PASSWORD = "Error-A-14";
        public const string ACCOUNT_DISABLED_RESET_PASSWORD = "Error-A-15";
        public const string PROVIDED_EMAIL_CONFLICT_WITH_ANOTHER = "Error-A-16";
        public const string RETRIES_EXCEEDED = "Error-A-21";
        public const string UNAUTHORIZED_ACCESS = "Error-A-28";
        public const string DANGOTE_RECORD_NOT_FOUND = "Error-A-32";
        public const string USER_RECORD_NOT_FOUND = "Error-A-29";
        public const string SERVER_ERROR_CODE = "E04";
        public const string NOTFOUND_ERROR_CODE = "E05";
        public const string CONFLICT_ERROR_CODE = "E06";
        public const string SERVER_CONFIGURATION_ERROR_CODE = "E07";
        public const string DEFAULT_AUTHORIZATION_CODE = "E02";
        public const string DATABASE_INSERT_CONFLICT_CODE = "E03";
        public const string OTP_AUTHORIZED_USER_REQUIRED_CODE = "E08";

        public const int SqlServerViolationOfUniqueIndex = 2601;
        public const int SqlServerViolationOfUniqueConstraint = 2627;
       

        public const string USER_WITH_USERNAME_NOTFOUND_CODE = "Error-A-09";
        public const string ROLE_ALEADY_EXIST = "Error-A-24";
        public const string PASSWORD_INVALID_CODE = "Error-A-25";
       
    }
}
