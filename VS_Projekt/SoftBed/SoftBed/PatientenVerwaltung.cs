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
using Wrapperklassen;

namespace SoftBed
{
    public partial class PatientenVerwaltung : Form
    {

        private PatientenManagement pPatientenManagement = PatientenManagement.GetInstance();
        private ZimmerManagement pZimmerManagement = ZimmerManagement.GetInstance();
        private int currentPatientenVNr = 0;

        public PatientenVerwaltung()
        {
            InitializeComponent();
        }

        /**
         * Action Listener for entlassen Button
         * shows confirming dialog and deletes only, if User confirmed the second time
         * ACHTUNG: fehlt noch Überprüfung: Ist Patient selektiert?
         */
        private void entlassenBtn_Click(object sender, EventArgs e)
        {
            // If the yes button was pressed ...
            if (showDeleteConfirmingDialog() == DialogResult.Yes)
            {
                pPatientenManagement.PatientLoeschen(Int32.Parse(versNrSucheTxt.Text));
            }

        }

        // suche Patient
        private void sucheBtn_Click(object sender, EventArgs e)
        {
            if (!versNrSucheTxt.Text.Equals(""))
            {

            }
        }

        private void aufnahmeBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void zurueckBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /**
         * reads Patient from GUI
         * creats Patient in DB
         * searches for Room in Hospital
         * sets option in suggestion Label
         */
        private void zimmerSuchenBtn_Click(object sender, EventArgs e)
        {
            Patient pPatient = getPatientFromGUI();
            pPatientenManagement.PatientAnlegen(pPatient);
            String roomSuggestion = pZimmerManagement.suchePassendesBett(pPatient.Versicherungsnr);
            editMeldungLdl.Text = roomSuggestion;
        }


        /**
         * suggestion has been accepted
         * opens confirm Dialog
         * puts transfer into DB
         * @return Patient from GUI
         */
        private void akzeptierenBtn_Click(object sender, EventArgs e)
        {
            // If the yes button was pressed ...
            if (showTransferConfirmingDialog() == DialogResult.Yes)
            {
                // Transfer has been accepted, can write into DB
                pZimmerManagement.PatientenTransfer(currentPatientenVNr);
            }
        }




        /**
         * reads Patient data from GUI
         * @return Patient from GUI
         */
        private Patient getPatientFromGUI()
        {
            Patient guiPatient = new Patient();
            guiPatient.Versicherungsnr = int.Parse(versNrSucheTxt.Text);
            currentPatientenVNr = guiPatient.Versicherungsnr;
            guiPatient.Gebdat = gebDatTxt.Text;
            guiPatient.Beschwerde = null;
            DateTime localDate = DateTime.Now;
            guiPatient.Aufnahmedatum = localDate;
            if (wRadBtn.Checked)
            {
                guiPatient.Geschlecht = "w";
            }
            else
            {
                guiPatient.Geschlecht = "m";
            }

            guiPatient.Station = abteilungDropDown.SelectedText;
            
            return guiPatient;
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

        /**
         * shows dialog for User to confirm transfering
         * @return which button has been clicked
         */
        private DialogResult showTransferConfirmingDialog()
        {
            string messageBoxText = "Wollen Sie den Patienten wirklich in das vorgeschlagene Zimmer legen?";
            string caption = "Bestätigung";
            MessageBoxButtons button = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(messageBoxText, caption, button);

            return result;
        }

    }
}
