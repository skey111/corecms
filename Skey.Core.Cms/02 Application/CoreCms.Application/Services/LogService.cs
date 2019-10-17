

using CoreCms.Application.Interfaces;
using CoreCms.Domain.DbModels;
using CoreCms.Domain.Interfaces;

namespace CoreCms.Application.Services
{
    public class LogService : ILogService
    {
        ILogModelsInterface  _logModelsInterface;

        public LogService(ILogModelsInterface logModelsInterface)
        {
            _logModelsInterface = logModelsInterface;
        }

        public void AddLogModels(LogModels log)
        {
            _logModelsInterface.Insert(log);
        }
    }
}
