

using System.ComponentModel.DataAnnotations;

namespace CoreCms.ViewModels.AccountModels
{
    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginModel
    {
        [Required]
        [Display(Name = "登录名称")]
        /// <summary>
        /// 登录名称
        /// </summary>
        public string UserName { get; set; }

        [Required]
        [Display(Name = "登录密码")]
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }

        [Display(Name = "验证码")]
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
    }
}
