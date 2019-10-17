

using System;

namespace CoreCms.Application.Entity
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public class QueryPara
    {
        public QueryPara()
        {
            PageSize = 10;
            PageIndex = 1;
            //Where = " where 1=1 ";
            Order = " id desc ";
        }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页，从第1页开始
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string Where { get; set; }

        /// <summary>
        /// 排序字符串
        /// </summary>
        public string Order { get; set; }
    }
}
