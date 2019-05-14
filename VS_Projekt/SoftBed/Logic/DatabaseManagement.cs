using System;
using Wrapperklassen;
using MySql.Data.MySqlClient;

namespace Logic
{
    public class DatabaseManagement : LogicController
    {
        private static DatabaseManagement _instance = null;
        private MySqlDataReader _reader;
        private MySqlConnection _connection;
        private MySqlCommand _cmd;

        public MySqlDataReader Reader { get => _reader; set => _reader = value; }
        public MySqlConnection Connection { get => _connection; set => _connection = value; }
        public MySqlCommand Cmd { get => _cmd; set => _cmd = value; }
        public static DatabaseManagement Instance { get => _instance; set => _instance = value; }


        private DatabaseManagement(){}
        

        public static DatabaseManagement GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DatabaseManagement();
            }
            return Instance;
        }


        //returns the Connection string (address, credentials etc)
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
            try
            {
                Connection = new MySqlConnection(GetConnectionString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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

        //executes the query that was passed as an argument, returns true if successful
        private bool ExecuteQuery(String query)
        {
            try
            {
                Connect();
                Connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, Connection);
                Reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
            return true;
        }


        public Patient GetPatient(string versicherungsNummer)
        {
            Patient p = null;

            try
            {
                ExecuteQuery("SELECT VersicherungsNr, Vorname, Nachname, Geburtsdatum, StationsBezeichnung, Beschwerde, Aufnahmedatum, Geschlecht FROM Patient, Person WHERE VersicherungsNr=" + versicherungsNummer + ";");

                if (Reader.Read())
                {
                    string vorname = Reader.GetString(1);
                    string nachname = Reader.GetString(2);
                    DateTime gebdat = DateTime.Parse(Reader.GetString(3));
                    string station = Reader.GetString(4);
                    string beschwerde = Reader.GetString(5);
                    DateTime aufnahmedatum = DateTime.Parse(Reader.GetString(6));
                    string geschlecht = Reader.GetString(7);

                    p = new Patient(vorname, nachname, versicherungsNummer, gebdat, station, beschwerde, aufnahmedatum, geschlecht);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return p;
        }


        public bool PatientAendern(Patient patient)
        {
            try
            {
                ExecuteQuery("UPDATE Patient SET StationsBezeichnung = " + patient.Station + ", " + "Beschwerde = " +
                             patient.Beschwerde + "WHERE VersicherungsNr = " + patient.Versicherungsnr + ";");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public bool PatientLoeschen(string versicherungsNummer)
        {
            try
            {
                ExecuteQuery("DELETE FROM Patient WHERE VersicherungsNr = " + versicherungsNummer + ";");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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


        public Person GetPerson(string vorname, string nachname)
        {
            Person p = new Person();
            p.Vorname = vorname;
            p.Nachname = nachname;

            return p;
        }


        public Verlegungsliste GetVerlegungsliste()
        {
            Verlegungsliste verlegungsliste = null;

            try
            {
                Connect();
                Cmd = Connection.CreateCommand();
                Cmd.CommandText = "SELECT p.PersonID, Vorname, Nachname, Von, Nach, Stempel FROM TransferListe t, Person p Where t.PersonID = p.PersonID;";
                Reader = Cmd.ExecuteReader();

                verlegungsliste = new Verlegungsliste();

                while (Reader.Read())
                {
                    VerlegungslistenItem item = new VerlegungslistenItem();
                    item.Person = GetPerson(Reader.GetString(1), Reader.GetString(2));
                    item.Von = Reader.GetString(3);
                    item.Nach = Reader.GetString(4);
                    item.Stempel = DateTime.Parse(Reader.GetString(5));

                    verlegungsliste.Transferliste.Add(item);
                }

                return verlegungsliste;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Bettenbelegung GetBettenbelegung()
        {

            return null;
        }

        public string GetPassendesBett()
        {

            return null;
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

            Reader.Close();
            Connection.Close();
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
            while (flag && Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                    row += Reader.GetValue(i).ToString() + ", ";

                Console.WriteLine(row);
            }
        }
    }
}
