using CoreCms.Application.Entity;

namespace CoreCms.Application.Interfaces
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICacheServices
    {
        /// <summary>
        /// 刷新缓存
        /// </summary>
        void Refresh();

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <returns></returns>
        bool Add<T>(CacheItem<T> cache);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        CacheItem<T> Get<T>(object key);
    }
}
