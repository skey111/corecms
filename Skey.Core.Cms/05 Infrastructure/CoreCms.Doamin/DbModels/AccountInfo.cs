using System; 

namespace CoreCms.Domain.DbModels
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public partial class AccountInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string Area { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int UserType { get; set; }
        public string UserPwd { get; set; }
        public string UserImg { get; set; }
        public DateTime RegDate { get; set; }
        public string RegIp { get; set; }
        public int IsLock { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIp { get; set; }
        public int AccountType { get; set; }
        public string OpenId { get; set; }
        public float ConsumptionMoney { get; set; }
        public float Money { get; set; }
        public float MoneyFree { get; set; }
        public float MoneyCount { get; set; }
        public DateTime LastMoneyDate { get; set; }
        public string WebCode { get; set; }
        public string UserCode { get; set; }
        public int DepartmentId { get; set; }
        public int CompanyId { get; set; }

    }
}
