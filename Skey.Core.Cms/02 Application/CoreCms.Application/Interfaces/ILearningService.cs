using CoreCms.Application.Entity;
using CoreCms.Domain.DbModels;
using CoreCms.ViewModels.LearningModels;
using System.Collections.Generic;

namespace CoreCms.Application.Interfaces
{
    /// <summary>
    /// 知识库接口
    /// </summary>
    public interface ILearningService
    {

        /// <summary>
        /// 转换成树形结构
        /// </summary>
        /// <param name="dlist"></param>
        /// <returns></returns>
        List<LearningType> ConverTree(List<LearningType> dlist);

        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResult AddType(LearningTypeModel model);

        /// <summary>
        /// 修改类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResult UpdateType(LearningTypeModel model);

        /// <summary>
        /// 删除类型
        /// </summary>
        /// <returns></returns>
        ServiceResult DeleteType(object id);

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<LearningType> LoadTypes();

        /// <summary>
        /// 模型转换
        /// </summary>
        /// <param name="dlist"></param>
        /// <returns></returns>
        LearningTypeModel ConverToTypeModel(LearningType model);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        QueryResult<LearningType> QueryTypes(QueryPara query);

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        LearningType SingleType(object id);


        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResult AddInfo(LearningInfoModel model);

        /// <summary>
        /// 修改内容
        /// </summary>
        /// <returns></returns>
        ServiceResult UpdateInfo(LearningInfoModel model);

        /// <summary>
        /// 删除内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceResult DeleteInfo(object id);

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<LearningInfo> LoadInfos();

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        QueryResult<LearningInfo> QueryInfos(QueryPara query);


        /// <summary>
        /// 模型转换
        /// </summary>
        /// <param name="dlist"></param>
        /// <returns></returns>
        LearningInfoModel ConverToInfoModel(LearningInfo model);

        LearningInfo SingleInfo(object id);

    }
}
