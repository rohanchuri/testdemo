using System;
using System.Collections.Generic;
using System.Text;
using MyBookShop.DAL;
using MyBookShop.Models;

namespace MyBookShop.BLL
{

    public static class UserManager
    {
        public static User AddUser(User user)
        {
            if (user.UserState == null)
            {
                user.UserState = UserStateManager.GetDefaultUserState();
            }

            if (user.UserRole == null)
            {
                user.UserRole = UserRoleManager.GetDefaultUserRole();
            }

            return UserService.AddUser(user);
        }

        public static void DeleteUser(User user)
        {
            UserService.DeleteUser(user);
        }

        public static void DeleteUserById(int id)
        {
            UserService.DeleteUserById(id);
        }

        public static void ModifyUser(User user)
        {
            UserService.ModifyUser(user);
        }

        public static IList<User> GetAllUsers()
        {
            return UserService.GetAllUsers();
        }

        public static User GetUserById(int id)
        {
            return UserService.GetUserById(id);
        }

        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="loginId">��¼��</param>
        /// <param name="loginPwd">��¼����</param>
        /// <param name="validUser">����û�</param>
        /// <returns></returns>
        public static bool Login(string loginId, string loginPwd, out User validUser)
        {
            User user = UserService.GetUserByLoginId(loginId);
            if (user == null)
            {
                //�û��������� 
                validUser = null;
                return false;
            }

            if (user.LoginPwd == loginPwd)
            {
                validUser = user;
                return true;
            }
            else
            {
                //�������
                validUser = null;
                return false;
            }
        }
        /// <summary>
        /// ע�����û�
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool Register(User user)
        {
            if (LoginIdExists(user.LoginId))
            {
                return false;
            }
            else
            {
                AddUser(user);
                return true;
            }
        }
        /*
        /// <summary>
        /// ����Ա��¼
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="loginPwd"></param>
        /// <param name="validUser"></param>
        /// <returns></returns>
        public static bool AdminLogin(string loginId, string loginPwd, out User validUser)
        {
            User user=UserService.GetAdminUserByLoginId(loginId);

            if (user == null)
            {
                //�û��������� 
                validUser = null;
                return false;
            }

            if (user.LoginPwd == loginPwd)
            {
                validUser = user;
                return true;
            }
            else
            {
                //�������
                validUser = null;
                return true;
            }
        }
         */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static bool LoginIdExists(string loginId)
        {
            if (UserService.GetUserByLoginId(loginId) == null)
                return false;
            return true;
        }

        /// <summary>
        /// �޸Ļ�����Ϣ
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Phone"></param>
        /// <param name="Address"></param>
        /// <param name="Mail"></param>
        /// <param name="Id"></param>
        public static void ModifyBasicInfo( string Name, string Phone, string Address, string Mail,int Id)
        {
            User user = UserService.GetUserById(Id);
            user.Name = Name;
            user.Phone = Phone;
            user.Address = Address;
            user.Mail = Mail;
            UserService.ModifyUser(user);
        }

    }
}
