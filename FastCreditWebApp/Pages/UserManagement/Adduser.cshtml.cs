using FastCreditWebApp.Request;
using FastCreditWebApp.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace FastCreditWebApp.Pages.UserManagement
{
    public class AdduserModel : PageModel
    {
        private readonly ILogger<AdduserModel> _logger;
        [BindProperty]
        public CreatUserRequestFE CUserRequestFE { get; set; }

        public AdduserModel(ILogger<AdduserModel> logger)
        {
                _logger = logger;
        }
        [TempData]
        public string ErrorMessage { get; set; }
        public List<SelectListItem> Genders { get; set; }
           = new List<SelectListItem>
          {
                new SelectListItem("Male", "Male"),
                new SelectListItem("Female", "Female")
          };
        public List<SelectListItem> projectdropdown { get; set; }
        public Root? Nationallist { get; set; }

        public List<SelectListItem> roledropdown { get; set; }
        public RoleResponseFE? RoleClist { get; set; }

        private HttpClient? client;

        public async Task<IActionResult> OnGet()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7296/api/")

            };


            try
            {
                var response = await client.GetAsync("v1/role/nationals");

                var kuu = await response.Content.ReadAsStringAsync();

                JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(kuu);
                

                Nationallist = JsonConvert.DeserializeObject<Root>(jsonResponse.ToString());

                List<NationalDropdown> ds = new();

                var projectdropdon = Nationallist?.data?.ToList();
                foreach (var item in projectdropdon)
                {
                    var newt = new NationalDropdown
                    {
                        Id = item.id,
                        Name = item.name
                    };
                    ds.Add(newt);
                }
                var nationalist = ds.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList();

                projectdropdown = nationalist;

                ViewData["Project"] = projectdropdown;


                var responserole = await client.GetAsync("v1/role");

                var kuurole = await responserole.Content.ReadAsStringAsync();

                JObject jsonResponserole = JsonConvert.DeserializeObject<JObject>(kuurole);


                RoleClist = JsonConvert.DeserializeObject<RoleResponseFE>(jsonResponserole.ToString());

                List<RolesDropDown> dsrole = new();

                var roledropdon = RoleClist?.data?.ToList();
                foreach (var item in roledropdon)
                {
                    var newtrole = new RolesDropDown
                    {
                        Id = item.id,
                        Name = item.name
                    };
                    dsrole.Add(newtrole);
                }
                var rolelist = dsrole.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList();

                roledropdown = rolelist;

                ViewData["Roles"] = roledropdown;


            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                ErrorMessage = ex.Message;
                return null;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                

                client = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7296/api/")
                };

                var info = await client.PostAsJsonAsync<CreatUserRequestFE>("v1/User", CUserRequestFE);
                ErrorMessage = await info.Content.ReadAsStringAsync();


                if (ErrorMessage != null)
                {
                    _logger.LogInformation("User has been Added .");

                    ErrorMessage.ToString();

                     return RedirectToPage("/UserManagement/Listuser");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Could not add user.");
                    return Page();
                }
                

            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return null;
            }

        }

    }
}
