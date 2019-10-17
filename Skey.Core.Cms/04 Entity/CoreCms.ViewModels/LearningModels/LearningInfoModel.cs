using System;
using System.ComponentModel.DataAnnotations; 

namespace CoreCms.ViewModels.LearningModels
{
    /// <summary>
    /// 知识内容模型
    /// </summary>
    public class LearningInfoModel : BaseViewModel
    {

        [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }


        [Required]
        [Display(Name = "标题图片")]
        public string TitleImgs { get; set; }

        [Required]
        [Display(Name = "描述")]
        public string Desc { get; set; }

        [Required]
        [Display(Name = "内容")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "标签")]
        public string Labs { get; set; }


        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }


        [Required]
        [Display(Name = "分类名称")]
        public int ParentId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

    }
}
