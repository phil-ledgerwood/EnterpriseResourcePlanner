using System.Collections.Generic;
using System.Linq;
using EnterpriseResourcePlanner.Data.Repository;
using EnterpriseResourcePlanner.Domain;
using EnterpriseResourcePlanner.Domain.UserManangement;
using EnterpriseResourcePlanner.Service;
using Machine.Fakes;
using Machine.Specifications;

namespace EnterpriseResourcePlanner.Tests.Unit.Services.Login
{
    public class When_checking_valid_login_credentials_ : WithSubject<UserAccountService>
    {
        protected static string TestUserName = "testuser";
        protected static string TestPassword = "testpassword";
        protected static User TestUser = new User();
        protected static bool Result;

        Establish that = () =>
        {
            TestUser.LoginInformation = new LoginInformation {UserName = TestUserName, Password = TestPassword};
            The<IRepository<User>>().WhenToldTo(x => x.GetAll()).Return(new [] {TestUser}.AsQueryable());
        };

        Because of = () =>
            Result = Subject.Login(TestUserName, TestPassword);

        It should_ask_for_a_matching_user = () =>
            The<IRepository<User>>().WasToldTo(x => x.GetAll()).OnlyOnce();

        It should_return_true = () =>
            Result.ShouldBeTrue();
    }

    public class When_checking_invalid_login_credentials_ : WithSubject<UserAccountService>
    {
        protected static string TestUserName = "testuser";
        protected static string TestPassword = "testpassword";
        protected static User TestUser = new User();
        protected static bool Result;

        Establish that = () =>
        {
            TestUser.LoginInformation = new LoginInformation { UserName = TestUserName + "not", Password = TestPassword + "not" };
            The<IRepository<User>>().WhenToldTo(x => x.GetAll()).Return(new[] { TestUser }.AsQueryable());
        };

        Because of = () =>
            Result = Subject.Login(TestUserName, TestPassword);

        It should_ask_for_a_matching_user = () =>
            The<IRepository<User>>().WasToldTo(x => x.GetAll()).OnlyOnce();

        It should_return_false = () =>
            Result.ShouldBeFalse();
    }
}
