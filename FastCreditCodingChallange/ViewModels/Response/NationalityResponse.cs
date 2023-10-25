namespace FastCreditCodingChallange.ViewModels.Response
{
   
    public record NationalityResponse
    {
        public int NationalityId { get; set; }
        public string NationalityName { get; set; }

        public NationalityResponse(int nationalityId, string nationalityName )
        {
            NationalityId = nationalityId;
            NationalityName = nationalityName;
          
        }
    }
}
