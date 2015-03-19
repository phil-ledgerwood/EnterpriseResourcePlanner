namespace EnterpriseResourcePlanner.WebUI.Utils
{
    public interface IAuthenticationPersister
    {
        void SetAuthCookie(string userName, bool createPersistentCookie);
    }
}
