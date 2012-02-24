using System;
using System.Collections.Generic;
using System.Text;
using MyBookShop.DAL;
using MyBookShop.Models;

namespace MyBookShop.BLL
{

    public static class UserRoleManager
    {
        public static UserRole AddUserRole(UserRole userRole)
        {
            return UserRoleService.AddUserRole(userRole);
        }

        public static void DeleteUserRole(UserRole userRole)
        {
            UserRoleService.DeleteUserRole(userRole);
        }

        public static void DeleteUserRoleById(int id)
        {
            UserRoleService.DeleteUserRoleById(id);
        }

		public static void ModifyUserRole(UserRole userRole)
        {
            UserRoleService.ModifyUserRole(userRole);
        }
        
        public static IList<UserRole> GetAllUserRoles()
        {
            return UserRoleService.GetAllUserRoles();
        }

        public static UserRole GetUserRoleById(int id)
        {
            return UserRoleService.GetUserRoleById(id);
        }

        public static UserRole GetDefaultUserRole()
        {
			return GetUserRoleById(1);
        }
    }
}
