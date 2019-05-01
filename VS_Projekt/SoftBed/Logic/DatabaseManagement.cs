using System;
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

        //Not working yet, connectionString has to be assigned first
        private SqlConnection Connect()
        {
            SqlConnection connection;
            String connectionString = null;

            connection = new SqlConnection(connectionString);

            return connection;
        }


        private bool ExecuteQuery()
        {
            SqlConnection connection = Connect();
            SqlCommand command = null;
            String query = null;

            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

            return false;
        }

        public User GetUser(string userName)
        {

            return null;
        }

        public bool UserAnlegen(User user)
        {

            return false;
        }

        public bool UserLoeschen(string userName)
        {

            return false;
        }

        public Patient GetPatient(string versicherungsNummer)
        {

            return null;
        }

        public bool PatientAendern(Patient patient)
        {

            return false;
        }

        public bool PatientLoeschen(int versicherungsNummer)
        {

            return false;
        }

        public bool PatientAnlegen(Patient patient)
        {

            return false;
        }


        public Bettenbelegung GetBettenbelegung()
        {

            return null;
        }

        public Verlegungsliste GetVerlegungsliste()
        {

            return null;
        }

        public String GetPassendesBett()
        {

            return null;
        }



    }
}
