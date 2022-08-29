using Dapper.Contrib.Extensions;
using LBMJ.Dal.Infra.Base;
using System.Data;

namespace LBMJ.Dal.MySql.Base
{
    public abstract class MySqlBaseCrudDal<TInfo> : IBaseCrudDal<TInfo> where TInfo : class
    {
        public async virtual Task<List<TInfo>> GetAllAsync(IDbConnection connection)
        {
            var list = await connection.GetAllAsync<TInfo>();
            return list.ToList();
        }
        public async virtual Task<TInfo> GetByIdAsync(int id, IDbConnection connection, IDbTransaction transaction = null)
        {
            return await connection.GetAsync<TInfo>(id, transaction);
        }
        public async virtual Task<bool> InsertAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            try
            {
                await connection.InsertAsync(entity, transaction);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public async virtual Task<bool> UpdateAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            try
            {
                return await connection.UpdateAsync(entity, transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async virtual Task<bool> DeleteAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            try
            {
                return await connection.DeleteAsync(entity, transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
