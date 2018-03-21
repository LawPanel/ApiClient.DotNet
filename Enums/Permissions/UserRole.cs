namespace LawPanel.ApiClient.Enums.Permissions
{
    public enum UserRole
    {
        FirmUser = 0,
        ClientUser = 2, 
        Admin = 8,
        System = 16
    }


    // I added this method to keep untoched DB and existing users
    public static class UserRoleExtensions
    {

        public static int GetUserRoleWeight(this UserRole userRole)
        {
            switch (userRole)
            {
                case UserRole.System: return 1000;
                case UserRole.Admin: return 999;
                case UserRole.FirmUser: return 998;
                case UserRole.ClientUser: return 997;
            }

            return -1;
        }

    }
}
