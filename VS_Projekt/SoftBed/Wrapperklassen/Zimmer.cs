using System;
using System.Collections.Generic;
using System.Text;

namespace Wrapperklassen
{
    public class Zimmer
    {
        private bool _tuer;
        private bool _fenster;
        private int _zimmerNr;

        public bool Tuer { get => _tuer; set => _tuer = value; }
        public bool Fenster { get => _fenster; set => _fenster = value; }
        public int ZimmerNr { get => _zimmerNr; set => _zimmerNr = value; }
    }
}
