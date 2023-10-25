namespace FastCreditWebApp.Response
{
   

   
    public class UserdetailData
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public object RoleId { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public object Nationality { get; set; }
    }

    public class UserDetailsResponseFE
    {
        public UserdetailData data { get; set; }
        public string status { get; set; }
        public string statusCode { get; set; }
        public string message { get; set; }
    }





}
