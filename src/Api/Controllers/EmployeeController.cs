using Api.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Service;

namespace Api.Controllers
{
    /// <summary>
    /// 員工資料API服務
    /// </summary>
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [OpenApiTag("WS-01 : 建立員工資料", Description = "提供單筆員工資料建立功能")]
        [HttpPost("app/employee")]
        public ResponseResult Create(Employee employeeInfo)
        {
            var executeResult = _employeeService.CreateEmployee(employeeInfo);

            var responseResult = new ResponseResult
            {
                ErrorCode = executeResult ? (int)ErrorCode.Success : (int)ErrorCode.Failed,
                Message = executeResult ? "建立員工資料成功" : "建立員工資料失敗"
            };

            return responseResult;
        }

        [OpenApiTag("WS-02 : 讀取員工資料", Description = "提供單筆員工資料讀取功能")]
        [HttpGet("app/employee")]
        public ResponseResult Read(Employee employeeInfo)
        {
            var executeResult = _employeeService.ReadEmployee(employeeInfo);

            var responseResult = new ResponseResult
            {
                ErrorCode = executeResult != null ? (int)ErrorCode.Success : (int)ErrorCode.Failed,
                Message = executeResult != null ? "讀取員工資料成功" : "讀取員工資料失敗",
                Data = executeResult
            };

            return responseResult;
        }

        [OpenApiTag("WS-03 : 更新員工資料", Description = "提供單筆員工資料更新功能")]
        [HttpPut("app/employee")]
        public ResponseResult Update(Employee employeeInfo)
        {
            var executeResult = _employeeService.UpdateEmployee(employeeInfo);

            var responseResult = new ResponseResult
            {
                ErrorCode = executeResult ? (int)ErrorCode.Success : (int)ErrorCode.Failed,
                Message = executeResult ? "更新員工資料成功" : "更新員工資料失敗"
            };

            return responseResult;
        }

        [OpenApiTag("WS-04 : 刪除員工資料", Description = "提供單筆員工資料刪除功能")]
        [HttpDelete("app/employee")]
        public ResponseResult Delete(Employee employeeInfo)
        {
            var executeResult = _employeeService.DeleteEmployee(employeeInfo);

            var responseResult = new ResponseResult
            {
                ErrorCode = executeResult ? (int)ErrorCode.Success : (int)ErrorCode.Failed,
                Message = executeResult ? "刪除員工資料成功" : "刪除員工資料失敗"
            };

            return responseResult;
        }
    }
}
