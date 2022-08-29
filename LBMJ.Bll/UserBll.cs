using LBMJ.Bll.Base;
using LBMJ.Bll.Infra;
using LBMJ.Dal.Infra;
using LBMJ.Dal.Infra.Base;
using LBMJ.Models;
using LBMJ.Token.Security;
using Microsoft.AspNetCore.Http;

namespace LBMJ.Bll
{
    public class UserBll : BaseCrudBll<IUserDal, UserInfo>, IUserBll
    {
        public UserBll(IUserDal repository, IBaseDal baseDal, IHttpContextAccessor httpContextAccessor) : base(repository, baseDal, httpContextAccessor)
        {
        }

        public async Task<UserInfo> AuthenticateAsync(UserInfo user)
        {
            UserInfo info = await _dal.GetByLoginAsync(user.Login, _baseDal.GetConnection());
            user.Password = CryptHelper.EncryptPassword(user.Password);

            if (info == null)
                throw new Exception("Login não encontrado.");

            if (info.Password != user.Password)
                throw new Exception("Senha incorreta.");

            return info;
        }
    }
}
