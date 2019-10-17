using System;

namespace CoreCms.Domain.DbModels
{
    /// <summary>
    /// 知识库分类
    /// </summary>
   public class LearningType
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string ImgUrl { get; set; }
        public string LinkUrl { get; set; }
        public int IsState { get; set; }
        public int IsShow { get; set; }
        public int IsTop { get; set; }
        public int OrderIndex { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastDate { get; set; }
        public int LastUserId { get; set; }
        public int CompanyId { get; set; }
    }
}
