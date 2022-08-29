using LBMJ.Bll.Infra.Base;
using LBMJ.Models;

namespace LBMJ.Bll.Infra
{
    public interface IUserBll : IBaseBll<UserInfo>
    {
        Task<UserInfo> AuthenticateAsync(UserInfo user);
    }
}
