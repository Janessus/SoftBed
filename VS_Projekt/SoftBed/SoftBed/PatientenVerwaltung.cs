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
            ShowAllPatients(DatabaseManagement.GetInstance().GetAllPatients());
        }

        /**
         * Action Listener for entlassen Button
         * shows confirming dialog and deletes only, if User confirmed the second time
         * ACHTUNG: fehlt noch Überprüfung: Ist Patient selektiert?
         */
        private void entlassenBtn_Click(object sender, EventArgs e)
        {
            if(UserManagement.CurrentUser.Rechte == "Standard")
            {
                // If the yes button was pressed ...
                if (showDeleteConfirmingDialog() == DialogResult.Yes)
                {
                    // If the yes button was pressed ...
                    if (showDeleteConfirmingDialog() == DialogResult.Yes)
                    {
                        bool result = pPatientenManagement.PatientLoeschen(patAnzDGV.SelectedRows[0].Cells[0].Value.ToString());    //delete Patient
                        if (result) //if worked
                        {
                            editMeldungLdl.Text = "Patient wurde aus dem System gelöscht";
                            patAnzDGV.Rows.Clear();
                            ShowAllPatients(DatabaseManagement.GetInstance().GetAllPatients());
                        }
                        else //if not worked
                        {
                            string messageBoxText = "Fehler aufgetreten! Patient konnte nicht gelöscht werden!!";
                            string caption = "Fehlschlag";
                            editMeldungLdl.Text = "Patient konnte nicht aus dem System gelöscht werden!";
                            MessageBoxButtons button = MessageBoxButtons.OK;

                            MessageBox.Show(messageBoxText, caption, button);
                        }
                    }
                }
            }
            else
            {
                string messageBoxText = "Benötigte Rechte nicht vorhanden!";
                string caption = "Fehlschlag";
                MessageBoxButtons button = MessageBoxButtons.OK;

                DialogResult result = MessageBox.Show(messageBoxText, caption, button);
            }



        }


        // suche Patient
        private void sucheBtn_Click(object sender, EventArgs e)
        {
            if (!versNrSucheTxt.Text.Equals(""))    //if textbox not empty
            {
                Patient patient = pUpdateManagement.GetPatient(versNrSucheTxt.Text);
                if (patient != null)    //if patient exists
                {
                    patAnzDGV.Rows.Clear();
                    if (patient.Station == "Onkologie")
                        patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                            "On-" + patient.ZimmerNr + "-" + patient.Bett);
                    else if (patient.Station == "Orthopädie")
                        patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                            "Or-" + patient.ZimmerNr + "-" + patient.Bett);
                    else if (patient.Station == "Pädiatrie")
                        patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                            "P-" + patient.ZimmerNr + "-" + patient.Bett);
                    else if (patient.Station == "Innere Medizin")
                        patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                            "IM-" + patient.ZimmerNr + "-" + patient.Bett);
                    else if (patient.Station == "Intensivstation")
                        patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                            "Is-" + patient.ZimmerNr + "-" + patient.Bett);
                    else if (patient.Station == "Gynäkologie")
                        patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                            "G-" + patient.ZimmerNr + "-" + patient.Bett);
                }
                else
                {
                    patientensucheMeldungTxt.ForeColor = Color.Red;
                    patientensucheMeldungTxt.Text = "Die angegebene Versicherungsnummer existiert nicht";
                }
            }
        }

        private void aufnahmeBtn_Click(object sender, EventArgs e)
        {
            if (UserManagement.CurrentUser.Rechte == "Standard")
            {
                //TODO
            }
            else
            {
                string messageBoxText = "Benötigte Rechte nicht vorhanden!";
                string caption = "Fehlschlag";
                MessageBoxButtons button = MessageBoxButtons.OK;

                DialogResult result = MessageBox.Show(messageBoxText, caption, button);
            }
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
            if (UserManagement.CurrentUser.Rechte == "Standard") //nullptr
            {
                // tests, if all fields are filled
                if (!AllFieldsFilled())
                {
                    editMeldungLdl.Text = "Füllen Sie zuerst alle Felder aus, bevor sie einen Patient aufnehmen!";
                }
                else
                {
                    editMeldungLdl.Text = "";
                    if (abteilungDropDown.SelectedIndex == 0 && mRadBtn.Checked) // is Gyn and male??
                    {
                        messageManInGyn();
                    }
                    else
                    {
                        int childPäd = TestChildPäd();
                        if (childPäd == -1)
                        {
                            // if user cancelled transaction
                            if (MessageChildInPädiatrie() == DialogResult.Cancel)
                            {
                                // ends transaction sets message
                                editMeldungLdl.Text =
                                    "Sie haben die Aufnahme abgebrochen! Der Patient wurde noch nicht aufgenommen!!";
                                return;
                            }
                            else
                            {
                                abteilungDropDown.SelectedIndex = 4;
                            }
                        }
                        else if (childPäd == 0)
                        {
                            MessageAdultInPäd();
                            editMeldungLdl.Text =
                                "Die Aufnahme wurde abgebrochen! Der Patient wurde noch nicht aufgenommen!!";
                            return;
                        }

                        if (showTransferConfirmingDialog() == DialogResult.Yes)
                        {
                            if (showTransferConfirmingDialog() == DialogResult.Yes)
                            {
                                Patient pPatient = getPatientFromGUI();
                                String roomSuggestion = pZimmerManagement.suchePassendesBett(pPatient);

                                // if no room was found, warning will be fired, otherwise tries to put patient in database
                                if (!roomSuggestion.Equals("NULL"))
                                {
                                    // can write into DB
                                    bool doneRight = pPatientenManagement.PatientAnlegen(pPatient, roomSuggestion);
                                    if (doneRight)
                                    {
                                        editMeldungLdl.Text = "Patient wird in Raum " + roomSuggestion + " gelegt";
                                        pZimmerManagement.PatientenTransfer(currentPatientenVNr, roomSuggestion);
                                        ShowAllPatients(DatabaseManagement.GetInstance().GetAllPatients());
                                    }
                                    else
                                    {
                                        MessageBox.Show("Patient konnte nicht angelegt werden!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(
                                        "Achtung!! Es konnte kein passendes Bett gefunden werden! Der Patient wird nicht aufgenommen!!");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                string messageBoxText = "Benötigte Rechte nicht vorhanden!";
                string caption = "Fehlschlag";
                MessageBoxButtons button = MessageBoxButtons.OK;

                DialogResult result = MessageBox.Show(messageBoxText, caption, button);
            }
        }

        


        /**
         * reads Patient data from GUI
         * @return Patient from GUI
         */
        private Patient getPatientFromGUI()
        {
            Patient guiPatient = new Patient();
            guiPatient.Versicherungsnr = versNrAufnTxt.Text;
            currentPatientenVNr = guiPatient.Versicherungsnr;
            guiPatient.Vorname = vornameTxt.Text;
            guiPatient.Nachname = nameTxt.Text;
            guiPatient.Station = abteilungDropDown.SelectedItem.ToString();
            guiPatient.SollStation = abteilungDropDown.SelectedItem.ToString();
            guiPatient.Gebdat = dTPGebDat.Value;
            guiPatient.SollStation = "";
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
            
            DatabaseManagement.PrintPatient(guiPatient);
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
            string messageBoxText;
            // if female, message for female
            if (wRadBtn.Checked)
            {
                messageBoxText = "Wollen Sie die Patientin " + vornameTxt.Text + " " + nameTxt.Text
                                 + " mit der Versicherungsnummer " + versNrAufnTxt.Text + " wirklich aufnehmen?";
            }
            // if male, message for male
            else
            {
                messageBoxText = "Wollen Sie den Patienten " + vornameTxt.Text + " " + nameTxt.Text
                                 + " mit der Versicherungsnummer " + versNrAufnTxt.Text + " wirklich aufnehmen?";
            }
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

        /**
         * tests if all patient fields are filled
         * @return all filled or not?
         */
        private bool AllFieldsFilled()
        {
            if ((nameTxt.Text == String.Empty) || (vornameTxt.Text == String.Empty) ||
                (versNrAufnTxt.Text == String.Empty) || (abteilungDropDown.Text == String.Empty))
            {
                return false;
            }

            return true;
        }

        /**
         * tests if patient is a child and should be put in päd or not
         * @return 1 if is child and put into Päd or ITS, -1 if it's child but not put into Päd, 0 if no child
         */
        private int TestChildPäd()
        {
            // returns 1, if first date is bigger, than second, 0, if equal, -1, if second is bigger
            // TimeSpan.Compare(TimeSpan.FromDays(5106), DateTime.Today.Subtract(dTPGebDat.Value) returns 1, if child is less than 14 years old
            if (TimeSpan.Compare(TimeSpan.FromDays(5106), DateTime.Today.Subtract(dTPGebDat.Value)) == 1)
            {
                if (abteilungDropDown.SelectedIndex == 4 || abteilungDropDown.SelectedIndex == 5)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (abteilungDropDown.SelectedIndex == 4)
                {
                    return 0;
                }
                return 1;
            }
        }

        /**
         * warns User, that he wanted to put child in other station
         */
        private DialogResult MessageChildInPädiatrie()
        {
            string messageBoxText = 
                "Sie wollten ein Kind in eine andere Station als die Pädiatrie oder ITS legen!\r\n Das Kind wird automatisch in die Pädiatrie verlegt werden! \r\n Bei Abbrechen wird der Vorgang abgebrochen!!";
            string caption = "Warnung";
            MessageBoxButtons button = MessageBoxButtons.OKCancel;

            DialogResult result = MessageBox.Show(messageBoxText, caption, button);
            return result;
        }



        /**
         * warns User, that he wanted to put adult in Pädiatrie
         */
        private DialogResult MessageAdultInPäd()
        {
            string messageBoxText =
                "Sie wollten einen Erwachsenen in die Pädiatrie legen!\r\n Dies ist nicht möglich! \r\n Der Patient wird NICHT aufgenommen!!";
            string caption = "Warnung";
            MessageBoxButtons button = MessageBoxButtons.OK;

            DialogResult result = MessageBox.Show(messageBoxText, caption, button);
            return result;
        }
        private void ShowAllPatients(List<Patient> patients)
        {
            patAnzDGV.Rows.Clear();
            foreach (var patient in patients)
            {

                if (patient.Station == "Onkologie")
                    patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                        "On-" + patient.ZimmerNr + "-" + patient.Bett);
                else if (patient.Station == "Orthopädie")
                    patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                        "Or-" + patient.ZimmerNr + "-" + patient.Bett);
                else if (patient.Station == "Pädiatrie")
                    patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                        "P-" + patient.ZimmerNr + "-" + patient.Bett);
                else if (patient.Station == "Innere Medizin")
                    patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                        "IM-" + patient.ZimmerNr + "-" + patient.Bett);
                else if (patient.Station == "Intensivstation")
                    patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                        "Is-" + patient.ZimmerNr + "-" + patient.Bett);
                else if (patient.Station == "Gynäkologie")
                    patAnzDGV.Rows.Add(patient.Versicherungsnr, patient.Nachname, patient.Vorname,
                        "G-" + patient.ZimmerNr + "-" + patient.Bett);
            }
        }
        

        private void VersNrSucheTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sucheBtn_Click(sender, e);
            }
            if (e.KeyCode == Keys.Back && versNrSucheTxt.Text == "")
            {
                ShowAllPatients(DatabaseManagement.GetInstance().GetAllPatients());
            }
        }
    }
}
