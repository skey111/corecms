
namespace CoreArea.Layouts.IpDb
{
    /// <summary>
    /// IP结果
    /// </summary>
    public class IpResult
    {
        /// <summary>
        /// 结果 0正确，1错误
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// IP信息
        /// </summary>
        public IpInfo data { get; set; }
    }
}
