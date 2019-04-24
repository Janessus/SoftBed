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

        public static PatientenManagement GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PatientenManagement();
            }
            return _instance;
        }

        public bool PatientAnlegen(Patient newPatient)
        {
            bool request = DatabaseManagement.GetInstance().PatientAnlegen(newPatient);

            return request;
        }

        public bool PatientLoeschen(int versNr)
        {
            bool request = DatabaseManagement.GetInstance().PatientLoeschen(versNr);

            return request;
        }

        public bool PatientAendern(Patient newPatient)
        {
            bool request = DatabaseManagement.GetInstance().PatientAendern(newPatient);

            return request;
        }

    }
}
