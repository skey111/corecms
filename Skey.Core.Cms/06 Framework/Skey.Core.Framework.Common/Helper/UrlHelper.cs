using System;
using System.Collections.Generic;
using System.Text;

namespace Skey.Core.Framework.Common.Helper
{
    /// <summary>
    /// URL帮助工具
    /// </summary>
    public class UrlHelper
    {
        /// <summary>
        /// 将URL转换成绝对路径
        /// </summary>
        /// <param name="url">例：/Resoureces/Upload/</param>
        /// <returns></returns>
        public static string GetFilePath(string url)
        {
            return url;
            //return url.Replace("/","\\");
        }
    }
}
