using System.Data;

namespace LBMJ.Dal.Infra.Base
{
    public interface IBaseCrudDal<TInfo> where TInfo : class
    {
        Task<bool> InsertAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<bool> DeleteAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<bool> UpdateAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<TInfo> GetByIdAsync(int id, IDbConnection connection, IDbTransaction transaction = null);
        Task<List<TInfo>> GetAllAsync(IDbConnection connection);
    }
}
