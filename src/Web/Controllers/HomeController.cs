using Microsoft.AspNetCore.Mvc;
using Service;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult CreateEmployee(Employee employeeInfo)
        {
            _employeeService.CreateEmployee();

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
