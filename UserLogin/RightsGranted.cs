using System.Collections.Generic;

namespace UserLogin
{
    public static class RightsGranted
    {
        private static Dictionary<UserRoles, List<RoleRight>> roleToRights = new Dictionary<UserRoles, List<RoleRight>>
        {
            {UserRoles.ADMIN, new List<RoleRight>(){RoleRight.OBSERVER, RoleRight.REDACTOR, RoleRight.LOGG_ACCESS}},
            {UserRoles.INSPECTOR, new List<RoleRight>(){RoleRight.OBSERVER, RoleRight.REDACTOR}},
            {UserRoles.STUDENT, new List<RoleRight>(){RoleRight.OBSERVER}}
        } ;

        public static Dictionary<UserRoles, List<RoleRight>> RoleToRights
        {
            get => roleToRights;
            set => roleToRights = value;
        }
    }
}