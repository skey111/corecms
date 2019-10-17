
using CoreCms.Domain.DbModels;
using CoreCms.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Skey.Core.Framework.Repository;

namespace CoreCms.DbRepository
{
    public class LearningTypeRepository : BaseRepository<LearningType, int>, ILearningTypeInterface
    {
        public LearningTypeRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
