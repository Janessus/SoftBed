using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class UserManagement : LogicController
    {
        private static UserManagement _instance = null; 
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

    }
}
