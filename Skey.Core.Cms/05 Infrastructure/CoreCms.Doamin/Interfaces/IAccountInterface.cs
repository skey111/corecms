using CoreCms.Domain.DbModels;
using Skey.Core.Framework.Repository;

namespace CoreCms.Domain.Interfaces
{
    /// <summary>
    /// 帐户管理
    /// </summary>
    public interface IAccountInterface : IBaseRepository<AccountInfo, int>
    {

    }
}
