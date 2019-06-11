using System;
using System.Collections.Generic;
using System.Text;
using Wrapperklassen;

namespace Logic
{
    public class PatientenManagement : LogicController
    {

        private static PatientenManagement _instance = null;
        private static int islast = 0;
        private static int geslast = 0;

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

            Bettenbelegung belegung = UpdateManagement.GetInstance().GetCurrentBettenbelegung();
            if(belegung.Intensiv == 10 && islast == 9)
                ZimmerManagement.GetInstance().ITSVoll();
            if(belegung.Gesamt() == 225 && geslast == 224)
                ZimmerManagement.GetInstance().KHFastVoll();

            islast = belegung.Intensiv;
            geslast = belegung.Gesamt();

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

            Bettenbelegung belegung = UpdateManagement.GetInstance().GetCurrentBettenbelegung();

            islast = belegung.Intensiv;
            geslast = belegung.Gesamt();

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
