
using CoreCms.Domain.DbModels;
using CoreCms.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Skey.Core.Framework.Repository;

namespace CoreCms.DbRepository
{
    public class LearningInfoRepository : BaseRepository<LearningInfo, int>, ILearningInfoInterface
    {
        public LearningInfoRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
