namespace FastCreditWebApp.Response
{
    //public class RoleResponseFE
    //{

    //}
    public class Rolesitem
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<object> userRoles { get; set; }
    }

    public class RoleResponseFE
    {
        public List<Rolesitem> data { get; set; }
        public string status { get; set; }
        public string statusCode { get; set; }
        public string message { get; set; }
    }

}
