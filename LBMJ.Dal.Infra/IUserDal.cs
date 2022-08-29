using LBMJ.Dal.Infra.Base;
using LBMJ.Models;
using System.Data;

namespace LBMJ.Dal.Infra
{
    public interface IUserDal : IBaseCrudDal<UserInfo>
    {
        Task<UserInfo> GetByLoginAsync(string login, IDbConnection dbConnection = null, IDbTransaction transaction = null);
    }
}
