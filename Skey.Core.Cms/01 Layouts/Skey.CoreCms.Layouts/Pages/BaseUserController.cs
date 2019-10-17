using Microsoft.AspNetCore.Authorization;

namespace Skey.CoreCms.Layouts.Pages
{

    [Authorize]
    /// <summary>
    /// 带有用户信息的基类
    /// </summary>
    public class BaseUserController : BaseController
    {

    }
}
