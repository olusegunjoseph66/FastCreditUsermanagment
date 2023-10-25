namespace FastCreditCodingChallange.ViewModels.Response
{
    //public record RoleResponse(List<string> Roles);
    public record RoleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RoleResponse(int id, string name)
        {
            Id = id;
            Name = name;

        }
    }
}
