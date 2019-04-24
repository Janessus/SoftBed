using System;
using System.Collections.Generic;
using System.Text;
using Wrapperklassen;

namespace Logic
{
    class ZimmerManagement : LogicController
    {
        private static ZimmerManagement _instance = null;

        private ZimmerManagement()
        {

        }

        public ZimmerManagement GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ZimmerManagement();
            }

            return _instance;
        }

        public bool PatientenTransfer(int versNr)
        {
            return false;
        }

        public string suchePassendesBett(int versNr)
        {
            return null;
        }

        public int KHFülle()
        {
            Bettenbelegung belegung = UpdateManagement.GetInstance().GetCurrentBettenbelegung();

            int gesAuslast = belegung.Gynaekologie + belegung.Innere + belegung.Intensiv + belegung.Onkologie +
                             belegung.Orthopaedie + belegung.Paediatrie;

            return gesAuslast;
        }

        public bool KHFastVoll()
        {

        }
    }
}
