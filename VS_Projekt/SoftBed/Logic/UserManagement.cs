using System;
using System.Collections.Generic;
using System.Text;
using Wrapperklassen;

namespace Logic
{
    public class UserManagement : LogicController
    {
        private static UserManagement _instance = null;
        private static User _currentUser;
        

        public static User CurrentUser { get => _currentUser; set => _currentUser = value; }

        private UserManagement()
        {
            CurrentUser = new User("Dummy", "Dummy", "Dummy", "Dummy", "Dummy");
        }

        public static UserManagement GetInstance()
        {
            if(_instance == null)
            {
                _instance = new UserManagement();
            }
            return _instance;
        }

        /**
         * funktion zum Anlegen eines Users
         * @param bekommt einen neuen User übergeben
         * @return true falls geklappt oder false falls nicht möglich
         */
        public bool UserAnlegen(User newUser)
        {
            bool result = DatabaseManagement.GetInstance().UserAnlegen(newUser);
            return result;
        }

        /**
         * funktion zum löschen eines Users
         * @param bekommt Benutzername des zu löschenden Users übergeben
         * @return true falls geklappt und false falls nicht möglich
         */
        public bool UserLöschen(string userName)
        {
            bool result = DatabaseManagement.GetInstance().UserLoeschen(userName);
            return result;
        }

        /**
         * funktion zum login eines Users
         * @param Benutzername und Passwort des einloggers
         * @return true falls geklappt, false falls nicht möglich 
         */
        public bool UserLogin(string userName, string password)
        {
            User requestedUser = DatabaseManagement.GetInstance().GetUser(userName);
            if(requestedUser != null)
            {
                if(requestedUser.Passwort == password)
                {
                    CurrentUser = new User(requestedUser.Vorname, requestedUser.Nachname, requestedUser.Rechte, requestedUser.Benutzername, requestedUser.Passwort);
                    return true;
                }
            }

            return false;
        }

        /**
         * funktion zum logout einer Users
         */
         public void UserLogout()
         {
            CurrentUser = new User("Dummy", "Dummy", "Dummy", "Dummy", "Dummy");
         }

    }
}
