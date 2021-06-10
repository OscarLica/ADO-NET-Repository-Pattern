using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TagHelpers.Models;
using TagHelpers.Service;

namespace TagHelpers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientService _ClientService;
        public HomeController(ILogger<HomeController> logger, IClientService clientService)
        {
            _logger = logger;
            _ClientService = clientService;
        }

        public IActionResult Index()
        {
           var result = _ClientService.GetAll();
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
}
