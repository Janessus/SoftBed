using System;
using System.Collections.Generic;
using System.Text;
using Wrapperklassen;

namespace Logic
{
    public class PatientenManagement : LogicController
    {

        private static PatientenManagement _instance = null;
        private static Patient _currentPatient;

        public static Patient CurrentPatient { get => _currentPatient; set => _currentPatient = value; }

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
            return false;
        }

        public bool PatientLoeschen(int versNr)
        {
            return false;
        }

        public bool PatientAendern(Patient newPatient, int versNr)
        {
            return false;
        }

    }
}
