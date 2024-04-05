namespace Dao.Utils
{
    public interface IGenericRepository<TEntity>
    {
        TEntity Get(TEntity entity);
        IEnumerable<TEntity> GetAll();
        int Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);
        int Update(TEntity entity);
        int UpdateRange(IEnumerable<TEntity> entities);
        int Remove(TEntity entity);
        int RemoveRange(IEnumerable<TEntity> entities);
    }
}
