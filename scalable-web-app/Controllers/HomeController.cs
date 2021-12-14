using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using scalable_web_app.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using scalable_web_api;

namespace scalable_web_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeApi _employeeApi;

        public HomeController(ILogger<HomeController> logger, IEmployeeApi employeeApi)
        {
            _logger = logger;
            _employeeApi = employeeApi;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeApi.GetEmployees();
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
