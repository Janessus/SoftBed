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

            label1.Text = "User: " + UserManagement.CurrentUser.Benutzername;
            label2.Text = "Rechte: " + UserManagement.CurrentUser.Rechte;
        }

        private void patVerwBtn_Click(object sender, EventArgs e)
        {
            openPatientenVerwaltung();
        }

        private void verlAugefBtn_Click(object sender, EventArgs e)
        {
            if (UserManagement.CurrentUser.Rechte == "Standard")
            {
                if (showTransferConfirmingDialog() == DialogResult.Yes && showTransferConfirmingDialog() == DialogResult.Yes)
                {
                    DataGridViewSelectedRowCollection selectedRows = transferListeDGV.SelectedRows;

                    ZimmerManagement.GetInstance().DeleteMemberTransferliste(selectedRows[0].Cells[0].Value.ToString(), selectedRows[0].Cells[1].Value.ToString());  //klappt vielleicht

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

        private void RefreshHauptfenster()
        {
            RefreshBettenbelegung();
            RefreshVerlegungsliste();
        }

        private void RefreshBettenbelegung()
        {
            


            Bettenbelegung currentBelegung = UpdateManagement.GetInstance().GetCurrentBettenbelegung();
            gynProgBar.Value = currentBelegung.Gynaekologie;
            labelGyn.Text = currentBelegung.Gynaekologie.ToString();
            iMProgBar.Value = currentBelegung.Innere;
            labelIm.Text = currentBelegung.Innere.ToString();
            onkProgBar.Value = currentBelegung.Onkologie;
            labelOnk.Text = currentBelegung.Onkologie.ToString();
            orthProgBar.Value = currentBelegung.Orthopaedie;
            labelOrth.Text = currentBelegung.Orthopaedie.ToString();
            paedProgBar.Value = currentBelegung.Paediatrie;
            labelPaed.Text = currentBelegung.Paediatrie.ToString();
            itsProgBar.Value = currentBelegung.Intensiv;
            labelIts.Text = currentBelegung.Intensiv.ToString();
            gesKHProgBar.Value = currentBelegung.Gesamt();
            labelGes.Text = currentBelegung.Gesamt().ToString();
        }

        private void RefreshVerlegungsliste()
        {
            Verlegungsliste currentVerlegungsliste = UpdateManagement.GetInstance().GetCurrentVerlegungsliste();
            for(int i = 0; i < currentVerlegungsliste.Transferliste.Count; i++)
            {
                transferListeDGV.Rows.Add(currentVerlegungsliste.Transferliste.ToArray()[i]);     //klappt vielleicht
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

        private void itsProgBar_Click(object sender, EventArgs e)
        {

        }

        private void HauptFenster_MouseEnter(object sender, EventArgs e)
        {
            RefreshHauptfenster();
        }
    }
}
