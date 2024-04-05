using Entity;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult CreateEmployee(Employee employeeInfo)
        {
            //var executeResult = _employeeService.CreateEmployee(employeeInfo);

            //return executeResult ? 
            //    Json(new ResponseResultModel(true, "人員資料新增成功!")) : 
            //    Json(new ResponseResultModel(false, "人員資料新增失敗!"));

            throw new NotImplementedException();
        }

        public ActionResult ReadEmployee(Employee employeeInfo)
        {
            //var executeResult = _employeeService.ReadEmployee(employeeInfo);

            //return Json(new ResponseResultModel(true, "人員資料讀取成功!", executeResult));

            throw new NotImplementedException();
        }

        public ActionResult UpdateEmployee(Employee employeeInfo)
        {
            //var executeResult = _employeeService.UpdateEmployee(employeeInfo);

            //return executeResult ?
            //    Json(new ResponseResultModel(true, "人員資料修改成功!")) :
            //    Json(new ResponseResultModel(false, "人員資料修改失敗!"));

            throw new NotImplementedException();
        }

        public ActionResult DeleteEmployee(Employee employeeInfo)
        {
            //var executeResult = _employeeService.DeleteEmployee(employeeInfo);

            //return executeResult ?
            //    Json(new ResponseResultModel(true, "人員資料刪除成功!")) :
            //    Json(new ResponseResultModel(false, "人員資料刪除失敗!"));

            throw new NotImplementedException();
        }
    }
}
