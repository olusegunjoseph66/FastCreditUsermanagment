using FastCreditCodingChallange.Services;
using FastCreditCodingChallange.Utility;
using FastCreditCodingChallange.Utility.Constants;
using FastCreditCodingChallange.ViewModels.QueryFilters;
using FastCreditCodingChallange.ViewModels.Request;
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
    public class UserController : BaseController
    {
        private readonly IUserServices _userService;
        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<PaginatedList<UserResponse>>))]
        public async Task<IActionResult> GetUsers([FromQuery] UserQueryFilter filter, CancellationToken cancellationToken = default) => Response(await _userService.GetUsers(filter, cancellationToken));

        [HttpPost("userbyid")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<PaginatedList<UserDetailResponse>>))]
        public async Task<IActionResult> GetUserId([FromBody] UserprofileResponse response, CancellationToken cancellationToken = default) => Response(await _userService.GetUserById(response, cancellationToken));


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<EmptyResponse>))]
        public async Task<IActionResult> CreateUser([FromBody] CreatUserRequest request, CancellationToken cancellationToken) => Response(await _userService.AddUsers(request, cancellationToken));

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<EmptyResponse>))]
        public async Task<IActionResult> UpdateUser( [FromBody] UpdateUserRequest request, CancellationToken cancellationToken) => Response(await _userService.UpdateUsers(request, cancellationToken));

        
        [HttpPost("deleteuser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<EmptyResponse>))]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request, CancellationToken cancellationToken) => Response(await _userService.DeletedUser(request, cancellationToken));


        //[HttpDelete("users")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<EmptyResponse>))]
        //public async Task<IActionResult> DeleteUsers([FromBody] int userId, CancellationToken cancellationToken) => Response(await _userService.DeleteUsers(userId, cancellationToken));

    }
}