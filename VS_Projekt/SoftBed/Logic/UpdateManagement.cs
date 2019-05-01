using System;
using System.Collections.Generic;
using System.Text;
using Wrapperklassen;

namespace Logic
{
    public class UpdateManagement : LogicController
    {
        private static UpdateManagement _instance = null;

        private UpdateManagement()
        {

        }

        public static UpdateManagement GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UpdateManagement();
            }
            return _instance;
        }

        public Patient GetPatient(string versNr)
        {
            Patient patient = DatabaseManagement.GetInstance().GetPatient(versNr);

            return patient;
        }

        public User GetUser(string userName)
        {
            User user = DatabaseManagement.GetInstance().GetUser(userName);

            return user;
        }

        public Bettenbelegung GetCurrentBettenbelegung()
        {
            Bettenbelegung bettenbelegung = DatabaseManagement.GetInstance().GetBettenbelegung();
            return bettenbelegung;
        }

        public Verlegungsliste GetCurrentVerlegungsliste()
        {
            Verlegungsliste verlegungsliste = DatabaseManagement.GetInstance().GetVerlegungsliste();
            return verlegungsliste;
        }
    }
}
