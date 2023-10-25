using FastCreditWebApp.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FastCreditWebApp.Request;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;

namespace FastCreditWebApp.Pages.UserManagement
{
    public class UpdateuserModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        private readonly ILogger<UpdateuserModel> _logger;

        [BindProperty]
        public UserprofileResponseFE UsernowResponse { get; set; }

        public UpdateuserModel(ILogger<UpdateuserModel> logger)
        {
            _logger = logger;
                
        }
        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public UserDetailsResponseFE? UserDetaResponselst { get; set; }

        [BindProperty]
        public UpdateUserRequestFE UpdateUserReqFE { get; set; }

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


                UserprofileResponseFE Userprofile = new();
                Userprofile.UserId = id;
                UsernowResponse = Userprofile;

                var info = await client.PostAsJsonAsync<UserprofileResponseFE>("v1/User/userbyid", UsernowResponse);                

                var kuu = await info.Content.ReadAsStringAsync();

                JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(kuu);

                UserDetaResponselst = JsonConvert.DeserializeObject<UserDetailsResponseFE>(jsonResponse.ToString());

                
                var response = await client.GetAsync("v1/role/nationals");

                var kuuNational = await response.Content.ReadAsStringAsync();

                JObject jsonResponseNational = JsonConvert.DeserializeObject<JObject>(kuuNational);


                Nationallist = JsonConvert.DeserializeObject<Root>(jsonResponseNational.ToString());

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

        public async Task<IActionResult> OnPostUpdate()
        {
            try
            {

                client = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7296/api/")
                };


                var response = await client.GetAsync("v1/role/nationals");

                var kuuNational = await response.Content.ReadAsStringAsync();

                JObject jsonResponseNational = JsonConvert.DeserializeObject<JObject>(kuuNational);


                Nationallist = JsonConvert.DeserializeObject<Root>(jsonResponseNational.ToString());

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

                UpdateUserReqFE.data = UserDetaResponselst?.data;

                var infoupdate = await client.PutAsJsonAsync<UpdateUserRequestFE>("v1/User", UpdateUserReqFE);
                ErrorMessage = await infoupdate.Content.ReadAsStringAsync();


                if (ErrorMessage != null)
                {
                    _logger.LogInformation("User Updated .");

                    ErrorMessage.ToString();

                    return Page();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Could not add User.");
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
