

using System;

namespace CoreCms.Application.Entity
{
    /// <summary>
    /// 服务状态
    /// </summary>
    public enum ServiceState
    {
        /// <summary>
        /// 默认值
        /// </summary>
        Default,
        /// <summary>
        /// 成功
        /// </summary>
        Success,
        /// <summary>
        /// 失败
        /// </summary>
        Lost,
        /// <summary>
        /// 异常
        /// </summary>
        Error
    }
}
