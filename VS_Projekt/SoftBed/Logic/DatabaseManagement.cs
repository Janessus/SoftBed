using System;
using Wrapperklassen;
using MySql.Data.MySqlClient;

namespace Logic
{
    public class DatabaseManagement : LogicController
    {
        private static DatabaseManagement _instance = null;
        private static MySqlConnection _connection = null;

        public static DatabaseManagement Instance { get => _instance; set => _instance = value; }
        public static MySqlConnection Connection { get => _connection; set => _connection = value; }

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
        private MySqlConnection Connect()
        {
            string connectionString = "SERVER=192.168.178.88;" +
                                      "DATABASE=SoftBedDB;" +
                                      "UID=softbed;" +
                                      "PASSWORD=softbed;";

            try
            {
                Connection = new MySqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Connection;
        }

        //"INSERT INTO Patient(VersicherungsNr, PersonID, ZimmerNr, StationsBezeichnung, Bett, Beschwerde) VALUES(\"21350\",(SELECT Person.PersonID From Person WHERE Vorname = \"Pablo\" AND Nachname = \"Escobar\"),0,\"Innere Medizin\",'F',\"Überdosis + Stichwunden\");"

        //executes the query that was passed as an argument, returns a MySqlDataReader Object if successful and null if not
        //Connection has to be closed after this function returns
        private MySqlDataReader ExecuteQuery(String query)
        {
            MySqlDataReader Reader = null;
            
            try
            {
                Connection = Connect();
                Connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, Connection);
                Reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
            
            return Reader;
        }

        public Patient GetPatient(string versicherungsNummer)
        {
            Patient p = null;
            MySqlDataReader Reader = null;

            try
            {
                Reader = ExecuteQuery("SELECT VersicherungsNr, Vorname, Nachname, Geburtsdatum, StationsBezeichnung, Beschwerde, Aufnahmedatum, Geschlecht FROM Patient, Person WHERE VersicherungsNr=\"" + versicherungsNummer + "\";");

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
                Console.WriteLine(e);
                Connection.Close();
                throw;
            }
            
            return p;
        }


        public bool PatientAendern(Patient patient)
        {
            try
            {
                ExecuteQuery("UPDATE Patient SET StationsBezeichnung = \"" + patient.Station + "\", " + "Beschwerde = \"" +
                             patient.Beschwerde + "\" WHERE VersicherungsNr = \"" + patient.Versicherungsnr + "\";");

                Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Connection.Close();
                throw;
            }
        }


        public bool PatientLoeschen(string versicherungsNummer)
        {
            try
            {
                ExecuteQuery("DELETE FROM Patient WHERE VersicherungsNr = \"" + versicherungsNummer + "\";");
                Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Connection.Close();
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
                    "VALUES(\"" + 
                    patient.Versicherungsnr + "\"," +                 // VersicherungsNr
                    "(SELECT Person.PersonID From Person " +          // PersonID
                    "WHERE " +                                        // *
                    "Vorname = \"" + patient.Vorname +                // *
                    "\" AND " +                                       // *
                    "Nachname = \"" + patient.Nachname + "\")," +     // *
                    "0" + ",\"" +                                     // ZimmerNr
                    patient.Station + "\"," +                         // Station
                    "\'F\'" + ",\"" +                                 // Bett
                    patient.Beschwerde + "\");";                      // Beschwerde

                if(PersonAnlegen(patient.Vorname, patient.Nachname))
                { 

                    if (ExecuteQuery(query) != null)
                    {
                        Connection.Close();
                        return true;
                    }
                    else
                    {
                        Connection.Close();
                        return false;
                    }
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
            
            try
            {
                Connection = Connect();
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

                Cmd.Dispose();
                Connection.Close();

                return verlegungsliste;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Cmd.Dispose();
                Connection.Close();
                throw;
            }
        }

        public bool PersonAnlegen(string vorname, string nachname)
        {
            string query = "INSERT INTO Person(Vorname, Nachname) " +
                           "VALUES(\"" + vorname + "\", \"" + nachname + "\");";

            try
            {
                if (ExecuteQuery(query) != null)
                {
                    Connection.Close();
                    return true;
                }
                else
                {
                    Connection.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }

            return false;
        }


        public User GetUser(string userName)
        {
            MySqlDataReader Reader = null;

            try
            {
                Reader = ExecuteQuery("SELECT u.Benutzername, u.Rechte, u.Passwort, p.Vorname, p.Nachname FROM Users u, Person p WHERE u.PersonID = p.PersonID AND u.Benutzername = \"" + userName + "\";");

                if (Reader.Read())
                {
                    string rechte = Reader.GetString(1);
                    string passwort = Reader.GetString(2);
                    string vorname = Reader.GetString(3);
                    string nachname = Reader.GetString(4);

                    return new User(vorname, nachname, rechte, userName, passwort);
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
                if (ExecuteQuery(query) != null)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return false;
        }

        public bool UserLoeschen(string userName)
        {
            try
            {
                ExecuteQuery("DELETE FROM Users WHERE Benutzername = \"" + userName + "\";");
                Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Connection.Close();
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


        // ################################################## DEV FUNCTIONS ##################################################


        public void TestDB()
        {

            //Patient p1 = GetPatient("12345");
            //PrintPatient(p1);

            PatientAnlegen(new Patient("Pablo", "Escobar", "21350", DateTime.Parse("1937-10-04"), "Innere Medizin", "Überdosis + Stichwunden", DateTime.Now, "M"));
            PatientAnlegen(new Patient("Max", "Mustermann", "42", DateTime.Parse("1937-10-04"), "Orthopädie", "Überdosis + Stichwunden", DateTime.Now, "M"));
            //User u = GetUser("Janessus");
            //Console.WriteLine(u.Rechte);

            //User u = new User("Janes", "Heuberger", "Praktikant", "JanesPraktikant", "PW");
            //UserAnlegen(u);
            //UserLoeschen("Janessus");


            //Connection.Close();
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
    }
}
