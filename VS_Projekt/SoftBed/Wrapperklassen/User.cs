using System;
using System.Collections.Generic;
using System.Text;

namespace Wrapperklassen
{
    public class User : Person
    {
        private string _rechte;
        private string _benutzername;
        private string _passwort;

        public string Rechte { get => _rechte; set => _rechte = value; }
        public string Benutzername { get => _benutzername; set => _benutzername = value; }
        public string Passwort { get => _passwort; set => _passwort = value; }

        public User()
        {

        }

        public User(string vorname, string nachname, string rechte, string benutzername, string passwort)
        {
            Vorname = vorname;
            Nachname = nachname;
            Rechte = rechte;
            Benutzername = benutzername;
            Passwort = passwort;
        }

    }
}
