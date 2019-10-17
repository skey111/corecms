

using System;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.ViewModels.LearningModels
{
    /// <summary>
    /// 知识分类模型
    /// </summary>
    public class LearningTypeModel : BaseViewModel
    {
        [Required]
        [Display(Name = "当前ID")]
        /// <summary>
        /// 当前ID
        /// </summary>
        public int Id { get; set; }

        [Required]
        [Display(Name = "上级ID")]
        /// <summary>
        /// 上级分类ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 上级分类名称
        /// </summary>
        public string ParentName { get; set; }


        [Required]
        [Display(Name = "名称")]
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        [Required]
        [Display(Name = "链接地址")]
        /// <summary>
        /// 名称
        /// </summary>
        public string LinkUrl { get; set; }


        [Display(Name = "描述")]
        /// <summary>
        /// 描述
        /// </summary>

        public string Desc { get; set; }


        [Display(Name = "图片地址")]
        /// <summary>
        /// 图片地址
        /// </summary>

        public string ImgUrl { get; set; }


        [Display(Name = "创建时间")]
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }


    }
}
