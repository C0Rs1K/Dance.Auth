using Dance.Auth.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Auth.Api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController(IInfoService infoService) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetInfo()
        {
            var info = await infoService.GetUserInfo(User.Identity.Name);

            return Ok(info);
        }
    }
}
