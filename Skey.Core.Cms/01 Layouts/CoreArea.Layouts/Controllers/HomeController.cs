using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreArea.Layouts.Models;
using Skey.Core.Framework.Common.Helper;

namespace CoreArea.Layouts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string ip = ClientHelper.ClientIp;
            var res = IpDb.IpdbService.Instance.GetIp(ip);

            ViewData["Ip"] = ip;
            ViewData["Res"] = SerializeHelper.SerializeJSON<IpDb.IpResult>(res);

            var isext = Config.AppConfig.Areas.Contains(res.data.city);
            ViewData["IsExt"] = isext;

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
