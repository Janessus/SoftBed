using System;
using Wrapperklassen;
using MySql.Data.MySqlClient;

namespace Logic
{
    public class DatabaseManagement : LogicController
    {
        private static DatabaseManagement _instance = null;

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


        //connects to the server specified in the connectionString
        //TODO set to private
        public MySqlConnection Connect()
        {
            /* Local
            string connectionString = "SERVER=192.168.178.88;" +
             
                                      "DATABASE=SoftBedDB;" +
                                      "UID=softbed;" +
                                      "PASSWORD=softbed;";
            */
            // Public
            string connectionString = "SERVER=sql7.freemysqlhosting.net;" +
                                      "DATABASE=sql7292983;" +
                                      "UID=sql7292983;" +
                                      "PASSWORD=qjsStyWinF;";

            MySqlConnection Connection = null;

            try
            {
                Connection = new MySqlConnection(connectionString);
            }
            catch (Exception e)
            {
                UncaughtExeption("CONNECT", e);
            }

            return Connection;
        }


        //executes the query that was passed as an argument, returns a MySqlDataReader Object if successful and null if not
        //TODO set to private
        public MySqlDataReader ExecuteQuery(String query, MySqlConnection Connection)
        {
            MySqlDataReader Reader = null;

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, Connection);
                Reader = cmd.ExecuteReader();
            }

            catch (MySqlException e)
            {
                if (e.HResult == -2147467259)
                    Console.WriteLine("Duplicate");
                else if (e.HResult == -2146232015)
                    Console.WriteLine("Not Existing");
                else
                {
                    UncaughtExeption("EXECUTE_QUERY", e);
                }
            }
            catch (Exception e)
            {
                UncaughtExeption("EXECUTE_QUERY", e);
            }

            return Reader;
        }

        //TODO set to private
        public bool ExecuteInsert(String query, MySqlConnection Connection)
        {
            try
            {
                Connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, Connection);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                if (e.HResult == -2147467259)
                    Console.WriteLine("ExecuteInsert: Duplicate " + query);
                else
                    Console.WriteLine("ExecuteInsert: " + e.HResult);

                Console.WriteLine("ExecuteInsert: " + e.Message);
            }
            catch (Exception e)
            {
                UncaughtExeption("EXECUTE UPDATE", e);
            }

            return false;
        }


        public Patient GetPatient(string versicherungsNummer)
        {
            Patient p = null;
            MySqlDataReader Reader = null;

            try
            {
                MySqlConnection Connection = Connect();
                Connection.Open();
                Reader = ExecuteQuery("SELECT VersicherungsNr, Vorname, Nachname, Geburtsdatum, StationsBezeichnung, Beschwerde, Aufnahmedatum, Geschlecht FROM Patient, Person WHERE VersicherungsNr=\"" + versicherungsNummer + "\" AND Patient.PersonID = Person.PersonID;", Connection);

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

                Connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("GetPatient: " + e.HResult);
                Console.WriteLine("GetPatient: " + e.Message);
                //UncaughtExeption("", e)
            }
            catch (Exception e)
            {
                if(e.HResult == -2146232015)
                    Console.WriteLine("Patient " + versicherungsNummer + " existiert nicht");
                else
                {
                    UncaughtExeption("GET PATIENT", e);
                }
            }
            
            return p;
        }


        public bool PatientAendern(Patient patient)
        {
            if(patient != null)
                try
                {
                    MySqlConnection Connection = Connect();
                    bool response = ExecuteInsert("UPDATE Patient SET StationsBezeichnung = \"" + patient.Station + "\", " + "Beschwerde = \"" +
                                 patient.Beschwerde + "\" WHERE VersicherungsNr = \"" + patient.Versicherungsnr + "\";", Connection);
                    Connection.Close();
                    return response;
                }
                catch (Exception e)
                {
                    UncaughtExeption("PATIENT ÄNDERN", e);
                }

            return false;
        }


        public bool PatientLoeschen(string versicherungsNummer)
        {
            try
            {
                MySqlConnection Connection = Connect();
                bool response = ExecuteInsert("DELETE FROM Patient WHERE VersicherungsNr = \"" + versicherungsNummer + "\";", Connection);
                Connection.Close();
                return response;
            }
            catch (Exception e)
            {
                UncaughtExeption("PATIENT LÖSCHEN", e);
                return false;
            }
        }


        public bool PatientAnlegen(Patient patient)
        {
            if (patient != null)
            {
                string query =
                    "INSERT INTO Patient(VersicherungsNr, PersonID, ZimmerNr, StationsBezeichnung, Bett, Beschwerde) " +
                    "VALUES(\"" + 
                    patient.Versicherungsnr + "\"," +                 // VersicherungsNr
                    "(SELECT Person.PersonID From Person " +          // PersonID
                    "WHERE " +                                        // *
                    "Vorname = \"" + patient.Vorname +                // *
                    "\" AND " +                                       // *
                    "Nachname = \"" + patient.Nachname + "\")," +     // *
                    "NULL" + ",\"" +                                  // ZimmerNr
                    patient.Station + "\"," +                         // Station
                    "\'F\'" + ",\"" +                                 // Bett
                    patient.Beschwerde + "\");";                      // Beschwerde

                try
                {
                    PersonAnlegen(patient);

                    MySqlConnection Connection = Connect();
                    bool response = ExecuteInsert(query, Connection);
                    Connection.Close();
                    return response;
                }
                catch (Exception e)
                {
                    UncaughtExeption("PATIENT ANLEGEN", e);
                }
            }
            return false;
        }


        private Person GeneratePerson(string vorname, string nachname)
        {
            Person p = new Person();
            p.Vorname = vorname;
            p.Nachname = nachname;

            return p;
        }


        public Verlegungsliste GetVerlegungsliste()
        {
            Verlegungsliste verlegungsliste = null;
            MySqlDataReader Reader = null;
            MySqlCommand Cmd = null;
            MySqlConnection Connection = null;

            try
            {
                Connection = Connect();
                Connection.Open();
                Cmd = Connection.CreateCommand();
                Cmd.CommandText = "SELECT p.PersonID, Vorname, Nachname, Von, Nach, Stempel FROM TransferListe t, Person p Where t.PersonID = p.PersonID;";
                Reader = Cmd.ExecuteReader();

                verlegungsliste = new Verlegungsliste();

                while (Reader.Read())
                {
                    VerlegungslistenItem item = new VerlegungslistenItem();
                    Person p = new Person();
                    p.Vorname = Reader.GetString(1);
                    p.Nachname = Reader.GetString(2);

                    item.Person = p;
                    item.Von = Reader.GetString(3);
                    item.Nach = Reader.GetString(4);
                    item.Stempel = DateTime.Parse(Reader.GetString(5));

                    verlegungsliste.Transferliste.Add(item);
                }

                //Cmd.Dispose();
                //Connection.Close();

                return verlegungsliste;
            }
            catch (Exception e)
            {
                Console.WriteLine("GetVerlegungsliste ERROR HResult: " + e.HResult);
                //Console.WriteLine(e);
                //Cmd.Dispose();
                //Connection.Close();
                UncaughtExeption("GET VERLEGUNGSLISTE", e);
                return null;
            }
        }

        public bool PersonAnlegen(Patient p)
        {
            string query = "INSERT INTO Person(Vorname, Nachname, Geschlecht, Geburtsdatum) " +
                           "VALUES(\"" + p.Vorname + "\", \"" + p.Nachname + "\", \"" + p.Geschlecht + "\", Date(\"" + p.Gebdat.Year + "-" + p.Gebdat.Month + "-" + p.Gebdat.Day + "\"));";

            Console.WriteLine("DEBUG " + query);
            Console.WriteLine("Patient.Gebdat = " + p.Gebdat.ToString());

            try
            {
                MySqlConnection Connection = Connect();
                bool response = ExecuteInsert(query, Connection);
                Connection.Close();
                return response;
            }
            catch (Exception e)
            {
                UncaughtExeption("PERSON ANLEGEN", e);
                return false;
            }
        }

        public bool PersonAnlegen(string Vorname, string Nachname)
        {
            string query = "INSERT INTO Person(Vorname, Nachname) " +
                           "VALUES(\"" + Vorname + "\", \"" + Nachname + "\");";

            try
            {
                MySqlConnection Connection = Connect();
                bool response = ExecuteInsert(query, Connection);
                Connection.Close();
                return response;
            }
            catch (Exception e)
            {
                UncaughtExeption("PERSON ANLEGEN", e);
                return false;
            }
        }


        public User GetUser(string userName)
        {
            MySqlDataReader Reader = null;

            try
            {
                MySqlConnection Connection = Connect();
                Connection.Open();
                Reader = ExecuteQuery("SELECT u.Benutzername, u.Rechte, u.Passwort, p.Vorname, p.Nachname FROM Users u, Person p WHERE u.PersonID = p.PersonID AND u.Benutzername = \"" + userName + "\";", Connection);

                if (Reader.Read())
                {
                    string rechte = Reader.GetString(1);
                    string passwort = Reader.GetString(2);
                    string vorname = Reader.GetString(3);
                    string nachname = Reader.GetString(4);

                    Connection.Close();
                    return new User(vorname, nachname, rechte, userName, passwort);
                }

                Connection.Close();
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("GetUser ERROR HResult: " + e.HResult);
                UncaughtExeption("GET USER", e);
                return null;
            }
            
        }


        public bool UserAnlegen(User user)
        {
            string query = "INSERT INTO Users(Benutzername, PersonID, Rechte, Passwort) Values(\"" + user.Benutzername + 
                           "\", (SELECT PersonID FROM Person WHERE Vorname = \"" + user.Vorname + "\" AND Nachname = \"" + user.Nachname + "\"), \"" +
                           user.Rechte + "\", \"" +
                           user.Passwort + "\"" +
                           ")";

            try
            {
                MySqlConnection Connection = Connect();
                bool response = ExecuteInsert(query, Connection);
                Connection.Close();
                return response;
            }
            catch (Exception e)
            {
                UncaughtExeption("USER ANLEGEN", e);
                return false;
            }
        }


        public bool UserLoeschen(string userName)
        {
            try
            {
                MySqlConnection Connection = Connect();
                bool response = ExecuteInsert("DELETE FROM Users WHERE Benutzername = \"" + userName + "\";", Connection);
                Connection.Close();
                return response;
            }
            catch (Exception e)
            {
                UncaughtExeption("USER LÖSCHEN", e);
                return false;
            }
        }


        public Bettenbelegung GetBettenbelegung()
        {
            Bettenbelegung belegung = null;
            try
            {
                belegung = new Bettenbelegung();

                MySqlConnection Connection = Connect();
                Connection.Open();

                MySqlDataReader reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Gynäkologie\";", Connection);
                if(reader.Read())
                    belegung.Gynaekologie = reader.GetInt32(0);
                reader.Close();

                reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Innere Medizin\";", Connection);
                if (reader.Read())
                    belegung.Innere = reader.GetInt32(0);
                reader.Close();

                reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Onkologie\";", Connection);
                if (reader.Read())
                    belegung.Onkologie = reader.GetInt32(0);
                reader.Close();

                reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Orthopädie\";", Connection);
                if (reader.Read())
                    belegung.Orthopaedie = reader.GetInt32(0);
                reader.Close();

                reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Pädiatrie\";", Connection);
                if (reader.Read())
                    belegung.Paediatrie = reader.GetInt32(0);
                reader.Close();

                Connection.Close();
            }
            catch (Exception e)
            {
                UncaughtExeption("GET BETTENBELEGUNG", e);
                return null;
            }
            
            return belegung;
        }

        public string GetPassendesBett(string Station, Patient patient)
        {
            
            return null;
        }


        // ################################################## DEV FUNCTIONS ################################################## //


        public void TestDB()
        {
            try
            {
                /*

                User u = new User("Janes", "Heuberger", "Praktikant", "JanesPraktikant", "PW");
                UserAnlegen(u);

                PersonAnlegen("Albert", "Einstein");
                PatientAnlegen(new Patient("Pa2lo", "Esscoabar", "213350", DateTime.Parse("1937-10-04"), "Innere Medizin", "Überdosis + Stichwunden", DateTime.Now, "M"));
                PatientAnlegen(new Patient("Maadx", "Musatedrmann", "442", DateTime.Parse("1937-10-04"), "Orthopädie", "Ihm tut irgendwas weh", DateTime.Now, "M"));
                GetPatient("12345");
                //PatientLoeschen("442");

                User u = GetUser("Janessus");
                Console.WriteLine(u.Rechte);

                //PatientAendern(GetPatient("12345"));
                Console.WriteLine("Betten Belegt: " + GetBettenbelegung().Gesamt());

                //UncaughtExeption("test", new Exception("test"));


                //Patient p1 = GetPatient("12345");
                //PrintPatient(p1);

                //Connection.Close();
                //Connection.Dispose();

                //User u = GetUser("Janessus");
                //Console.WriteLine(u.Rechte);

                //UserLoeschen("Janessus");

                //Connection.Close();
                */
            }
            catch (Exception e)
            {
                UncaughtExeption("TESTDB_EXCEPTION", e);
            }
        }

        public void UncaughtExeption(string callerName, Exception e)
        {
            Console.Error.WriteLine("\nUnhandled Exception at " + callerName);
            Console.Error.WriteLine(e.Message);
        }


        public static void PrintPatient(Patient p)
        {
            Console.WriteLine();
            Console.WriteLine("Patient:");

            if (p != null)
            {
                Console.WriteLine("VersicherungsNr = " + p.Versicherungsnr);
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
    }
}
