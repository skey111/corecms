using CoreCms.ViewModels.BaseModels;
using Microsoft.AspNetCore.Http;
using Skey.Core.Framework.Common.Helper;
using System.Linq;
using System.Security.Claims;

namespace CoreCms.ViewModels
{
    /// <summary>
    /// 页面基类
    /// </summary>
    public abstract class BaseViewModel
    {
        public BaseViewModel()
        {

        }

        HttpContext _httpContext;
        public void SetBase(HttpContext httpContext)
        {
            _httpContext = httpContext;

            if (_httpContext != null)
            {
                var claims = _httpContext.User.Claims;
                var uid = claims.SingleOrDefault(p => p.Type == ClaimTypes.UserData);
                if (uid != null)
                {
                    if (!string.IsNullOrEmpty(uid.Value))
                    {
                        BaseUserData userData = SerializeHelper.DeserializeJSON<BaseUserData>(uid.Value);

                        UserId = userData.UserId;
                        DepartmentId = userData.DepartmentId;
                        CompanyId = userData.CompanyId;
                        Url = _httpContext.Request.Path.ToUriComponent();
                    }
                }
            }
        }

        /// <summary>
        /// 当前用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// 当前URL地址
        /// </summary>
        public string Url { get; set; }
    }
}
