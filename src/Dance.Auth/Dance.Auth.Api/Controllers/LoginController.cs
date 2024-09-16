using Microsoft.AspNetCore.Mvc;

namespace Dance.Auth.Api.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}