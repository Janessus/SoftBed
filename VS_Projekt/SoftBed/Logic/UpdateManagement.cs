using System;
using System.Collections.Generic;
using System.Text;
using Wrapperklassen;

namespace Logic
{
    class UpdateManagement : LogicController
    {
        public static UpdateManagement _instance = null;

        private UpdateManagement()
        {

        }

        public static UpdateManagement GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UpdateManagement();
            }
            return _instance;
        }

        public Patient GetPatient(int versNr)
        {
            return null;
        }

        public User GetUser(string userName)
        {
            return null;
        }

        public Bettenbelegung GetCurrentBettenbelegung()
        {
            return null;
        }




    }
}
