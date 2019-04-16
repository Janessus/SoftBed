using System;

namespace Wrapperklassen
{
    public class Person
    {
        private string _vorname;
        private string _nachname;

        public string Vorname { get => _vorname; set => _vorname = value; }
        public string Nachname { get => _nachname; set => _nachname = value; }
    }
}
