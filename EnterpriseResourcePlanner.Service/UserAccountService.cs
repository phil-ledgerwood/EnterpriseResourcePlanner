using System.Linq;
using EnterpriseResourcePlanner.Data.Repository;
using EnterpriseResourcePlanner.Domain;

namespace EnterpriseResourcePlanner.Service
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IRepository<User> _users; 

        public UserAccountService(IRepository<User> users)
        {
            _users = users;
        }

        public bool Login(string userName, string password)
        {
            var foundUser =
                _users.GetAll()
                    .SingleOrDefault(
                        user => user.LoginInformation.UserName == userName && user.LoginInformation.Password == password);

            return foundUser != null;
        }
    }
}
