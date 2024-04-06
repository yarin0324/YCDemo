using Entity;

namespace Dao
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetBy(Employee entity);
    }
}