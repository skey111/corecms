

using System;

namespace CoreCms.Application.Entity
{
    /// <summary>
    /// Service接口结果对象
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public ServiceState State { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }
}
