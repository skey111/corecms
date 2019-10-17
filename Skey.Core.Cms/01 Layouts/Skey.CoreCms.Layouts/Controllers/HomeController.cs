using System; 
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreCms.Application.Entity;
using CoreCms.Application.Interfaces;
using CoreCms.ViewModels.AccountModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skey.Core.Framework.Common.Helper;
using Skey.CoreCms.Layouts.Models;
using Skey.CoreCms.Layouts.Pages;

namespace Skey.CoreCms.Layouts.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        ILoginService _service;

        public HomeController(ILogger<HomeController> logger, ILoginService service)
        {
            _logger = logger;
            _service = service;
        }

        [AllowAnonymous]
        /// <summary>
        /// 错误页
        /// </summary>
        /// <returns></returns>
        public IActionResult CusError()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        /// <summary>
        /// 登录页
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Login(LoginModel model)
        {
            CommonResult result = new CommonResult();
            result.Msg = "";

            if (Post)
            {
                string uname = model.UserName;
                string pwd = model.Password;
                string code = model.Code;

                var token = _service.Login(uname, pwd, code);

                result.Success = token.Status;
                result.Msg = token.Msg;

                if (token.Status)
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.Sid, token.UserId.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, token.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.UserData, SerializeHelper.SerializeJSON(token.UserData)));

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    result.Data = token;
                    result.Msg = "登录成功。";
                    result.Success = true;


                    return RedirectToAction("LearningInfoList", "Learning");
                }
            }

            ViewData["Result"] = SerializeHelper.SerializeJSON<CommonResult>(result);
            return View(model);
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <returns></returns>
        public IActionResult RePwd()
        {
            return View();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Reg(LoginModel model)
        {
            CommonResult result = new CommonResult();
            result.Msg = "";

            if (Post)
            {
                string uname = model.UserName;
                string pwd = model.Password;
                string code = model.Code;

                var token = _service.Reg(uname, pwd);

                result.Success = token.Status;
                result.Msg = token.Msg;

                if (token.Status)
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.Sid, token.UserId.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, token.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.UserData, SerializeHelper.SerializeJSON(token.UserData)));

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));


                    result.Data = token;
                    result.Msg = "登录成功。";
                    result.Success = true;

                    return RedirectToAction("LearningInfoList", "Learning");
                }
            }

            ViewData["Result"] = SerializeHelper.SerializeJSON<CommonResult>(result);
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> SignOut()
        {
            int v = 0;
            Console.WriteLine(v.ToString());
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
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
