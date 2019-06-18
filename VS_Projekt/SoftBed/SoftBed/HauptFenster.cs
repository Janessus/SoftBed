using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Wrapperklassen;

namespace SoftBed
{
    public partial class HauptFenster : Form
    {
        public HauptFenster()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);

            RefreshHauptfenster();  //refresh everything

            labelUser.Text = "User: " + UserManagement.CurrentUser.Benutzername;
            labelRechte.Text = "Rechte: " + UserManagement.CurrentUser.Rechte;

        }

        /**
         * button that opens Patientenverwaltung
         */
        private void patVerwBtn_Click(object sender, EventArgs e)
        {
            openPatientenVerwaltung();
        }

        /**
         * button that validates, that transfer is complete
         */
        private void verlAugefBtn_Click(object sender, EventArgs e)
        {
            if (UserManagement.CurrentUser.Rechte == "Standard")    //if user has standard rights
            {
                if (showTransferConfirmingDialog() == DialogResult.Yes && showTransferConfirmingDialog() == DialogResult.Yes)   //if user confirmed
                {
                    DataGridViewSelectedRowCollection selectedRows = transferListeDGV.SelectedRows;

                    if(selectedRows.Count != 0) //if a row is selected
                    {
                        ZimmerManagement.GetInstance().DeleteMemberTransferliste(selectedRows[0].Cells[1].Value.ToString(), selectedRows[0].Cells[0].Value.ToString());
                    }
                    
                    RefreshHauptfenster();
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
         * button for logout
         */
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

        /**
         * refreshes Transferlist and progressbars
         */
        private void RefreshHauptfenster()
        {
            RefreshBettenbelegung();
            RefreshVerlegungsliste();
        }

        /**
         * refreshes progressbars
         */
        private void RefreshBettenbelegung()
        {
            Bettenbelegung currentBelegung = UpdateManagement.GetInstance().GetCurrentBettenbelegung();
            gynProgBar.Value = currentBelegung.Gynaekologie;
            labelGyn.Text = currentBelegung.Gynaekologie.ToString();
            RefreshBettenbelegungColor(gynProgBar);
            iMProgBar.Value = currentBelegung.Innere;
            labelIm.Text = currentBelegung.Innere.ToString();
            RefreshBettenbelegungColor(iMProgBar);
            onkProgBar.Value = currentBelegung.Onkologie;
            labelOnk.Text = currentBelegung.Onkologie.ToString();
            RefreshBettenbelegungColor(onkProgBar);
            orthProgBar.Value = currentBelegung.Orthopaedie;
            labelOrth.Text = currentBelegung.Orthopaedie.ToString();
            RefreshBettenbelegungColor(orthProgBar);
            paedProgBar.Value = currentBelegung.Paediatrie;
            labelPaed.Text = currentBelegung.Paediatrie.ToString();
            RefreshBettenbelegungColor(paedProgBar);
            itsProgBar.Value = currentBelegung.Intensiv;
            labelIts.Text = currentBelegung.Intensiv.ToString();
            RefreshBettenbelegungColor(itsProgBar);
            gesKHProgBar.Value = currentBelegung.Gesamt();
            labelGes.Text = currentBelegung.Gesamt().ToString();
            RefreshBettenbelegungColor(gesKHProgBar);
        }

        private void RefreshBettenbelegungColor(ProgressBar pb)
        {
            int max = pb.Maximum;
            if (pb.Value < (max * 0.8))
                ModifyProgressBarColor.SetState(pb, 1);
            else if (pb.Value < (max * 0.9))
                ModifyProgressBarColor.SetState(pb, 3);
            else
                ModifyProgressBarColor.SetState(pb, 2);
        }
        
        /**
         * refreshes Transferlist
         */
        private void RefreshVerlegungsliste()
        {
            Verlegungsliste currentVerlegungsliste = UpdateManagement.GetInstance().GetCurrentVerlegungsliste();

            transferListeDGV.Rows.Clear();

            for (int i = 0; i < currentVerlegungsliste.Transferliste.Count; i++)
            {
                
                transferListeDGV.Rows.Add(currentVerlegungsliste.Transferliste.ToArray()[i].Person.Nachname, currentVerlegungsliste.Transferliste.ToArray()[i].Person.Vorname, currentVerlegungsliste.Transferliste.ToArray()[i].Von, currentVerlegungsliste.Transferliste.ToArray()[i].Nach);
            }
        }


        /**
         * shows dialog for User to confirm transfering
         * @return which button has been clicked
         */
        private DialogResult showTransferConfirmingDialog()
        {
            string messageBoxText = "Wurde die Verlegung ausgeführt? Wollen Sie den ausgewählten Patienten wirklich aus der Transferliste löschen?";
            string caption = "Bestätigung";
            MessageBoxButtons button = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(messageBoxText, caption, button);

            return result;
        }

        /**
         * mouse enter event for refreshes
         */
        private void HauptFenster_MouseEnter(object sender, EventArgs e)
        {
            RefreshHauptfenster();
        }

        private void TransferListeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
