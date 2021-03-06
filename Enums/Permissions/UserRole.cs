﻿namespace LawPanel.ApiClient.Enums.Permissions
{
    public enum UserRole
    {
        InvalidRole = -1,
        FirmUser = 0,
        ClientUser = 2, 
        AgentUser = 4,
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
                case UserRole.AgentUser: return 997;
                case UserRole.ClientUser: return 996;

                case UserRole.InvalidRole: return -1;
            }

            return -1;
        }

    }
}
