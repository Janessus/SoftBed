using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftBed
{
    public partial class HauptFenster : Form
    {
        public HauptFenster()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
        }

        private void patVerwBtn_Click(object sender, EventArgs e)
        {
            openPatientenVerwaltung();
        }

        private void verlAugefBtn_Click(object sender, EventArgs e)
        {

        }

        private void abmeldenBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /**
        * opens patientenverwaltung and hides MainWindow
        */
        private void openPatientenVerwaltung()
        {
            this.SetVisibleCore(false);
            Form patientenVerwaltung = new PatientenVerwaltung();
            patientenVerwaltung.ShowDialog();
            this.SetVisibleCore(true);
        }
    }
}
