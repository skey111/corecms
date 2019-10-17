﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skey.CoreCms.Layouts.Middleware
{
    /// <summary>
    /// 权限中间件选项
    /// </summary>
    public class PermissionMiddlewareOption
    {
        /// <summary>
        /// 登录action
        /// </summary>
        public string LoginAction
        { get; set; }
        /// <summary>
        /// 无权限导航action
        /// </summary>
        public string NoPermissionAction
        { get; set; }

        /// <summary>
        /// 用户权限集合
        /// </summary>
        public List<UserPermission> UserPerssions
        { get; set; } = new List<UserPermission>();

        /// <summary>
        /// 不检查页面的，使用小写
        /// </summary>
        public List<string> NoCheckPermission { get; set; }
    }
}