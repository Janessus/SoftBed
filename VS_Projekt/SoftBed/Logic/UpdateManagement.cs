using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<string> GetBettenbelegungSortiert(Bettenbelegung bettenbelegung)
        {
            List<SortBelegung> sortBelegung = new List<SortBelegung>();
            sortBelegung.Add(new SortBelegung("Pädiatrie", bettenbelegung.Paediatrie));
            sortBelegung.Add(new SortBelegung("Gynäkologie", bettenbelegung.Gynaekologie));
            sortBelegung.Add(new SortBelegung("Innere Medizin", bettenbelegung.Innere));
            sortBelegung.Add(new SortBelegung("Onkologie", bettenbelegung.Onkologie));
            sortBelegung.Add(new SortBelegung("Orthopädie", bettenbelegung.Orthopaedie));
            sortBelegung.Sort();

            List<string> sorted = new List<string>();
            for(int i=0;i<5;i++)
                sorted.Insert(i, sortBelegung.ElementAt(i).station);

            return sorted;
        }
        
        private class SortBelegung : IComparable<SortBelegung>
        {
            public string station;
            public int belegung;

            public SortBelegung(string station, int belegung)
            {
                this.station = station;
                this.belegung = belegung;
            }

            public int CompareTo(SortBelegung other)
            {
                if(this.belegung < other.belegung)
                    return 1;
             
                if (this.belegung > other.belegung)
                    return -1;

                return 0;
            }
        }

    }
}
