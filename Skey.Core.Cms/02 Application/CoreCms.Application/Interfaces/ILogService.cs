
using CoreCms.Domain.DbModels;

namespace CoreCms.Application.Interfaces
{
    public interface ILogService
    {
        /// <summary>
        /// 访问日志
        /// </summary>
        /// <param name="log"></param>
        void AddLogModels(LogModels log);

    }
}
