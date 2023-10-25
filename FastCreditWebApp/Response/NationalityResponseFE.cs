namespace FastCreditWebApp.Response
{

    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<object> userNationals { get; set; }
    }

    public class Root
    {
        public List<Datum> data { get; set; }
        public string status { get; set; }
        public string statusCode { get; set; }
        public string message { get; set; }
    }

    //public class NationalityResponselist
    //{
    //    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    //        public int id { get; set; }
    //        public string name { get; set; }
    //        public List<object> userNationals { get; set; }     
    //}

    //public class NationalityResponseFE
    //{
    //    public List<NationalityResponselist>  responsesData { get; set; }
    //    public string status { get; set; }
    //    public string statusCode { get; set; }
    //    public string message { get; set; }
    //}
}
