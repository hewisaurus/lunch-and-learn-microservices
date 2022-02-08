using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Frontend.Models.Configuration;
using Frontend.Services;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBackendService _backendService;
        private readonly ContentConfiguration _contentConfiguration;
        

        public HomeController(ILogger<HomeController> logger, IBackendService backendService, 
            ContentConfiguration contentConfiguration)
        {
            _logger = logger;
            _backendService = backendService;
            _contentConfiguration = contentConfiguration;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel
            {
                ApiContent = await _backendService.GetBackendApiContent(),
                MyContent = _contentConfiguration.Display
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