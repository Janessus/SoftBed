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
                                      "DATABASE=sql7294766;" +
                                      "UID=sql7294766;" +
                                      "PASSWORD=jy3wzdVUHg;";

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
                if (e.HResult == -2146232015)
                    Console.WriteLine("EXECUTE_QUERY Not Existing");
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
            catch (Exception e)
            {
                UncaughtExeption("EXECUTE INSERT", e);
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
            catch (Exception e)
            {
                UncaughtExeption("GET PATIENT", e);
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


        public bool PatientAnlegen(Patient patient, string zimmerDst)
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

                    query =
                        "INSERT INTO TransferListe(PersonID, Von, Nach) VALUES((SELECT PersonID FROM Person WHERE Vorname = \"" +
                        patient.Vorname + "\" AND Nachname = \"" + patient.Nachname + "\"), " + "\"NULL\"" + ", \"" + zimmerDst + "\");";

                    var tmp = ExecuteInsert(query, Connection);

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
            Verlegungsliste verlegungsliste = new Verlegungsliste();
            MySqlDataReader Reader = null;
            MySqlConnection Connection = null;
            string query = "SELECT p.PersonID, p.Vorname, p.Nachname, t.Von, t.Nach, t.Stempel FROM TransferListe t, Person p Where t.PersonID = p.PersonID;";

            try
            {
                Connection = Connect();
                Connection.Open();
                Reader = ExecuteQuery(query, Connection);

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
                Connection.Close();   
            }
            catch (Exception e)
            {
                UncaughtExeption("GET VERLEGUNGSLISTE", e);
            }

            return verlegungsliste;
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
                UncaughtExeption("GET USER", e);
                return null;
            }
        }


        public bool UserAnlegen(User user)
        {
            string InsertQuery = "INSERT INTO Users(Benutzername, PersonID, Rechte, Passwort) Values(\"" + user.Benutzername + 
                           "\", (SELECT PersonID FROM Person WHERE Vorname = \"" + user.Vorname + "\" AND Nachname = \"" + user.Nachname + "\"), \"" +
                           user.Rechte + "\", \"" +
                           user.Passwort + "\"" +
                           ")";

            string CheckPersonQuery = "select count(*) " +
                                      "from Person p " +
                                      "where p.Vorname = \"" + user.Vorname + "\" " +
                                      "and p.Nachname = \"" + user.Nachname + "\";";

            try
            {
                MySqlConnection Connection = Connect();
                Connection.Open();

                MySqlDataReader reader = ExecuteQuery(CheckPersonQuery, Connection);

                if (reader.Read())
                {
                    short count = reader.GetInt16(0);
                    Connection.Close();

                    if (count == 0)
                    {
                        PersonAnlegen(user.Vorname, user.Nachname);
                    }
                }

                Connection = Connect();
                bool response = ExecuteInsert(InsertQuery, Connection);
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

                reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Intensivstation\";", Connection);
                if (reader.Read())
                    belegung.Intensiv = reader.GetInt32(0);
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

        //Potential Bugs!
        //looks for a room with 1 person in it and matches the gender, if no room with 1 person is available search for empty rooms
        public string GetPassendesBett(string Station, Patient patient)
        {
            string Bett = "NULL";
            string stationKurz = "NULL";
            int zimmerNr = 0;
            bool found = false;

            switch (Station)
            {
                case "Gynäkologie":
                    stationKurz = "G";
                    break;

                case "Innere Medizin":
                    stationKurz = "IM";
                    break;

                case "Onkologie":
                    stationKurz = "On";
                    break;

                case "Orthopädie":
                    stationKurz = "Or";
                    break;

                case "Pädiatrie":
                    stationKurz = "P";
                    break;

                case "Intensivstation":
                    stationKurz = "Is";
                    break;
                default:
                    Console.WriteLine("Ungültige Station");
                    break;
            }

            //Select all rooms with exactly 1 person in it
            string query = "select z.ZimmerNr, z.StationsBezeichnung, p.VersicherungsNr, pe.Geschlecht, p.Bett, pe.Geburtsdatum " +
                           "from Zimmer z, Patient p, Person pe " +
                           "where z.ZimmerNr = p.ZimmerNr " +
                           "and z.StationsBezeichnung = p.StationsBezeichnung " +
                           "and z.StationsBezeichnung = \"" + Station + "\" " +
                           "and pe.PersonID = p.PersonID " +
                           "group by z.ZimmerNr having count(z.ZimmerNr) < 2; ";

            MySqlConnection connection = Connect();
            connection.Open();
            MySqlDataReader reader = ExecuteQuery(query, connection);

            while (reader.Read())
            {
                //Match Geschlecht
                if (reader.GetChar(3).ToString().ToLower().Equals(patient.Geschlecht.ToLower()))
                {
                    zimmerNr = reader.GetInt32(0);

                    if (reader.GetString(4).Equals("T"))
                        Bett = "F";
                    else
                        Bett = "T";

                    found = true;
                    break;
                }
            }

            connection.Close();

            //Select all empty rooms from the given station
            if (!found)
            {
                query = "select z.ZimmerNr, z.StationsBezeichnung " +
                        "from Zimmer z " +
                        "where not exists " +
                        "(" +
                            "select * " +
                            "from Patient, Zimmer " +
                            "where Patient.ZimmerNr = z.ZimmerNr " +
                            "and Patient.StationsBezeichnung = z.StationsBezeichnung" +
                        ") " +
                        "and z.StationsBezeichnung = \"" + Station + "\";";

                connection = Connect();
                connection.Open();
                reader = ExecuteQuery(query, connection);
                if (reader.Read())
                {
                    zimmerNr = reader.GetInt32(0);
                    Bett = "F";
                }
            }

            string result = stationKurz + "-" + zimmerNr + "-" + Bett;
            connection.Close();
            return result;
        }


        // ################################################## DEV FUNCTIONS ################################################## //


        public void TestDB()
        {
            try
            {
                Patient p = new Patient();
                p.Geschlecht = "w";

                Console.WriteLine(GetPassendesBett("Gynäkologie", p));


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
