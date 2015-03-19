using EnterpriseResourcePlanner.Domain.UserManangement;

namespace EnterpriseResourcePlanner.Domain
{
    public class User : IPersistable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public LoginInformation LoginInformation { get; set; }
    }
}
