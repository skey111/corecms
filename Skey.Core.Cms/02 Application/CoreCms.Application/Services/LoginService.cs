using CoreCms.Application.Entity;
using CoreCms.Application.Interfaces;
using CoreCms.Domain.DbModels;
using CoreCms.Domain.Interfaces;
using CoreCms.ViewModels.BaseModels;
using Skey.Core.Framework.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreCms.Application.Services
{
    /// <summary>
    /// 登录业务
    /// </summary>
    public class LoginService : ILoginService
    {
        IAccountInterface _accountInterface;

        public LoginService(IAccountInterface account)
        {
            _accountInterface = account;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public LoginResult Login(string username, string password, string code)
        {
            LoginResult result = new LoginResult();

            string cmd = string.Format(" where UserName = '{0}' and UserPwd='{1}'", username, CryptographyHelper.MD5(password));

            var list = _accountInterface.GetList(cmd).ToList();


            if (list != null && list.Count == 1)
            {

                var user = list[0];

                result.UserName = user.UserName;
                result.UserId = user.Id;

                BaseUserData userData = new BaseUserData();

                userData.UserId = user.Id;
                userData.DepartmentId = user.DepartmentId;
                userData.CompanyId = user.CompanyId;
                userData.UserName = user.UserName;
                userData.UserType = user.UserType;

                result.UserData = userData;
                result.Status = true;
            }

            return result;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LoginResult Reg(string username, string password)
        {
            var rcount = _accountInterface.RecordCount();

            LoginResult result = new LoginResult();
            string cmd = string.Format(" where UserName = '{0}'", username);

            var list = _accountInterface.GetList(cmd).ToList();

            if (list.Count == 0)
            {
                AccountInfo account = new AccountInfo();
                account.UserName = username;
                account.UserPwd = CryptographyHelper.MD5(password);
                account.LastLoginDate = DateTime.Now;
                account.LastMoneyDate = DateTime.Now;
                account.RegDate = DateTime.Now;
                account.NickName = username;

                account.RegIp = ClientHelper.ClientIp;
                account.LastLoginIp = ClientHelper.ClientIp;

                if (rcount == 0)
                {
                    //第一个用户是超级管理员
                    account.UserType = 100;
                }

                var uid = _accountInterface.Insert(account);
                if (uid.HasValue)
                {
                    account.Id = uid.Value;
                }

                var user = account;

                result.UserName = user.UserName;
                result.UserId = user.Id;

                BaseUserData userData = new BaseUserData();
                userData.UserId = user.Id;
                userData.DepartmentId = user.DepartmentId;
                userData.CompanyId = user.CompanyId;
                userData.UserName = user.UserName;

                result.UserData = userData;
                result.Status = true;
            }
            else
            {
                result.Msg = "己经存在该用户名，请重新更换用户名。";
            }


            return result;
        }
    }
}
