

using CoreCms.Application.Entity;
using CoreCms.Application.Interfaces;
using System;

namespace CoreCms.Application.Services
{

    /// <summary>
    /// 缓存实现
    /// </summary>
    public class MoneyCacheServices : ICacheServices
    {
        public bool Add<T>(CacheItem<T> cache)
        {
            throw new NotImplementedException();
        }

        public CacheItem<T> Get<T>(object key)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
