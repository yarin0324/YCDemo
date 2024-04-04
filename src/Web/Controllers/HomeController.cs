using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult CreateEmployee(Employee employeeInfo)
        {
            throw new NotImplementedException();
        }

        public ActionResult ReadEmployee()
        {
            return Json(new ResponseResultModel(true, "", new Employee()
            {
                IdentityNo = "A123456789",
                Name= "王O明"
            }));
        }

        public ActionResult UpdateEmployee()
        {
            throw new NotImplementedException();
        }

        public ActionResult DeleteEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
