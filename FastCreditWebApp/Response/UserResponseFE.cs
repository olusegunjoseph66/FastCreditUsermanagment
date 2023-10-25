namespace FastCreditWebApp.Response
{



    public class UserData
    {
        public List<UserItem> items { get; set; }
        public Pagination pagination { get; set; }
    }

    public class UserItem
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public UserStatus UserStatus { get; set; }
        public string RoleId { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public object Nationality { get; set; }
    }

    public class Pagination
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalRecords { get; set; }
    }

    public class UserResponseFE
    {
        public UserData data { get; set; }
        public string status { get; set; }
        public string statusCode { get; set; }
        public string message { get; set; }
    }

    public class UserStatus
    {
        public int id { get; set; }
        public string name { get; set; }
    }

   
}
