using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using FastCreditWebApp.Response;
using System.ComponentModel.DataAnnotations;
using FastCreditWebApp.Request;

namespace FastCreditWebApp.Pages.UserManagement
{
    public class ListuserModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }


        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } 

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } 
        private readonly ILogger<ListuserModel> _logger;
        public ListuserModel(ILogger<ListuserModel> logger)
        {
                _logger = logger;
        }


        [TempData]
        public string ErrorMessage { get; set; }
        [BindProperty]
        public DeleteUserRequestFE DeleteusedFE { get; set; }
        public UserResponseFE? UserResponselst { get; set; }

        private HttpClient? client;


        public async Task<IActionResult> OnGet()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7296/api/")


            };

            
            try
            {
                var response = await client.GetAsync("v1/User");

                var kuu = await response.Content.ReadAsStringAsync();

                JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(kuu);

                UserResponselst = JsonConvert.DeserializeObject<UserResponseFE>(jsonResponse.ToString());





            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                ErrorMessage = ex.Message;
                return null;
            }
            return Page();
        }

        

    }
}
