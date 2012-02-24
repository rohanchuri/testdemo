using System;
using System.Collections.Generic;
using System.Text;
using MyBookShop.DAL;
using MyBookShop.Models;

namespace MyBookShop.BLL
{

    public static partial class UserStateManager
    {
        public static UserState AddUserState(UserState userState)
        {
            return UserStateService.AddUserState(userState);
        }

        public static void DeleteUserState(UserState userState)
        {
            UserStateService.DeleteUserState(userState);
        }

        public static void DeleteUserStateById(int id)
        {
            UserStateService.DeleteUserStateById(id);
        }

		public static void ModifyUserState(UserState userState)
        {
            UserStateService.ModifyUserState(userState);
        }
        
        public static IList<UserState> GetAllUserStates()
        {
            return UserStateService.GetAllUserStates();
        }

        public static UserState GetUserStateById(int id)
        {
            return UserStateService.GetUserStateById(id);
        }

        public static UserState GetDefaultUserState()
        {
			return GetUserStateById(1);
        }
    }
}
