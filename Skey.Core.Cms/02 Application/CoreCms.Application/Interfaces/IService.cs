
using System.Collections.Generic;

namespace CoreCms.Application.Interfaces
{
    /// <summary>
    /// 基础接口
    /// </summary>
    public interface IService<T,Int32>
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(T model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Edit(T model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 加载所有数据
        /// </summary>
        /// <returns></returns>
        List<T> Load();

        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        List<T> GetPageList();
    }
}
