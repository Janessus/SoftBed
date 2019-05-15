using System;
using System.Collections.Generic;
using System.Text;

namespace Wrapperklassen
{
    public class Zimmer
    {
        private bool _position;  // true = tuer, false = fenster
        private int _zimmerNr;

        public bool Position { get => _position; set => _position = value; }
        public int ZimmerNr { get => _zimmerNr; set => _zimmerNr = value; }
    }
}
