using Dao.Utils;
using Entity;
using System.Data;
using System.Text;

namespace Dao
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public override Employee Get(Employee entity)
        {
            StringBuilder sqlCommand = new StringBuilder(@"
                SELECT TOP 1 
                    IdentityNo, 
                    Name 
                FROM EMPLOYEE 
                WHERE IdentityNo = @IdentityNo");

            return QueryFirstOrDefault<Employee>(sqlCommand.ToString(), entity);
        }

        public override IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public override int Add(Employee entity)
        {
            StringBuilder sqlCommand = new StringBuilder(@"
                INSERT INTO EMPLOYEE(
                    IdentityNo, 
                    Name
                ) VALUES (
                    @IdentityNo, 
                    @Name
                )");

            return Execute(sqlCommand.ToString(), entity);
        }

        public override int AddRange(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public override int Update(Employee entity)
        {
            StringBuilder sqlCommand = new StringBuilder(@"
                UPDATE EMPLOYEE SET
                    Name = @Name
                WHERE Name = @Name");

            return Execute(sqlCommand.ToString(), entity);
        }

        public override int UpdateRange(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public override int Remove(Employee entity)
        {
            throw new NotImplementedException();
        }

        public override int RemoveRange(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }
    }
}
