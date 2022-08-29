using System.Data;

namespace LBMJ.Dal.Infra.Base
{
    public interface IBaseDal : IDisposable
    {
        void FinallyTransaction(bool success, IDbTransaction trans);
        IDbConnection GetConnection();
        IDbTransaction BeginTransaction();
    }
}
