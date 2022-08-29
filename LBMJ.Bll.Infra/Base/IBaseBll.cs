using System.Data;

namespace LBMJ.Bll.Infra.Base
{
    public interface IBaseBll<TInfo>
    {
        Task<TInfo> GetByIdAsync(int id, IDbTransaction transaction = null);
        Task<List<TInfo>> GetAllAsync();
        Task<bool> InsertAsync(TInfo entity, IDbTransaction transaction = null);
        Task<bool> UpdateAsync(TInfo entity, IDbTransaction transaction = null);
        Task<bool> DeleteAsync(TInfo entity, IDbTransaction transaction = null);
    }
}
