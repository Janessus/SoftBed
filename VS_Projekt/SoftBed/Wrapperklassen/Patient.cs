using System;
using System.Collections.Generic;
using System.Text;

namespace Wrapperklassen
{
    public class Patient : Person
    {
        private string _versicherungsnr;
        private DateTime _gebdat;
        private string _station;
        private string _beschwerde;
        private DateTime _aufnahmedatum;
        private string _geschlecht;

        public string Versicherungsnr { get => _versicherungsnr; set => _versicherungsnr = value; }
        public DateTime Gebdat { get => _gebdat; set => _gebdat = value; }
        public string Station { get => _station; set => _station = value; }
        public string Beschwerde { get => _beschwerde; set => _beschwerde = value; }
        public DateTime Aufnahmedatum { get => _aufnahmedatum; set => _aufnahmedatum = value; }
        public string Geschlecht { get => _geschlecht; set => _geschlecht = value; }

        public Patient()
        {

        }

        public Patient(string vorname, string nachname, string versnr, DateTime gebdat, string station, string beschwerde, DateTime aufnahmedatum, string geschlecht)
        {
            Vorname = vorname;
            Nachname = nachname;
            Versicherungsnr = versnr;
            Gebdat = gebdat;
            Station = station;
            Beschwerde = beschwerde;
            Aufnahmedatum = aufnahmedatum;
            Geschlecht = geschlecht;
        }

    }
}
