using System;
using System.Collections.Generic;
using Wrapperklassen;
using MySql.Data.MySqlClient;

namespace Logic
{
    public class DatabaseManagement : LogicController
    {
        private static DatabaseManagement _instance = null;

        public static DatabaseManagement Instance { get => _instance; set => _instance = value; }

        private DatabaseManagement(){}

        private bool DebugMode = true;

        public static DatabaseManagement GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DatabaseManagement();
            }
            return Instance;
        }


        //connects to the server specified in the connectionString
        private MySqlConnection Connect()
        {
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
        //"select" statements only
        private MySqlDataReader ExecuteQuery(String query, MySqlConnection Connection)
        {
            MySqlDataReader Reader = null;

            if(DebugMode)
                Console.WriteLine("EXECUTE QUERY: " + query);

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, Connection);
                Reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                UncaughtExeption("EXECUTE_QUERY", e);
            }

            return Reader;
        }

        //Execute a query that does not return a table but modifies one
        //Insert, Update, Delete ...
        private bool ExecuteInsert(String query, MySqlConnection Connection)
        {
            if (DebugMode)
                Console.WriteLine("EXECUTEINSERT: " + query);
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
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }

            return false;
        }


        public Patient GetPatient(string versicherungsNummer)
        {
            Patient p = null;
            MySqlDataReader Reader = null;
            MySqlConnection Connection = null;

            try
            {
                Connection = Connect();
                Connection.Open();
                Reader = ExecuteQuery("SELECT VersicherungsNr, Vorname, Nachname, Geburtsdatum, StationsBezeichnung, Sollstation, Aufnahmedatum, Geschlecht ,Bett, ZimmerNr " +
                                      "FROM Patient, Person " +
                                      "WHERE VersicherungsNr = \"" + versicherungsNummer + "\" " +
                                      "AND Patient.PersonID = Person.PersonID;", Connection);

                if (Reader.Read())
                {
                    string vorname = Reader.GetString(1);
                    string nachname = Reader.GetString(2);
                    DateTime gebdat = DateTime.Parse(Reader.GetString(3));
                    string station = Reader.GetString(4);
                    string sollstation = Reader.GetString(5);
                    DateTime aufnahmedatum = DateTime.Parse(Reader.GetString(6));
                    string geschlecht = Reader.GetString(7);
                    p = new Patient(vorname, nachname, versicherungsNummer, gebdat, station, sollstation, aufnahmedatum, geschlecht);
                    p.Bett = Reader.GetString(8);
                    p.ZimmerNr = Reader.GetString(9);
                }
            }
            catch (Exception e)
            {
                UncaughtExeption("GET PATIENT", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }

            return p;
        }

        public Patient GetPatient(string vorname, string nachname)
        {
            Patient p = null;
            MySqlDataReader Reader = null;
            MySqlConnection Connection = null;

            try
            {
                Connection = Connect();
                Connection.Open();
                Reader = ExecuteQuery("SELECT pa.VersicherungsNr, pe.Vorname, pe.Nachname, pe.Geburtsdatum, pa.StationsBezeichnung, pa.Sollstation, pa.Aufnahmedatum, pe.Geschlecht, pa.ZimmerNr " +
                                      "FROM Patient pa, Person pe " +
                                      "WHERE pe.PersonID = pa.PersonID " +
                                      "AND pe.Vorname = \"" + vorname + "\" " +
                                      "AND pe.Nachname = \"" + nachname + "\";", Connection);

                if (Reader.Read())
                {
                    string versicherungsNummer = Reader.GetString(0);
                    DateTime gebdat = DateTime.Parse(Reader.GetString(3));

                    string station = Reader.GetString(4);

                    string sollstation = "";

                    try
                    {
                        sollstation = Reader.GetString(5);
                    }
                    catch(Exception e)
                    {
                        if(DebugMode)
                            Console.WriteLine("sollstation war Null");
                    }


                    DateTime aufnahmedatum = DateTime.Parse(Reader.GetString(6));
                    string geschlecht = Reader.GetString(7);
                    //string bett = Reader.GetString(8);
                    //string zimmerNr = Reader.GetString(9);

                    p = new Patient(vorname, nachname, versicherungsNummer, gebdat, station, sollstation, aufnahmedatum, geschlecht);
                    p.ZimmerNr = Reader.GetString(8);
                    //p.Bett = Reader.GetString(8);
                }
            }
            catch (Exception e)
            {
                UncaughtExeption("GET PATIENT", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }

            return p;
        }

        // !BUG! Patientenliste wird nicht mehr angezeigt wenn ein ZimmerNr in der DB NULL ist
        public List<Patient> GetAllPatients()
        {
            MySqlConnection connection = null;
            List<Patient> patients = null;
            string query = "select pe.Vorname, pe.Nachname, pa.VersicherungsNr, pe.Geburtsdatum, pa.StationsBezeichnung, pa.Aufnahmedatum, pe.Geschlecht, pa.Bett, pa.ZimmerNr " +
                           "from Patient pa, Person pe " +
                           "where pa.PersonID = pe.PersonID " +
                           "order by pe.Nachname; ";

            try
            {
                connection = Connect();
                connection.Open();
                MySqlDataReader reader = ExecuteQuery(query, connection);

                patients = new List<Patient>();

                while (reader.Read())
                {
                    Patient tmPatient = new Patient(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetDateTime(3),
                        reader.GetString(4),
                        "",
                        reader.GetDateTime(5),
                        reader.GetString(6)
                    );

                    tmPatient.Bett = reader.GetString(7);
                    tmPatient.ZimmerNr = reader.GetString(8);

                    patients.Add(tmPatient);
                }
            }
            catch (Exception e)
            {
                UncaughtExeption("GET ALL PATIENTS", e);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return patients;
        }



        //Versicherungsnummer kann nicht geändert werden
        public bool PatientAendern(Patient patient)
        {
            MySqlConnection Connection = null;

            if (patient != null)
                try
                {
                    Connection = Connect();
                    bool response = ExecuteInsert("UPDATE Patient " +
                                                  "SET StationsBezeichnung = \"" + patient.Station + "\", " + 
                                                  "ZimmerNr = \"" + patient.ZimmerNr + "\", " +
                                                  "Bett = \"" + patient.Bett + "\", " +
                                                  "Sollstation = \"" + patient.SollStation + "\" " +
                                                  "WHERE VersicherungsNr = \"" + patient.Versicherungsnr + "\";", Connection);
                    Connection.Close();
                    return response;
                }
                catch (Exception e)
                {
                    UncaughtExeption("PATIENT ÄNDERN", e);
                }
                finally
                {
                    if (Connection != null)
                    {
                        Connection.Close();
                    }
                }

            return false;
        }


        public bool PatientLoeschen(string versicherungsNummer)
        {
            MySqlConnection Connection = null;
            bool response = false;
            try
            {
                Connection = Connect();
                Patient p = GetPatient(versicherungsNummer);
                response =
                    ExecuteInsert("DELETE FROM Patient WHERE VersicherungsNr = \"" + versicherungsNummer + "\";",
                        Connection);

                BedGotFree(p);
            }
            catch (Exception e)
            {
                UncaughtExeption("PATIENT LÖSCHEN", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }
            return response;
        }

        public void BedGotFree(Patient p)
        {
            string query = "SELECT pa.VersicherungsNr, pa.Sollstation, pa.Aufnahmedatum " +
                           "FROM Patient pa " +
                           "WHERE NOT (pa.Sollstation = \"\") " +
                           "ORDER BY pa.Aufnahmedatum ASC;";

            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            try
            {
                connection = Connect();
                connection.Open();
                reader = ExecuteQuery(query, connection);

                if (reader != null)
                {
                    if (reader.Read())
                    {
                        if (reader.GetString(1).Equals(p.Station))
                        {
                            Patient falscheStation = GetPatient(reader.GetString(0));

                            string longBed = GetPassendesBett(p.Station, falscheStation);

                            if (!longBed.Equals("NULL") && !p.Station.Equals(falscheStation.SollStation))
                            {
                                string[] subs = longBed.Split('-');
                                string zimmerNr = subs[1];
                                string bett = subs[2];

                                AddToTransferList(falscheStation, longBed);

                                falscheStation.SollStation = "";
                                falscheStation.Station = p.Station;
                                falscheStation.ZimmerNr = zimmerNr;
                                falscheStation.Bett = bett;
                                PatientAendern(falscheStation);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                UncaughtExeption("BedGotFree", e);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        //zimmerDst im format - Station-ZimmerNr-Bett
        public bool PatientAnlegen(Patient patient, string zimmerDst)
        {
            if (patient != null)
            {
                MySqlConnection Connection = null;

                string query =
                    "INSERT INTO Patient(VersicherungsNr, PersonID, ZimmerNr, StationsBezeichnung, Bett, Sollstation) " +
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
                    patient.SollStation + "\");";                     // Sollstation

                try
                {
                    if (GetPatient(patient.Versicherungsnr) == null)
                    {
                        try
                        {
                            PersonAnlegen(patient);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Person konnte nicht angelegt werden.\n" + e.Message);
                        }
                        Connection = Connect();
                        bool response = ExecuteInsert(query, Connection);
                        Connection.Close();
                        return response & AddToTransferList(patient, zimmerDst);
                    }
                    return false;
                }
                catch (Exception e)
                {
                    UncaughtExeption("PATIENT ANLEGEN", e);
                }
                finally
                {
                    if (Connection != null)
                    {
                        Connection.Close();
                    }
                }
            }
            return false;
        }


        private bool AddToTransferList(Patient patient, string zimmerDst)
        {
            MySqlConnection Connection = null;
            bool result = false;

            try
            {
                string vonStation = patient.Station;
                string vonZimmer = patient.ZimmerNr;
                string vonBett = patient.Bett;
                string stationKurz = "";
                string longBed = "";


                switch (vonStation)
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
                }

                
                if ((stationKurz != null) && (!stationKurz.Equals("")) &&
                    (vonZimmer != null) && (!vonZimmer.Equals("")) && (vonBett != null) && (!vonBett.Equals("")))
                    longBed = stationKurz + "-" + vonZimmer + "-" + vonBett;

                string query =
                    "INSERT INTO TransferListe(PersonID, Von, Nach) VALUES((SELECT PersonID FROM Person WHERE Vorname = \"" +
                    patient.Vorname + "\" AND Nachname = \"" + patient.Nachname + "\"), " + "\"" + longBed + "\"" + ", \"" +
                    zimmerDst + "\");";

                Connection = Connect();
                result = ExecuteInsert(query, Connection);
            }
            catch (Exception e)
            {
                UncaughtExeption("AddToTransferliste", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }
            
            return result;
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
            }
            catch (Exception e)
            {
                UncaughtExeption("GET VERLEGUNGSLISTE", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }

            return verlegungsliste;
        }




        public bool DeleteMemberTransferliste(string vorname, string nachname)
        {
            string query = "DELETE FROM TransferListe " +
                           "WHERE PersonID IN" +
                           "(" +
                               "SELECT p.PersonID " +
                               "FROM Person p " +
                               "WHERE p.Vorname = \"" + vorname + "\" " +
                               "AND p.Nachname = \"" + nachname + "\" " +
                           ");";
            bool response = false;
            MySqlConnection Connection = null;

            try
            {
                /*
                Patient p = GetPatient(vorname, nachname);
                if (p.Station != null && !p.Station.Equals(""))
                {
                    p.SollStation = "";
                    p.Station = p.SollStation;
                }

                PatientAendern(p);
                */
                Connection = Connect();
                response = ExecuteInsert(query, Connection);
            }
            catch (Exception e)
            {
                UncaughtExeption("DELETE MEMBER TRANSFERLISTE", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }

            return response;
        }



        public bool PersonAnlegen(Patient p)
        {
            string query = "INSERT INTO Person(Vorname, Nachname, Geschlecht, Geburtsdatum) " +
                           "VALUES(\"" + p.Vorname + "\", \"" + p.Nachname + "\", \"" + p.Geschlecht + "\", Date(\"" + p.Gebdat.Year + "-" + p.Gebdat.Month + "-" + p.Gebdat.Day + "\"));";

            MySqlConnection Connection = null;
            bool response = false;

            Console.WriteLine("DEBUG " + query);
            Console.WriteLine("Patient.Gebdat = " + p.Gebdat.ToString());

            try
            {
                Connection = Connect();
                response = ExecuteInsert(query, Connection);
            }
            catch (Exception e)
            {
                UncaughtExeption("PERSON ANLEGEN", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }
            return response;
        }

        public bool PersonAnlegen(string Vorname, string Nachname)
        {
            string query = "INSERT INTO Person(Vorname, Nachname) " +
                           "VALUES(\"" + Vorname + "\", \"" + Nachname + "\");";
            MySqlConnection Connection = null;
            bool response = false;

            try
            {
                Connection = Connect();
                response = ExecuteInsert(query, Connection);
            }
            catch (Exception e)
            {
                UncaughtExeption("PERSON ANLEGEN", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }
            return response;
        }


        public User GetUser(string userName)
        {
            MySqlDataReader Reader = null;
            MySqlConnection Connection = null;
            User user = null;


            try
            {
                Connection = Connect();
                Connection.Open();
                Reader = ExecuteQuery(
                    "SELECT u.Benutzername, u.Rechte, u.Passwort, p.Vorname, p.Nachname FROM Users u, Person p WHERE u.PersonID = p.PersonID AND u.Benutzername = \"" +
                    userName + "\";", Connection);

                if (Reader.Read())
                {
                    string rechte = Reader.GetString(1);
                    string passwort = Reader.GetString(2);
                    string vorname = Reader.GetString(3);
                    string nachname = Reader.GetString(4);

                    user = new User(vorname, nachname, rechte, userName, passwort);
                }
            }
            catch (Exception e)
            {
                UncaughtExeption("GET USER", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }
            return user;
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

            MySqlConnection Connection = null;
            bool response = false;

            try
            {
                if (GetUser(user.Benutzername) == null)
                {
                    Connection = Connect();
                    Connection.Open();
                    MySqlDataReader reader = ExecuteQuery(CheckPersonQuery, Connection);

                    if (reader.Read())
                    {
                        short count = reader.GetInt16(0);
                        

                        if (count == 0)
                        {
                            PersonAnlegen(user.Vorname, user.Nachname);
                        }
                    }
                    Connection.Close();
                    response = ExecuteInsert(InsertQuery, Connection);
                }
            }
            catch (Exception e)
            {
                UncaughtExeption("USER ANLEGEN", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }

            return response;
        }


        public bool UserLoeschen(string userName)
        {
            MySqlConnection Connection = null;
            bool response = false;

            try
            {
                Connection = Connect();

                if(GetUser(userName) != null)
                    response = ExecuteInsert("DELETE FROM Users WHERE Benutzername = \"" + userName + "\";", Connection);
            }
            catch (Exception e)
            {
                UncaughtExeption("USER LÖSCHEN", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }

            return response;
        }


        public Bettenbelegung GetBettenbelegung()
        {
            Bettenbelegung belegung = null;
            MySqlConnection Connection = null;
            try
            {
                belegung = new Bettenbelegung();

                Connection = Connect();
                Connection.Open();

                MySqlDataReader reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Gynäkologie\";",
                    Connection);
                if (reader.Read())
                    belegung.Gynaekologie = reader.GetInt32(0);
                reader.Close();

                reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Innere Medizin\";",
                    Connection);
                if (reader.Read())
                    belegung.Innere = reader.GetInt32(0);
                reader.Close();

                reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Onkologie\";",
                    Connection);
                if (reader.Read())
                    belegung.Onkologie = reader.GetInt32(0);
                reader.Close();

                reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Orthopädie\";",
                    Connection);
                if (reader.Read())
                    belegung.Orthopaedie = reader.GetInt32(0);
                reader.Close();

                reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Pädiatrie\";",
                    Connection);
                if (reader.Read())
                    belegung.Paediatrie = reader.GetInt32(0);
                reader.Close();

                reader = ExecuteQuery(
                    "SELECT Count(StationsBezeichnung) FROM Patient WHERE StationsBezeichnung = \"Intensivstation\";",
                    Connection);
                if (reader.Read())
                    belegung.Intensiv = reader.GetInt32(0);
                reader.Close();
            }
            catch (Exception e)
            {
                UncaughtExeption("GET BETTENBELEGUNG", e);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
            }
            
            return belegung;
        }

        //Potential Bugs!
        //looks for a room with 1 person in it and matches the gender, if no room with 1 person is available search for empty rooms
        public string GetPassendesBett(string Station, Patient patient)
        {
            string query = "";
            string Bett = "NULL";
            string stationKurz = "NULL";
            int zimmerNr = 0;
            bool found = false;
            string result = "NULL";

            MySqlConnection connection = null;
            MySqlDataReader reader = null;

            int alter = DateTime.Now.Subtract(patient.Gebdat).Days / 365;

            if ((Station.Equals("Pädiatrie")) && (DateTime.Now.Subtract(patient.Gebdat).Days > 365 * 13))
                return "NULL";

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

            try
            {
                connection = Connect();
                connection.Open();

                if (!Station.Equals("Intensivstation"))
                {
                    //Select all rooms with exactly 1 person in it
                    query =
                        "select z.ZimmerNr, z.StationsBezeichnung, p.VersicherungsNr, pe.Geschlecht, p.Bett, pe.Geburtsdatum " +
                        "from Zimmer z, Patient p, Person pe " +
                        "where z.ZimmerNr = p.ZimmerNr " +
                        "and z.StationsBezeichnung = p.StationsBezeichnung " +
                        "and z.StationsBezeichnung = \"" + Station + "\" " +
                        "and pe.PersonID = p.PersonID " +
                        "group by z.ZimmerNr having count(z.ZimmerNr) < 2; ";

                    reader = ExecuteQuery(query, connection);

                    while (reader.Read())
                    {
                        string tmpGeschlecht = patient.Geschlecht;
                        //Match Geschlecht
                        if (!Station.Equals("Pädiatrie") && CheckIfAgeLt14(patient.Gebdat))
                        {
                            tmpGeschlecht = "w";
                        }

                        if (reader.GetChar(3).ToString().ToLower().Equals(tmpGeschlecht))
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
                    connection.Open();
                    reader = ExecuteQuery(query, connection);
                    if (reader.Read())
                    {
                        zimmerNr = reader.GetInt32(0);
                        Bett = "F";
                        found = true;
                    }
                }


                //if a room was found return it, if not search at an other station
                if (found)
                    result = stationKurz + "-" + zimmerNr + "-" + Bett;

                /*else //TODO Test
                {
                    if (patient.SollStation.Equals(""))
                        patient.SollStation = Station;
                    PatientAendern(patient);

                    //Andere Station auswählen
                    List<string> prioritiyList = new List<string>();
                    prioritiyList.Add("Innere Medizin");
                    prioritiyList.Add("Onkologie");
                    prioritiyList.Add("Orthopädie");
                    prioritiyList.Add("Gynäkologie");
                    prioritiyList.Add("Pädiatrie");

                    var enumerator = prioritiyList.GetEnumerator();

                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current != Station)
                        {
                            if ((result = GetPassendesBett(enumerator.Current, patient)).Equals("NULL"))
                                continue;
                            else
                                break;
                        }
                    }
                }
                connection.Close();
                */
            }
            catch (Exception e)
            {
                UncaughtExeption("GetPassendesBett", e);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            /* TODO 
            patient.Bett = Bett;
            patient.ZimmerNr = zimmerNr.ToString();
            patient.Station = Station;
            //result &= PatientAendern(patient);
            */
            return result;
        }

        public static bool CheckIfAgeLt14(DateTime bDay)
        {
            //returns true, if child is less than 14 years old
            if (TimeSpan.Compare(TimeSpan.FromDays(5106), DateTime.Today.Subtract(bDay)) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // ################################################## DEV FUNCTIONS ################################################## //


        public void TestDB()
        {
            try
            {
                var tmp = GetAllPatients();
                foreach (var patient in tmp)
                {
                    Console.WriteLine(patient.Nachname);
                }
            }
            catch (Exception e)
            {
                UncaughtExeption("TESTDB_EXCEPTION", e);
            }
        }


        public void UncaughtExeption(string callerName, Exception e)
        {
            if (DebugMode)
            {
                Console.Error.WriteLine("\nUnhandled Exception at " + callerName);
                Console.Error.WriteLine(e.Message);
            }
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
                Console.WriteLine("Sollstation = " + p.SollStation);
                Console.WriteLine("AufnahmeDatum = " + p.Aufnahmedatum.ToString());
                Console.WriteLine("Geschlecht = " + p.Geschlecht);
            }
            else
                Console.WriteLine("NULL");
        }
    }
}
