﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Wrapperklassen
{
    public class Patient : Person
    {
        private int _versicherungsnr;
        private string _gebdat;
        private string _station;
        private string _beschwerde;
        private string _aufnahmedatum;
        private string _geschlecht;

        public int Versicherungsnr { get => _versicherungsnr; set => _versicherungsnr = value; }
        public string Gebdat { get => _gebdat; set => _gebdat = value; }
        public string Station { get => _station; set => _station = value; }
        public string Beschwerde { get => _beschwerde; set => _beschwerde = value; }
        public string Aufnahmedatum { get => _aufnahmedatum; set => _aufnahmedatum = value; }
        public string Geschlecht { get => _geschlecht; set => _geschlecht = value; }

        public Patient()
        {

        }

        public Patient(string vorname, string nachname, int versnr, string gebdat, string station, string beschwerde, string aufnahmedatum, string geschlecht)
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
