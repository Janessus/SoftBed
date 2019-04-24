using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class DatabaseManagement
    {
        private static DatabaseManagement _instance = null;

        private DatabaseManagement()
        {

        }

        public static DatabaseManagement GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseManagement();
            }
            return _instance;
        }


    }
}
