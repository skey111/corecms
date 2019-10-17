using CoreCms.Application.Entity; 

namespace CoreCms.Application.Interfaces
{
    /// <summary>
    /// 登录工具
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        LoginResult Login(string username, string password, string code);

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        LoginResult Reg(string username, string password);
    }
}
