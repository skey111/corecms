using Skey.Core.Framework.Common.Helper; 
using System.Collections.Generic;
namespace CoreArea.Layouts.Config
{
    public class AppConfig
    {
        /// <summary>
        /// 屏蔽区域
        /// </summary>
        public static List<string> Areas
        {
            get
            {
                List<string> list = new List<string>();

                string alist = ConfigurationHelper.GetConfigValueByKey("Areas");
                if (!string.IsNullOrEmpty(alist))
                {
                    var tlist = alist.Split(',');
                    foreach (var item in tlist)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            list.Add(item);
                        }
                    }
                }

                return list;
            }
        }

        /// <summary>
        /// 验证通过跳转地址
        /// </summary>
        public static string AreaYesUrl
        {
            get
            {
                return ConfigurationHelper.GetConfigValueByKey("AreaYesUrl");
            }
        }

        /// <summary>
        /// 验证没通过跳转地址
        /// </summary>
        public static string AreaNoUrl
        {
            get
            {
                return ConfigurationHelper.GetConfigValueByKey("AreaNoUrl");
            }
        }

        /// <summary>
        /// IP文件地址
        /// </summary>
        public static string IpFilePath
        {
            get
            {
                return ConfigurationHelper.GetConfigValueByKey("IpFilePath");
            }
        }
    }
}
