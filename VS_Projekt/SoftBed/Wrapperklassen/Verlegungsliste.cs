using System;
using System.Collections.Generic;
using System.Text;

namespace Wrapperklassen
{
    public class Verlegungsliste
    {
        private List<VerlegungslistenItem> _transferliste;

        public List<VerlegungslistenItem> Transferliste { get => _transferliste; set => _transferliste = value; }
    }
}
