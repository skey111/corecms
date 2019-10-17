using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Skey.Core.Framework.Repository
{
    /// <summary>
    /// 数据库工具
    /// </summary>
    public class ConnectionFactory
    {
        private static IDbConnection CreateConnection(string dbtype, string connection)
        {
            if (string.IsNullOrWhiteSpace(dbtype))
                throw new ArgumentNullException("数据库类型未配置，请在配置文件中配置 DbType 的类型。");
            if (string.IsNullOrWhiteSpace(connection))
                throw new ArgumentNullException("数据库链接字符串未配置，请在配置文件中配置该字符串。");
            var dbType = GetDataBaseType(dbtype);
            return CreateConnection(dbType, connection);
        }

        public static IDbConnection CreateConnection(DbType dbType, string connectionString)
        {
            IDbConnection connection = null;

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("数据库链接字符串未配置，请在配置文件中配置该字符串。");

            switch (dbType)
            {
                case DbType.SqlServer:
                    connection = new SqlConnection(connectionString);
                    break;
                case DbType.MySQL:
                    connection = new MySqlConnection(connectionString);
                    break;
                //case DatabaseType.PostgreSQL:
                //    connection = new NpgsqlConnection(strConn);
                //    break;
                default:
                    throw new ArgumentNullException($"这是我的错，还不支持的{dbType.ToString()}数据库类型");

            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public static DbType GetDataBaseType(string dbtype)
        {
            if (string.IsNullOrWhiteSpace(dbtype))
                throw new ArgumentNullException("数据库类型未配置，请在配置文件中配置 DbType 的类型。");
            DbType returnValue = DbType.SqlServer;
            foreach (DbType dbType in Enum.GetValues(typeof(DbType)))
            {
                if (dbType.ToString().Equals(dbtype, StringComparison.OrdinalIgnoreCase))
                {
                    returnValue = dbType;
                    break;
                }
            }
            return returnValue;
        }
    }
}
