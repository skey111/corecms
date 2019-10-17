
namespace CoreCms.ViewModels.BaseModels
{
    /// <summary>
    /// 用户基本信息
    /// </summary>
    public class BaseUserData
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 登录名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户类型，100是超级管理员
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        public int CompanyId { get; set; }
    }
}
