using System;
using System.Collections.Generic;
using System.Text;

namespace Wrapperklassen
{
    public class Bettenbelegung
    {
        private int _gynaekologie;
        private int _innere;
        private int _onkologie;
        private int _orthopaedie;
        private int _paediatrie;
        private int _intensiv;

        public int Gynaekologie { get => _gynaekologie; set => _gynaekologie = value; }
        public int Innere { get => _innere; set => _innere = value; }
        public int Onkologie { get => _onkologie; set => _onkologie = value; }
        public int Orthopaedie { get => _orthopaedie; set => _orthopaedie = value; }
        public int Paediatrie { get => _paediatrie; set => _paediatrie = value; }
        public int Intensiv { get => _intensiv; set => _intensiv = value; }

        public int Gesamt()
        {
            int ges = Gynaekologie + Innere + Onkologie + Orthopaedie + Paediatrie + Intensiv;
            return ges;
        }
    }
}
