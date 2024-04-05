using Api.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Service;

namespace Api.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [OpenApiTag("WS-01 : 建立員工資料", Description = "提供單筆員工資料建立功能")]
        [HttpPost("app/create_employee")]
        public ResponseResult Create(Employee employeeInfo)
        {
            var executeResult = _employeeService.CreateEmployee(employeeInfo);

            var responseResult = new ResponseResult
            {
                ErrorCode = executeResult ? ErrorCode.Success : ErrorCode.Failed,
                Message = executeResult ? "建立員工資料成功" : "建立員工資料失敗"
            };

            return responseResult;
        }
    }
}
