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
        private string _sollstation;
        private DateTime _aufnahmedatum;
        private string _geschlecht;
        private string _zimmernr;
        private string _bett;

        public string Versicherungsnr { get => _versicherungsnr; set => _versicherungsnr = value; }
        public DateTime Gebdat { get => _gebdat; set => _gebdat = value; }
        public string Station { get => _station; set => _station = value; }
        public string SollStation { get => _sollstation; set => _sollstation = value; }
        public DateTime Aufnahmedatum { get => _aufnahmedatum; set => _aufnahmedatum = value; }
        public string Geschlecht { get => _geschlecht; set => _geschlecht = value; }
        public string Bett { get => _bett; set => _bett = value; }
        public string ZimmerNr { get => _zimmernr; set => _zimmernr = value; }

        public Patient()
        {

        }

        public Patient(string vorname, string nachname, string versnr, DateTime gebdat, string station, string sollstation = "", DateTime aufnahmedatum, string geschlecht)
        {
            Vorname = vorname;
            Nachname = nachname;
            Versicherungsnr = versnr;
            Gebdat = gebdat;
            Station = station;
            SollStation = sollstation;
            Aufnahmedatum = aufnahmedatum;
            Geschlecht = geschlecht;
        }

    }
}
