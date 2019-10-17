using CoreCms.Application.Entity;
using CoreCms.Application.Interfaces;
using CoreCms.Domain.DbModels;
using CoreCms.Domain.Interfaces;
using CoreCms.ViewModels.LearningModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreCms.Application.Services
{
    /// <summary>
    /// 知识库实现
    /// </summary>
    public class LearningService : ILearningService
    {
        ILearningInfoInterface _learningInfo;
        ILearningTypeInterface _learningType;

        public LearningService(ILearningInfoInterface learningInfo, ILearningTypeInterface learningType)
        {
            _learningInfo = learningInfo;
            _learningType = learningType;

        }

        public ServiceResult AddInfo(LearningInfoModel model)
        {
            ServiceResult result = new ServiceResult();
            LearningInfo info = new LearningInfo();
            info.CreateDate = DateTime.Now;
            info.LastDate = DateTime.Now;
            info.Desc = model.Desc;
            info.Content = model.Content;
            info.LastUserId = model.UserId;
            info.Labs = model.Labs;
            info.CreateUserId = model.UserId;
            info.CompanyId = model.CompanyId;
            info.Title = model.Title;
            info.TitleImgs = model.TitleImgs;

            _learningInfo.Insert(info);

            return result;
        }

        public ServiceResult AddType(LearningTypeModel model)
        {
            ServiceResult result = new ServiceResult();

            LearningType info = new LearningType();

            info.CompanyId = model.CompanyId;
            info.CreateDate = DateTime.Now;
            info.CreateUserId = model.UserId;
            info.Desc = model.Desc;
            info.ImgUrl = model.ImgUrl;
            info.LastDate = DateTime.Now;
            info.LastUserId = model.UserId;
            info.Name = model.Name;
            info.ParentId = model.ParentId;
            info.LinkUrl = model.LinkUrl;

            var id = _learningType.Insert(info);

            return result;
        }


        List<LearningType> m_cache_types = new List<LearningType>();

        private void RefreshTypes()
        {
            if (m_cache_types.Count != 0)
            {
                m_cache_types = new List<LearningType>();
                m_cache_types = LoadTypes().ToList();
            }
        }

        private string GetTypeAttr(object id, string key = "Name")
        {
            var info = m_cache_types.SingleOrDefault(p => p.Id == int.Parse(id.ToString()));

            if (info != null)
            {
                return info.Name;
            }
            else
            {
                info = SingleType(id);
                if (info != null) return info.Name;
            }

            return id.ToString();
        }


        public ServiceResult DeleteInfo(object id)
        {
            ServiceResult result = new ServiceResult();

            return result;
        }

        public ServiceResult DeleteType(object id)
        {
            ServiceResult result = new ServiceResult();

            return result;
        }

        public IEnumerable<LearningInfo> LoadInfos()
        {
            List<LearningInfo> list = new List<LearningInfo>();

            return list;
        }

        public IEnumerable<LearningType> LoadTypes()
        {
            var list = _learningType.GetList();

            return list;
        }

        public QueryResult<LearningInfo> QueryInfos(QueryPara query)
        {
            QueryResult<LearningInfo> result = new QueryResult<LearningInfo>();

            result.Data = _learningInfo.GetListPaged(query.PageIndex, query.PageSize, query.Where, query.Order);
            result.Recount = _learningType.RecordCount(query.Where);
            result.PageSize = query.PageSize;
            result.PageIndex = query.PageIndex;


            return result;
        }

        public QueryResult<LearningType> QueryTypes(QueryPara query)
        {
            QueryResult<LearningType> result = new QueryResult<LearningType>();

            result.Data = _learningType.GetListPaged(query.PageIndex, query.PageSize, query.Where, query.Order);
            result.Recount = _learningType.RecordCount(query.Where);
            result.PageSize = query.PageSize;
            result.PageIndex = query.PageIndex;


            return result;
        }

        public ServiceResult UpdateInfo(LearningInfoModel model)
        {
            ServiceResult result = new ServiceResult();

            LearningInfo info = SingleInfo(model.Id);

            info.Desc = model.Desc;
            info.LastDate = DateTime.Now;
            info.LastUserId = model.UserId;
            info.Title = model.Title;
            info.Content = model.Content;
            info.ParentId = model.ParentId;
            info.Labs = model.Labs;
            info.Id = model.Id;
            info.TitleImgs = model.TitleImgs;

            _learningInfo.Update(info);


            result.Code = 1;
            result.Message = "更新成功";
            result.State = ServiceState.Success;

            return result;
        }

        public ServiceResult UpdateType(LearningTypeModel model)
        {
            ServiceResult result = new ServiceResult();

            var info = _learningType.Get(model.Id);
            if (info != null)
            {
                info.LastDate = DateTime.Now;
                info.LastUserId = model.UserId;
                info.Name = model.Name;
                info.Desc = model.Desc;
                info.ParentId = model.ParentId;
                info.ImgUrl = model.ImgUrl;
                info.CompanyId = model.CompanyId;
                info.LinkUrl = model.LinkUrl;

                _learningType.Update(info);
            }

            return result;
        }

        public LearningTypeModel ConverToTypeModel(LearningType model)
        {
            LearningTypeModel vmodel = new LearningTypeModel();

            vmodel.Name = model.Name;
            vmodel.Desc = model.Desc;
            vmodel.ParentId = model.ParentId;
            vmodel.ParentName = GetTypeAttr(model.ParentId);
            vmodel.CreateDate = model.CreateDate;
            vmodel.Id = model.Id;
            vmodel.ImgUrl = model.ImgUrl;
            vmodel.LinkUrl = model.LinkUrl;

            return vmodel;
        }

        public LearningType SingleType(object id)
        {
            var info = _learningType.Get(int.Parse(id.ToString()));

            return info;
        }

        public LearningInfoModel ConverToInfoModel(LearningInfo model)
        {
            LearningInfoModel vmodel = new LearningInfoModel();
            vmodel.Id = model.Id;
            vmodel.Labs = model.Labs;
            vmodel.Title = model.Title;
            vmodel.TitleImgs = model.TitleImgs;
            vmodel.ParentId = model.ParentId;
            vmodel.UserId = model.CreateUserId;
            vmodel.Desc = model.Desc;
            vmodel.Content = model.Content;
            vmodel.CompanyId = model.CompanyId;
            vmodel.CreateDate = model.CreateDate;
            return vmodel;
        }

        public LearningInfo SingleInfo(object id)
        {
            var info = _learningInfo.Get(int.Parse(id.ToString()));
            return info;
        }

        /// <summary>
        /// 转换成树形结构
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<LearningType> ConverTree(List<LearningType> list)
        {
            List<LearningType> tree = new List<LearningType>();

            var root = list.FindAll(p => p.ParentId == 0);

            if (root.Count != 0)
            {
                foreach (var item in root)
                {
                    tree.Add(item);
                    LoopToList("", item.Id, list, 1, tree);
                }
            }

            return tree;
        }

        /// <param name="Pading">空格</param>
        /// <param name="DirId">父路径ID</param>
        /// <param name="datatable">返回的datatable</param>
        /// <param name="deep">树形的深度</param>
        private void LoopToList(string pading, int id, List<LearningType> datatable, int deep, List<LearningType> tree)
        {
            var list = datatable.FindAll(p => p.ParentId == id);
            foreach (LearningType row in list)
            {
                string strPading = "";
                for (int j = 0; j < deep; j++)
                {
                    strPading += "　"; //用全角的空格
                }
                //添加节点
                LearningType temp = row;
                temp.Name = strPading + "|--" + temp.Name;
                tree.Add(temp);

                //递归调用addOtherDll函数，在函数中把deep加1
                LoopToList(strPading, row.Id, datatable, deep + 1, tree);
            }
        }
    }
}
