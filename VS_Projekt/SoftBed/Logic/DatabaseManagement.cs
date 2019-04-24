using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Wrapperklassen;

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


        private SqlConnection Connect()
        {

        }

        private bool ExecuteQuery()
        {

        }

        public User GetUser()
        {

        }

        public bool UserAnlegen()
        {

        }

        public bool UserLoeschen()
        {

        }

        public Patient GetPatient()
        {

        }

        public bool PatientAendern()
        {

        }

        public bool PatientLoeschen()
        {

        }

        public bool PatientAnlegen()
        {

        }


        public Bettenbelegung GetBettenbelegung()
        {

        }

        public Verlegungsliste GetVerlegungsliste()
        {

        }

        public String GetPassendesBett()
        {

        }








    }
}
