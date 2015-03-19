using System.Web.Mvc;
using EnterpriseResourcePlanner.WebUI.Controllers;
using Machine.Fakes;
using Machine.Specifications;
using Machine.Specifications.Mvc;

namespace EnterpriseResourcePlanner.Tests.Unit.Controllers.Login
{
    public class When_requesting_login_page : WithSubject<AccountController>
    {
        protected static ActionResult Result;

        Because of = () =>
            Result = Subject.Index();

        It should_return_the_index_view = () =>
            Result.ShouldBeAView().And().ViewName.ShouldEqual("Index");
    }
}
