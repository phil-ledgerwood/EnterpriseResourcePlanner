namespace EnterpriseResourcePlanner.Service
{
    public interface IUserAccountService
    {
        bool Login(string userName, string password);
    }
}
