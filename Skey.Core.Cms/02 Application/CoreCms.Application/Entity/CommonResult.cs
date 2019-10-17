

using System;

namespace CoreCms.Application.Entity
{
    /// <summary>
    /// 公共结果对象
    /// </summary>
    public class CommonResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 对象
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
    }
}
