using System.Web.Security;


namespace EnterpriseResourcePlanner.WebUI.Utils
{
    internal class AuthenticationPersister : IAuthenticationPersister
    {
        public void SetAuthCookie(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }
    }
}