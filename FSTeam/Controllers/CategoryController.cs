using Microsoft.AspNetCore.Mvc;

namespace FSTeam.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}