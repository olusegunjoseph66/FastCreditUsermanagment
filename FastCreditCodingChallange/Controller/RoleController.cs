using FastCreditCodingChallange.Services;
using FastCreditCodingChallange.Utility.Constants;
using FastCreditCodingChallange.ViewModels.Requests;
using FastCreditCodingChallange.ViewModels.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastCreditCodingChallange.Controller
{
    [Route("api/v1/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<RoleResponse>))]
        public async Task<IActionResult> GetRoles(CancellationToken cancellationToken = default) => Response(await _roleService.GetRoles(cancellationToken));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<EmptyResponse>))]
        public async Task<IActionResult> CreateRole([FromForm] string name, CancellationToken cancellationToken) => Response(await _roleService.AddRoles(name, cancellationToken));

        
        [HttpGet("nationals")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<NationalityResponse>))]
        public async Task<IActionResult> GetNations(CancellationToken cancellationToken = default) => Response(await _roleService.GetNationality(cancellationToken));

    }
}
