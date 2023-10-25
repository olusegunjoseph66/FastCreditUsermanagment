namespace FastCreditCodingChallange.ViewModels.Response
{
    public record UserResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public UserStatusResponse UserStatus { get; set; }
        public string Roles { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }

        public UserResponse(int id, string firstName, string lastName, string emailAddress, string gender, string phonenumber,string nationality, UserStatusResponse status, string roles, DateTime? dateOfBirth)
        {
            UserId = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            UserStatus = status;
            Roles = roles;
            Gender = gender;
            Phone = phonenumber;
            Nationality = nationality;
            DateOfBirth = dateOfBirth;
        }
    }
}

