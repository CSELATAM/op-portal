using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpPortal.Models;
using OpPortal.Services;

namespace OpPortal.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet(Name = "Home_Index")]
        public IActionResult Index([FromServices]TenantService tenantService)
        {
            ViewBag.AppList = tenantService.List();
            return View();
        }

        [HttpPost(Name= "Home_CreateTenant")]
        public IActionResult CreateTenant([FromForm]string tenantName, [FromServices]TenantService tenantService)
        {
            tenantService.Create(tenantName);

            return Redirect("/");
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
