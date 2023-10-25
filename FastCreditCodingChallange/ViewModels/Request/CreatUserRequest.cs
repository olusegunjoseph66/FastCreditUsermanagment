namespace FastCreditCodingChallange.ViewModels.Requests
{
    public class CreatUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Nationality { get; set; }
        public short RoleId { get; set; }
        
    }
}
