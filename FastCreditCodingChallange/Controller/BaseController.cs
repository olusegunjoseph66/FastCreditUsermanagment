using FastCreditCodingChallange.ViewModels.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastCreditCodingChallange.Controller
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]

    public class BaseController : ControllerBase
    {

        protected new IActionResult Response(ApiResponse response)
        {
            if (response.StatusCode == "201")
                return Created("", response);

            if (response.StatusCode == "00")
                return Ok(response);

            if (response.StatusCode == "400")
                return BadRequest(response);

            if (response.StatusCode == "404")
                return NotFound(response);

            if (response.StatusCode == "409")
                return Conflict(response);

            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}

