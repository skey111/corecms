using System;

namespace CoreCms.Domain.DbModels
{
    /// <summary>
    /// 知识库内容
    /// </summary>
    public class LearningInfo
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int ResId { get; set; }
        public int ResType { get; set; }
        public string Title { get; set; }
        public string TitleImgs { get; set; }
        public string LinkUrl { get; set; }
        public string Desc { get; set; }
        public string Content { get; set; }
        public string Labs { get; set; }
        public string SysLabs { get; set; }
        public int IsState { get; set; }
        public int IsShow { get; set; }
        public int IsTop { get; set; }
        public int OrderIndex { get; set; }
        public int GoodCount { get; set; }
        public int BadCount { get; set; }
        public int OpenCount { get; set; }
        public int CommentCount { get; set; }
        public int TypeId { get; set; }
        public int GroupId { get; set; }
        public int IsOpen { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastDate { get; set; }
        public int LastUserId { get; set; }
        public int CompanyId { get; set; }
    }
}
