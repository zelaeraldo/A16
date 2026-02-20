using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize] // Vetëm për përdorues të loguar
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View(); 
    }
}

