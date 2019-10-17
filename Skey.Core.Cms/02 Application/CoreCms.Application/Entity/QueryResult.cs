

using System;
using System.Collections.Generic;

namespace CoreCms.Application.Entity
{
    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryResult<T>
    {
        /// <summary>
        /// 记录数
        /// </summary>
        public int Recount { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 从第1页开始
        /// </summary>
        public int PageIndex { get; set; }
        
        /// <summary>
        /// 数据
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }
}
