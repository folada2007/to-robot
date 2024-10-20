using HackM.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HackM.Controllers;

public class HomeController : Controller
{
    private readonly IStatistics _statistic;

    public HomeController(IStatistics statistic)
    {
        _statistic = statistic;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public async Task<IActionResult> Profile() 
    {
        string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var LoseCount = await _statistic.GetStatisticAsync(id);

        return View(LoseCount);
    }

    public async Task<IActionResult> DropStat() 
    {
        await _statistic.DropStat();

        return RedirectToAction("Index");
    }
}
