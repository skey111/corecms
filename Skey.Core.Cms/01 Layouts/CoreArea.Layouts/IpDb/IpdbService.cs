using CoreArea.Layouts.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreArea.Layouts.IpDb
{
    public class IpdbService
    {
        public readonly City m_city;

        #region 实例

        static IpdbService m_proxy = null;

        private IpdbService()
        {
            if (m_city == null)
            {
                string path = AppConfig.IpFilePath;
                if (!string.IsNullOrEmpty(path))
                {
                    m_city = new City(path);

                }
                else
                {
                    throw new ArgumentNullException("基础文件配置错误。IpDbFile未配置地址。");
                }
            }
        }

        public static IpdbService Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    m_proxy = new IpdbService();
                }

                return m_proxy;
            }
        }

        #endregion

        string language = "CN";

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public IpResult GetIp(string ip)
        {
            //DN.Framework.Utility.LogHelper.Write("ip=" + ip);
            IpResult result = new IpResult();

            try
            {
                CityInfo info = m_city.findInfo(ip, language);
                result.code = 0;
                result.data = new IpInfo();
                result.data.region = info.getRegionName();
                result.data.country = info.getCountryName();
                result.data.city = info.getCityName();
                result.data.isp = "本地IP";
            }
            catch (Exception ex)
            {
                result.code = 1;
                Console.WriteLine(ex.Message);
            }


            return result;
        }
    }
}
