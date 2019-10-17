
using CoreCms.Domain.DbModels;
using CoreCms.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Skey.Core.Framework.Repository;

namespace CoreCms.DbRepository
{
    public class LogModelsRepository : BaseRepository<LogModels, int>, ILogModelsInterface
    {
        public LogModelsRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}

