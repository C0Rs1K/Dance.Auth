using Dance.Auth.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Auth.Api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InfoController(IInfoService infoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetInfo(CancellationToken cancellationToken)
        {
            var info = await infoService.GetUserInfo(User.Identity.Name);

            return Ok(info);
        }
    }
}
