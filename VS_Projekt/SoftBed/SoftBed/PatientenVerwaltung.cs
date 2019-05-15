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
        private UpdateManagement pUpdateManagement = UpdateManagement.GetInstance();
        private string currentPatientenVNr = null;

        public PatientenVerwaltung()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
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
                // If the yes button was pressed ...
                if (showDeleteConfirmingDialog() == DialogResult.Yes)
                {
                    pPatientenManagement.PatientLoeschen(versNrSucheTxt.Text);
                }
            }



        }


        // suche Patient
        private void sucheBtn_Click(object sender, EventArgs e)
        {
            if (!versNrSucheTxt.Text.Equals(""))
            {
                Patient selectedPatient = pUpdateManagement.GetPatient(versNrSucheTxt.Text);
                if (selectedPatient != null)
                {
                    patAnzDGV.Rows.Add(selectedPatient.Versicherungsnr, selectedPatient.Nachname, selectedPatient.Vorname, "Bettnr Implement. fehlt noch");

                }
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
         * puts person if confirmed in DB
         */
        private void zimmerSuchenBtn_Click(object sender, EventArgs e)
        {
            if (abteilungDropDown.SelectedIndex == 0 && mRadBtn.Checked) // is Gyn and male??
            {
                messageManInGyn();
            }
            else
            {
                if (showTransferConfirmingDialog() == DialogResult.Yes)
                {
                    Patient pPatient = getPatientFromGUI();
                    String roomSuggestion = pZimmerManagement.suchePassendesBett(pPatient);

                    // can write into DB
                    bool doneRight = pPatientenManagement.PatientAnlegen(pPatient);
                    if (doneRight)
                    {
                        editMeldungLdl.Text = "Patient wird in Raum" + roomSuggestion + "gelegt";
                        pZimmerManagement.PatientenTransfer(currentPatientenVNr);
                    }
                    else
                    {
                        MessageBox.Show("Patient konnte nicht angelegt werden!");
                    }

                }
            }
            
        }

        


        /**
         * reads Patient data from GUI
         * @return Patient from GUI
         */
        private Patient getPatientFromGUI()
        {
            Patient guiPatient = new Patient();
            guiPatient.Versicherungsnr = versNrSucheTxt.Text;
            currentPatientenVNr = guiPatient.Versicherungsnr;
            guiPatient.Gebdat = dTPGebDat.Value;
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



        /**
         * Sets message if, User wants to put man into Gynäkolgie
         */
        private void mRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (abteilungDropDown.SelectedIndex == 0 && mRadBtn.Checked)
            {
            Console.WriteLine("here");
                editMeldungLdl.Text = "Sie haben ausgewählt, dass Sie einen Mann auf die Gynäkologie legen wollen! Dies ist nicht möglich!";
            }
        }



        /**
         * Sets message if, User wants to put man into Gynäkolgie
         * or clears message, if not
         */
        private void abteilungDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (abteilungDropDown.SelectedIndex == 0 && mRadBtn.Checked)
            {
                editMeldungLdl.Text = "Sie haben ausgewählt, dass Sie einen Mann auf die Gynäkologie legen wollen! Dies ist nicht möglich!";
            }
            else
            {
                editMeldungLdl.Text = "";
            }
        }


        /**
         * warns User, that he wanted to put man in gyn
         */
        private void messageManInGyn()
        {
            string messageBoxText = "Diese Verlegung kann NICHT ausgeführt werden! Ein Mann kann nicht auf die Gynäkologie verlegt werden!";
            string caption = "Warnung";
            MessageBoxButtons button = MessageBoxButtons.OK;

            DialogResult result = MessageBox.Show(messageBoxText, caption, button);
        }

        /**
         * clears warning text
         */
        private void wRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            editMeldungLdl.Text = "";
        }
    }
}
