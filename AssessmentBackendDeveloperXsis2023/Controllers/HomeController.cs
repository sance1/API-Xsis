using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AssessmentBackendDeveloperXsis2023.Data;
using AssessmentBackendDeveloperXsis2023.Models;
using AssessmentBackendDeveloperXsis2023.Interface;

namespace AssessmentBackendDeveloperXsis2023.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositories _repository;

    public HomeController(ILogger<HomeController> logger, IRepositories repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public IActionResult Index()
    {
        var data = _repository.movies();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

