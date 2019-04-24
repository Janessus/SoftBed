using System;
using System.Collections.Generic;
using System.Text;

namespace Wrapperklassen
{
    class Station
    {
        private List<Zimmer> _zimmerliste;

        public List<Zimmer> Zimmerliste { get => _zimmerliste; set => _zimmerliste = value; }
    }
}
