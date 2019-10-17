

using System;

namespace CoreCms.Application.Entity
{
    /// <summary>
    /// 缓存对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CacheItem<T>
    {
        private readonly string KEY;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entity"></param>
        public CacheItem(object key, T entity)
        {
            CreateDate = DateTime.Now;

            Data = entity;

            KEY = string.Format("{0}_{1}", nameof(entity), key.ToString());
        }

        /// <summary>
        /// 当前Key
        /// </summary>
        public string Key
        {
            get
            {
                return KEY;
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; private set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime Expire { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; private set; }
    }
}
