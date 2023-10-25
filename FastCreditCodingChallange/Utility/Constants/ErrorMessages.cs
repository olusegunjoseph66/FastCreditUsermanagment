namespace FastCreditCodingChallange.Utility.Constants
{
    public class ErrorMessages
    {
        internal const string DEFAULT_VALIDATION_MESSAGE = "Sorry, you have supplied one or more wrong inputs. Kindly check your input and try again.";
        internal const string DEFAULT_AUTHORIZATION_MESSAGE = "Sorry, you do not have the right to perform this operation.";

        public const string SERVER_ERROR = "Sorry, we are unable to fulfill your request at the moment, kindly try again later.";
        public const string CONFLICT_ERROR = "Sorry, there seems to be a request conflict, kindly check your input and try again.";
        public const string DATABASE_CONFLICT_ERROR = "One or more unique fields already exist, kindly try again later.";
        public const string NOT_FOUND_ERROR = "Sorry, the resource you have requested for is not available at the moment.";

      
        public const string USERNAME_ALREADY_EXIST = "This username is already taken.";
        public const string PASSWORD_INVALID = "The Password does not match the format specified. You must use the combination of atleast One Alphanumeral, One Lowercase character, One Uppercase character, 1 Number and a minimum password length of 8.";

        public const string DEFAULT_ROLE_NOTFOUND = "The System Default Role cannot be found.";
        public const string ROLE_ALEADY_EXIST = "Sorry, the Role already exist.";
        public const string USER_WITH_USERNAME_NOTFOUND = "Sorry, the User with the Username does not exist.";

        public const string ACCOUNT_LOCKED_RESET_PASSWORD = "Sorry, Cannot login as your account is currently locked.  Perform a password reset";
        public const string USERNAME_PASSWORD_NOT_EXIST = "Sorry, Incorrect username or password provided";
        public const string ACCOUNT_EXPIRED_RESET_PASSWORD = "Sorry, Cannot login as your password has expired.  Perform a password reset";
        public const string ACCOUNT_DISABLED_RESET_PASSWORD = "Sorry, Cannot login as your account has been disabled.  Contact Support";
        public const string PROVIDED_EMAIL_CONFLICT_WITH_ANOTHER = "Sorry, provided email address conflicts with another user’s email address";
        public const string RETRIES_EXCEEDED = "Sorry, Maximum number of retries exceeded";
        public const string UNAUTHORIZED_ACCESS = "Sorry, you do not have the permission to access the resource you are looking for.";
        public const string USER_RECORD_NOT_FOUND = "Sorry, this user does not exist.";
        
        public const string INVALID_FILE_DOWNLOAD_FORMAT = "Sorry, you have selected an invalid format for downloading this file";
        public const string INVALID_FILE_UPLOAD_FORMAT = "Sorry, you have supplied an invalid file format for the file to be uploaded.";
    }
}
