using Dao;
using Dao.Utils;
using Entity;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public bool CreateEmployee(Employee employeeInfo)
        {
            var rowCount = _unitOfWork.Get<EmployeeRepository>().Add(employeeInfo);

            _unitOfWork.SaveChanges();

            return rowCount > 0;
        }

        public IEnumerable<Employee> ReadEmployee(Employee employeeInfo)
        {
            return _unitOfWork.Get<EmployeeRepository>().GetBy(employeeInfo);
        }

        public bool UpdateEmployee(Employee employeeInfo)
        {
            var rowCount = _unitOfWork.Get<EmployeeRepository>().Update(employeeInfo);

            _unitOfWork.SaveChanges();

            return rowCount > 0;
        }

        public bool DeleteEmployee(Employee employeeInfo)
        {
            var rowCount = _unitOfWork.Get<EmployeeRepository>().Remove(employeeInfo);

            _unitOfWork.SaveChanges();

            return rowCount > 0;
        }
    }
}
