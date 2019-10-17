using System;
using System.Collections.Generic;
using System.Text;

namespace Skey.Core.Framework.Common.Helper
{
    /// <summary>
    /// 序列化工具
    /// </summary>
    public class SerializeHelper
    {

        /// <summary>
        /// 将实体类序列化为JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        static public string SerializeJSON<T>(T data)
        {
            return System.Text.Json.JsonSerializer.Serialize<T>(data);
        }

        /// <summary>
        /// 反序列化JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        static public T DeserializeJSON<T>(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(json);
        }
    }
}
