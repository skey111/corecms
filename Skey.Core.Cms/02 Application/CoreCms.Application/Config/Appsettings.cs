using Skey.Core.Framework.Common.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Application.Config
{
    /// <summary>
    /// APP配置信息
    /// </summary>
    public class Appsettings
    {
        /// <summary>
        /// 上传目录
        /// </summary>
        public static string UploadDirectory
        {
            get
            {
                string UploadDirectory = ConfigurationHelper.GetConfigValueByKey("UploadDirectory");

                if (string.IsNullOrEmpty(UploadDirectory))
                {
                    UploadDirectory = "/Resources/Upload/";
                }

                return UploadDirectory;
            }
        }
        /// <summary>
        /// 应用名称
        /// </summary>
        public static string AppName
        {
            get
            {
                return ConfigurationHelper.GetConfigValueByKey("AppName");
            }
        }

        /// <summary>
        /// 版本号
        /// </summary>
        public static string Version
        {
            get
            {
                return ConfigurationHelper.GetConfigValueByKey("Version");
            }
        }

        /// <summary>
        /// 页大小
        /// </summary>
        public static int PageSize
        {
            get
            {
                int pageSize = 10;
                string psize = ConfigurationHelper.GetConfigValueByKey("PageSize");
                pageSize = int.Parse(psize);

                return pageSize;
            }
        }

        /// <summary>
        /// 软件商名称
        /// </summary>
        public static string CompanyName
        {
            get
            {

                return ConfigurationHelper.GetConfigValueByKey("CompanyName");
            }
        }

        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static string app(params string[] sections)
        {
            try
            {
                var val = string.Empty;
                for (int i = 0; i < sections.Length; i++)
                {
                    val += sections[i] + ":";
                }
                val = val.TrimEnd(':');
                return ConfigurationHelper.GetConfigValueByKey(val);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }

        }
    }
}
