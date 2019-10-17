using System;

namespace CoreCms.Domain.DbModels
{
    public class LogModels
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
        public string ClientIp { get; set; }
        public string ClientId { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserAgent { get; set; }
        public string ReferUrl { get; set; }
        public int IsMobile { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int TimeSpan { get; set; }
        public int WinHeight { get; set; }
        public int WinWidth { get; set; }
    }
}
