namespace FastCreditCodingChallange.ViewModels.Response
{
    public class UserDetailResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string RoleId { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
    }
}
