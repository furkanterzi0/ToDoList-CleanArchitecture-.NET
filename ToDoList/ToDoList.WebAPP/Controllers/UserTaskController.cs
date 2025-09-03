using Microsoft.AspNetCore.Mvc;

namespace ToDoList.WebAPP.Controllers
{
    public class UserTaskController : Controller
    {
        public IActionResult List()
        {

            return View();
        }
    }
}
