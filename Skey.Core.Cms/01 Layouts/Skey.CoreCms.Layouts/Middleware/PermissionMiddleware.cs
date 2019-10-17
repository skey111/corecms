

using CoreCms.Application.Interfaces;
using CoreCms.Domain.DbModels;
using Microsoft.AspNetCore.Http;
using Skey.Core.Framework.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Skey.CoreCms.Layouts.Middleware
{
    /// <summary>
    /// 权限中间件
    /// </summary>
    public class PermissionMiddleware
    {
        /// <summary>
        /// 管道代理对象
        /// </summary>
        private readonly RequestDelegate _next;
        /// <summary>
        /// 权限中间件的配置选项
        /// </summary>
        private readonly PermissionMiddlewareOption _option;

        /// <summary>
        /// 用户权限集合
        /// </summary>
        internal static List<UserPermission> _userPermissions;

        private HttpContext m_context;

        private ILogService _logService;

        /// <summary>
        /// 权限中间件构造
        /// </summary>
        /// <param name="next">管道代理对象</param>
        /// <param name="permissionResitory">权限仓储对象</param>
        /// <param name="option">权限中间件配置选项</param>
        public PermissionMiddleware(RequestDelegate next, PermissionMiddlewareOption option, ILogService logService)
        {
            _option = option;
            _next = next;
            _userPermissions = option.UserPerssions;
            _logService = logService;
        }
        /// <summary>
        /// 调用管道
        /// </summary>
        /// <param name="context">请求上下文</param>
        /// <returns></returns>
        public Task Invoke(HttpContext context)
        {
            //请求Url
            m_context = context;
            AddLog();

            var questUrl = context.Request.Path.Value.ToLower();

            if (_option.NoCheckPermission.Contains(questUrl))
            {
                return this._next(context);
            }


            //是否经过验证
            var isAuthenticated = context.User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                //超级管理员直接通过
                if (IsAdmin)
                {
                    return this._next(context);
                }

                if (_userPermissions.GroupBy(g => g.Url).Where(w => w.Key.ToLower() == questUrl).Count() > 0)
                {
                    //用户名
                    var userName = context.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Sid).Value;
                    if (_userPermissions.Where(w => w.UserName == userName && w.Url.ToLower() == questUrl).Count() > 0)
                    {
                        return this._next(context);
                    }
                    else
                    {
                        //无权限跳转到拒绝页面
                        context.Response.Redirect(_option.NoPermissionAction);
                    }
                }
            }
            else
            {
                context.Response.Redirect(_option.LoginAction);
            }
            return this._next(context);
        }

        private bool IsAdmin
        {
            get
            {
                var username = m_context.User.Identity.Name;
                if (username == "admin") return true;

                return false;
            }
        }

        protected void AddLog()
        {
            LogModels log = new LogModels();
            log.ClientId = "";
            log.ClientIp = ClientHelper.ClientIp;
            log.CreateDate = DateTime.Now;
            log.ReferUrl = "";
            log.TimeEnd = DateTime.Now;
            log.TimeSpan = 0;
            log.TimeStart = DateTime.Now;
            log.Url = m_context.Request.Path.Value;
            log.UserAgent = ClientHelper.UseAgent;
            log.UserId = 0;
            log.WinHeight = 0;
            log.WinWidth = 0;

            _logService.AddLogModels(log);
        }
    }
}