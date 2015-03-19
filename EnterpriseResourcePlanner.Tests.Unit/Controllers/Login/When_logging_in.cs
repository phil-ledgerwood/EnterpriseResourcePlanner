using System.Web.Mvc;
using EnterpriseResourcePlanner.Service;
using EnterpriseResourcePlanner.WebUI.Controllers;
using EnterpriseResourcePlanner.WebUI.Models;
using EnterpriseResourcePlanner.WebUI.Utils;
using Machine.Fakes;
using Machine.Specifications;
using Machine.Specifications.Mvc;

namespace EnterpriseResourcePlanner.Tests.Unit.Controllers.Login
{
    public class When_logging_in_with_valid_credentials : WithSubject<AccountController>
    {
        protected static string TestUserName = "testuser";
        protected static string TestPassword = "testpassword";
        protected static LoginViewModel TestViewModel = new LoginViewModel();
        protected static ActionResult Result;

        Establish that = () =>
        {
            TestViewModel.UserName = TestUserName;
            TestViewModel.Password = TestPassword;
            The<IUserAccountService>().WhenToldTo(x => x.Login(TestUserName, TestPassword)).Return(true);
        };

        Because of = () =>
            Result = Subject.Index(TestViewModel);

        It should_ask_the_service_for_a_login_success = () =>
            The<IUserAccountService>().WasToldTo(x => x.Login(TestUserName, TestPassword)).OnlyOnce();

        It should_persist_the_authentication = () =>
            The<IAuthenticationPersister>().WasToldTo(x => x.SetAuthCookie(TestUserName, false)).OnlyOnce();

        It should_redirect_to_the_home_page_action = () =>
            Result.ShouldRedirectToAction<HomeController>(x => x.Index());
    }

    public class When_logging_in_with_invalid_credentials : WithSubject<AccountController>
    {
        protected static string TestUserName = "testuser";
        protected static string TestPassword = "testpassword";
        protected static LoginViewModel TestViewModel = new LoginViewModel();
        protected static ActionResult Result;

        Establish that = () =>
        {
            TestViewModel.UserName = TestUserName;
            TestViewModel.Password = TestPassword;
            The<IUserAccountService>().WhenToldTo(x => x.Login(TestUserName, TestPassword)).Return(false);
        };

        Because of = () =>
            Result = Subject.Index(TestViewModel);

        It should_ask_the_service_for_a_login_success = () =>
            The<IUserAccountService>().WasToldTo(x => x.Login(TestUserName, TestPassword)).OnlyOnce();

        It should_add_an_error_to_the_model_state = () =>
            Subject.ModelState.IsValid.ShouldBeFalse();

        It should_reload_the_same_view = () =>
            Result.ShouldBeAView().And().ViewName.ShouldEqual("Index");
    }
}
