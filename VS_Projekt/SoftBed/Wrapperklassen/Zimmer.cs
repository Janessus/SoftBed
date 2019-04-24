using System;
using System.Collections.Generic;
using System.Text;

namespace Wrapperklassen
{
    public class Zimmer
    {
        private string _fenster;
        private string _tür;
        private int _zimmerNr;

        public string Fenster { get => _fenster; set => _fenster = value; }
        public string Tür { get => _tür; set => _tür = value; }
        public int ZimmerNr { get => _zimmerNr; set => _zimmerNr = value; }
    }
}
