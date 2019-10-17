
using CoreCms.Domain.DbModels;
using CoreCms.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Skey.Core.Framework.Repository;

namespace CoreCms.DbRepository
{
    public class AccountRepository : BaseRepository<AccountInfo, int>, IAccountInterface
    {
        public AccountRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
