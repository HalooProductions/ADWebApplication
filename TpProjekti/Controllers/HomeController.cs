using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TpProjekti.Models;
using Haloo.DirectoryServices;
using Microsoft.Extensions.Options;

namespace TpProjekti.Controllers
{
    public class HomeController : Controller
    {
        private IADManager _manager;
        private ADConfig _options;

        public HomeController(IADManager aDManager, IOptions<ADConfig> adConfig)
        {
            _manager = aDManager;
            _options = adConfig.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
