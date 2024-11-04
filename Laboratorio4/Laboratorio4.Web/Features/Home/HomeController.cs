using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Laboratorio4.Web.Features.Home
{
    public partial class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public virtual IActionResult Index()
        {
            return View();
        }

        public virtual IActionResult Privacy()
        {
            return View();
        }
    }
}