using System;
using System.Collections.Generic;
using System.Text;
using Wrapperklassen;

namespace Logic
{
    public class UserManagement : LogicController
    {
        private static UserManagement _instance = null;
        private static User _currentUser;

        public static User CurrentUser { get => _currentUser; set => _currentUser = value; }

        private UserManagement()
        {
        }

        public static UserManagement GetInstance()
        {
            if(_instance == null)
            {
                _instance = new UserManagement();
            }
            return _instance;
        }

        public bool UserAnlegen(User newUser)
        {
            return false;
        }

        public bool UserLöschen(string userName)
        {
            return false;
        }

        public bool UserAendern(string userName, User newUser)
        {
            return false;
        }

        public bool UserLogin(string userName, string password)
        {
            return false;
        }


    }
}
