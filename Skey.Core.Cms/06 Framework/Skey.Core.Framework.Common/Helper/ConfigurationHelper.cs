using Microsoft.Extensions.Configuration;

namespace Skey.Core.Framework.Common.Helper
{
    /// <summary>
    /// 配置文件读取工具，需要设置属性值
    /// </summary>
    public class ConfigurationHelper
    {
        private static IConfiguration _config;
        public static void Configure(IConfiguration config)
        {
            _config = config;
        }
        /// <summary>
        /// 根据配置文件键读取对应的值
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string GetConfigValueByKey(string Key)
        {
            var value = _config[Key];
            return value;
        }
    }
}
