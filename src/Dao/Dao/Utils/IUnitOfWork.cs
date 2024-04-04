namespace Dao.Utils
{
    public interface IUnitOfWork
    {
        TRepository Get<TRepository>();

        /// <summary>
        /// 儲存變更
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// 放棄變更
        /// </summary>
        void AbortChanges();
    }
}
