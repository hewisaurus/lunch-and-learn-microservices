using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Frontend.Services;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBackendService _backendService;

        public HomeController(ILogger<HomeController> logger, IBackendService backendService)
        {
            _logger = logger;
            _backendService = backendService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel
            {
                ApiContent = await _backendService.GetBackendApiContent()
            };

            return View(model);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}