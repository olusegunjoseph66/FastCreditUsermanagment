namespace FastCreditWebApp.Request
{
    public class CreatUserRequestFE
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Nationality { get; set; }
        public int RoleId { get; set; }
    }
}
