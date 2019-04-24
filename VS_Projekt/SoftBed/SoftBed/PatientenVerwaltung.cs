using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace SoftBed
{
    public partial class PatientenVerwaltung : Form
    {

        private PatientenManagement pPatientenManagement = PatientenManagement.GetInstance();

        public PatientenVerwaltung()
        {
            InitializeComponent();
        }

        /**
         * Action Listener for entlassen Button
         * shows confirming dialog and deletes only, if User confirmed the second time
         */
        private void entlassenBtn_Click(object sender, EventArgs e)
        {
            // If the yes button was pressed ...
            if (showDeleteConfirmingDialog() == DialogResult.Yes)
            {
                pPatientenManagement.PatientLoeschen(Int32.Parse(versNrSucheTxt.Text));
            }

        }

        private void sucheBtn_Click(object sender, EventArgs e)
        {

        }

        private void aufnahmeBtn_Click(object sender, EventArgs e)
        {

        }

        private void zurueckBtn_Click(object sender, EventArgs e)
        {

        }


        /**
         * shows dialog for User to confirm deleting
         * @return which button has been clicked
         */
        private DialogResult showDeleteConfirmingDialog()
        {
            string messageBoxText = "Wollen Sie den Patienten wirklich entlassen?";
            string caption = "Bestätigung";
            MessageBoxButtons button = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(messageBoxText, caption, button);

            return result;
        }
    }
}
