using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skey.CoreCms.Layouts.Pages;

namespace Skey.CoreCms.Layouts.Controllers
{
    public class UserController : BaseUserController
    {
        [AllowAnonymous]
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            string name = User.Identity.Name;
            return View();
        }
    }
}
