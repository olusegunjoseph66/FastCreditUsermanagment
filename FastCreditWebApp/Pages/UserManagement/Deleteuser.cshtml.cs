using FastCreditWebApp.Request;
using FastCreditWebApp.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FastCreditWebApp.Pages.UserManagement
{
    public class DeleteuserModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        private readonly ILogger<DeleteuserModel> _logger;
        public DeleteuserModel(ILogger<DeleteuserModel> logger)
        {
                _logger = logger;
        }

        [BindProperty]
        public UserDetailsResponseFE? UserDetaResponselst { get; set; }
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


                DeleteUserRequestFE fe = new();
                fe.UserId = id;
                DeleteusedFE = fe;

                var info = await client.PostAsJsonAsync<DeleteUserRequestFE>("v1/User/userbyid", DeleteusedFE);

                var kuu = await info.Content.ReadAsStringAsync();

                JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(kuu);

                UserDetaResponselst = JsonConvert.DeserializeObject<UserDetailsResponseFE>(jsonResponse.ToString());


            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                ErrorMessage = ex.Message;
                return null;
            }
            return Page();
        }


        public async Task<IActionResult> OnPostDelete()
        {
            try
            {
                //if (ModelState.IsValid)
                //{

                client = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7296/api/")
                };



                DeleteUserRequestFE u = new();
                u.UserId = id;
                DeleteusedFE = u;

                var info = await client.PostAsJsonAsync<DeleteUserRequestFE>("v1/User/deleteuser", DeleteusedFE);
                ErrorMessage = await info.Content.ReadAsStringAsync();



                if (ErrorMessage != null)
                {
                    _logger.LogInformation("User Deleted .");

                    ErrorMessage.ToString();

                    return RedirectToPage("/UserManagement/Listuser");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Could not Delete User.");
                    return Page();
                }
                //}

            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return null;
            }

        }
    }
}
