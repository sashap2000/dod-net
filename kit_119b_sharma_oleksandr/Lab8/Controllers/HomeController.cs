using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var students = LoadStud.students;

            return View(students);
        }
    }
}
