using Dapper;
using LBMJ.Dal.Infra;
using LBMJ.Dal.MySql.Base;
using LBMJ.Models;
using System.Data;

namespace LBMJ.Dal.MySql
{
    public class UserDal : MySqlBaseCrudDal<UserInfo>, IUserDal
    {
        public async Task<UserInfo> GetByLoginAsync(string login, IDbConnection connection, IDbTransaction transaction)
        {
            var sql = @"SELECT * FROM Usuario WHERE LOGIN = @LOGIN";
            var user = await connection.QueryAsync<UserInfo>(sql, new { login });
            return user.FirstOrDefault();
        }
    }
}
