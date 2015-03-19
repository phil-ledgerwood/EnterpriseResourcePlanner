using System.Web.Mvc;

namespace EnterpriseResourcePlanner.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}