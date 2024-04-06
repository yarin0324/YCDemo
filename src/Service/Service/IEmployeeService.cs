using Entity;

namespace Service
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Create Employee Info
        /// </summary>
        /// <param name="employeeInfo">employee entity</param>
        /// <returns>資料異動筆數 0:失敗、非0:成功 </returns>
        bool CreateEmployee(Employee employeeInfo);

        /// <summary>
        /// Read Employee Info
        /// </summary>
        /// <param name="employeeInfo">employee entity</param>
        /// <returns>Employee 資訊查詢結果 </returns>
        IEnumerable<Employee> ReadEmployee(Employee employeeInfo);

        /// <summary>
        /// Update Employee Info
        /// </summary>
        /// <param name="employeeInfo">employee entity</param>
        /// <returns>資料異動筆數 0:失敗、非0:成功 </returns>
        bool UpdateEmployee(Employee employeeInfo);

        /// <summary>
        /// Delete Employee Info
        /// </summary>
        /// <param name="employeeInfo">employee entity</param>
        /// <returns>資料異動筆數 0:失敗、非0:成功 </returns>
        bool DeleteEmployee(Employee employeeInfo);
    }
}
