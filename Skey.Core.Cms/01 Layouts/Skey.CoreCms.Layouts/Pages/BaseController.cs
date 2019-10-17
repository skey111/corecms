using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Skey.CoreCms.Layouts.Pages
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 是否提交代码
        /// </summary>
        protected bool Post
        {
            get
            {
                string post = Request.Query["post"];
                if (post == "1")
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetParameter(string key)
        {
            string val = Request.Query[key];

            return val;
        }



        /// <summary>
        /// 获取参数并且保存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetParameterViewBag(string key)
        {
            string val = GetParameter(key);

            if (val != null)
            {
                ViewData[key] = val;
            }

            return val;
        }

        public void SetViewData<T>(T model)
        {

        }
    }
}
