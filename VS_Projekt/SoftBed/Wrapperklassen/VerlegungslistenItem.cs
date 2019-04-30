using System;
using System.Collections.Generic;
using System.Text;

namespace Wrapperklassen
{
    public class VerlegungslistenItem
    {
        private Person _person;
        private string _von;
        private string _nach;

        public Person Person { get => _person; set => _person = value; }
        public string Von { get => _von; set => _von = value; }
        public string Nach { get => _nach; set => _nach = value; }

        public VerlegungslistenItem()
        {

        }

        public VerlegungslistenItem(Person person, string von, string nach)
        {
            _person = person;
            _von = von;
            _nach = nach;
        }
    }
}
