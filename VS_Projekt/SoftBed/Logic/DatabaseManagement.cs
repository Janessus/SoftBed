using System;
using Wrapperklassen;
using MySql.Data.MySqlClient;

namespace Logic
{
    public class DatabaseManagement : LogicController
    {
        private static DatabaseManagement _instance = null;
        private MySqlDataReader reader;
        private MySqlConnection connection;

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

        //returns the connection string (address, credentials etc)
        static private string GetConnectionString()
        {
            return "SERVER=192.168.178.88;" +
                   "DATABASE=SoftBedDB;" +
                   "UID=softbed;" +
                   "PASSWORD=softbed;";
        }

        //connects to the server specified in the connectionString
        public void Connect()
        {
            String connectionString = GetConnectionString();
            connection = new MySqlConnection(connectionString);
        }

        //executes the query that was passed as an argument, returns true if successful
        private bool ExecuteQuery(String query)
        {
            try
            {
                Connect();
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
            return true;
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
            Patient p = null;

            ExecuteQuery("SELECT VersicherungsNr, Vorname, Nachname, Geburtsdatum, StationsBezeichnung, Beschwerde, Aufnahmedatum, Geschlecht FROM Patient, Person WHERE VersicherungsNr=" + versicherungsNummer + ";");

            if (reader.Read())
            {
                string vorname = reader.GetString(1);
                string nachname = reader.GetString(2);
                DateTime gebdat = DateTime.Parse(reader.GetString(3));
                string station = reader.GetString(4);
                string beschwerde = reader.GetString(5);
                DateTime aufnahmedatum = DateTime.Parse(reader.GetString(6));
                string geschlecht = reader.GetString(7);

                p = new Patient(vorname, nachname, versicherungsNummer, gebdat, station, beschwerde, aufnahmedatum, geschlecht);
            }
            return p;
        }

        public bool PatientAendern(Patient patient)
        {

            return false;
        }

        public bool PatientLoeschen(string versicherungsNummer)
        {

            return false;
        }

        public bool PatientAnlegen(Patient patient)
        {
            if (patient != null)
            {
                string query =
                    "INSERT INTO Patient(VersicherungsNr, PersonID, ZimmerNr, StationsBezeichnung, Bett, Beschwerde) " +
                    "VALUES(" +
                    patient.Versicherungsnr + "," +            // VersicherungsNr
                    "(Select Person.PersonID From Person " +   // PersonID
                    "WHERE " +                                 // *
                    "Vorname = " + patient.Vorname +           // *
                    " AND " +                                  // *
                    "Nachname = " + patient.Nachname + ")," +  // *
                    "null" + "," +                             // ZimmerNr
                    patient.Station + "," +                    // Station
                    "null" + "," +                             // Bett
                    patient.Beschwerde + ");";                 // Beschwerde

                return ExecuteQuery(query);
            }

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

        public string GetPassendesBett()
        {

            return null;
        }



        // ################################################## DEV FUNCTIONS ##################################################


        public void TestDB()
        {
            //PrintResults(ExecuteQuery("insert into Test Values(\"testdatentestdatenTestDaten\");"));
            Patient p1 = GetPatient("12345");
            PrintPatient(p1);

            Patient p2 = GetPatient("12335");
            PrintPatient(p2);

            PatientAnlegen(new Patient("Pablo", "Escobar", "21350", DateTime.Parse("1937-10-04"), "Innere Medizin",
                "Überdosis + Stichwunden", DateTime.Now, "M"));

            PrintPatient(GetPatient("21350"));

            reader.Close();
            connection.Close();
        }


        public void PrintPatient(Patient p)
        {
            Console.WriteLine();
            Console.WriteLine("Patient:");

            if (p != null)
            {
                Console.WriteLine("Vorname = " + p.Vorname);
                Console.WriteLine("Nachname = " + p.Nachname);
                Console.WriteLine("GebDat = " + p.Gebdat.ToString());
                Console.WriteLine("Station = " + p.Station);
                Console.WriteLine("Beschwerde = " + p.Beschwerde);
                Console.WriteLine("AufnahmeDatum = " + p.Aufnahmedatum.ToString());
                Console.WriteLine("Geschlecht = " + p.Geschlecht);
            }
            else
                Console.WriteLine("NULL");
        }


        // prints the results of eg. select * from Test
        // usage -> PrintResults(ExecuteQuery("select * from Test"));
        public void PrintResults(bool flag)
        {
            while (flag && reader.Read())
            {
                string row = "";
                for (int i = 0; i < reader.FieldCount; i++)
                    row += reader.GetValue(i).ToString() + ", ";

                Console.WriteLine(row);
            }
        }
    }
}
