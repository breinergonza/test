using System.Web.Mvc;

namespace _1_Presentacion_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}