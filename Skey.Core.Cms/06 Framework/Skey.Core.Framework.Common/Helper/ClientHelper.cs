using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Net.Http.Headers;
using System.Linq; 

namespace Skey.Core.Framework.Common.Helper
{
    /// <summary>
    /// 客户端工具
    /// </summary>
    public class ClientHelper
    {
        private static IHttpContextAccessor _accessor;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="httpContext"></param>
        public static void Configure(IHttpContextAccessor httpContext)
        {
            _accessor = httpContext;
        }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public static string ClientIp
        {
            get
            {
                var ip = _accessor.HttpContext.Request.Headers[ForwardedHeadersDefaults.XForwardedForHeaderName].ToString();
                if (string.IsNullOrEmpty(ip))
                {
                    ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }
                else
                {
                    var list = ip.Split(',');
                    if (list.Length >= 1)
                    {
                        ip = list[0];
                    }
                }
                return ip;
            }
        }

        /// <summary>
        /// 客户信息
        /// </summary>
        public static string UseAgent
        {
            get
            {
                var useagent = _accessor.HttpContext.Request.Headers[HeaderNames.UserAgent];
                return useagent.FirstOrDefault();
            }
        }
    }
}
