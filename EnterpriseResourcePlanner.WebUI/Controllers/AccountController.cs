using System.Web.Mvc;
using EnterpriseResourcePlanner.Service;
using EnterpriseResourcePlanner.WebUI.Models;
using EnterpriseResourcePlanner.WebUI.Utils;

namespace EnterpriseResourcePlanner.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IAuthenticationPersister _authenticationPersister;

        public AccountController(IUserAccountService userAccountService, IAuthenticationPersister authenticationPersister)
        {
            _userAccountService = userAccountService;
            _authenticationPersister = authenticationPersister;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel login)
        {
            if (!ModelState.IsValid) return View(login);

            if (_userAccountService.Login(login.UserName, login.Password))
            {
                _authenticationPersister.SetAuthCookie(login.UserName, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Login data is incorrect!");
            return View("Index", login);
        }
    }
}