using System;
using System.Collections.Generic;
using System.Text;
using Wrapperklassen;

namespace Logic
{
    public class PatientenManagement : LogicController
    {

        private static PatientenManagement _instance = null;

        private PatientenManagement()
        {
        }

        /**
         * legt ein Singleton-Objekt an und gibt eins zurueck, wenn bereits vorhanden
         * @return ein Singleton-Objekt
         */
        public static PatientenManagement GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PatientenManagement();
            }
            return _instance;
        }

        /**
         * uebergibt dem Databasemanagement einen neuen Patienten zum Anlegen
         * @return true, wenn Patient erfolgreich angelegt und false, wenn nicht erfolgreich
         */
        public bool PatientAnlegen(Patient newPatient, String roomSuggestion)
        {
            bool request = DatabaseManagement.GetInstance().PatientAnlegen(newPatient, roomSuggestion);
            ZimmerManagement.GetInstance().KHFastVoll();
            ZimmerManagement.GetInstance().ITSVoll();

            return request;
        }

        /**
         * uebergibt dem Databasemanagement eine Versichertennummer,
         * um den dazugehoerigen Patienten zu loeschen
         * @return true, wenn Patient erfolgreich geloescht und false, wenn nicht erfolgreich
         */
        public bool PatientLoeschen(string versNr)
        {
            bool request = DatabaseManagement.GetInstance().PatientLoeschen(versNr);

            return request;
        }

        /**
         * uebergibt dem Databasemanagement einen Patienten  mit geaendert Attributen
         * @return true, wenn Patient erfolgreich geaendert und false, wenn nicht erfolgreich
         */
        public bool PatientAendern(Patient newPatient)
        {
            bool request = DatabaseManagement.GetInstance().PatientAendern(newPatient);

            return request;
        }

    }
}
