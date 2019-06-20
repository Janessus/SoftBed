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
using System.Drawing.Drawing2D;

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
                        Patient p = new Patient();
                        p.Nachname = selectedRows[0].Cells[0].Value.ToString();
                        p.Vorname = selectedRows[0].Cells[1].Value.ToString();
                        p.Station = selectedRows[0].Cells[2].Value.ToString();  //von
                        ZimmerManagement.GetInstance().DeleteMemberTransferliste(p.Vorname, p.Nachname);
                        DatabaseManagement.GetInstance().BedGotFree(p);
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
            labelGyn.Text = currentBelegung.Gynaekologie.ToString() + "/50";
            RefreshColorProgBar(gynProgBar);
            iMProgBar.Value = currentBelegung.Innere;
            labelIm.Text = currentBelegung.Innere.ToString() + "/50";
            RefreshColorProgBar(iMProgBar);
            onkProgBar.Value = currentBelegung.Onkologie;
            labelOnk.Text = currentBelegung.Onkologie.ToString() + "/50";
            RefreshColorProgBar(onkProgBar);
            orthProgBar.Value = currentBelegung.Orthopaedie;
            labelOrth.Text = currentBelegung.Orthopaedie.ToString() + "/50";
            RefreshColorProgBar(orthProgBar);
            paedProgBar.Value = currentBelegung.Paediatrie;
            labelPaed.Text = currentBelegung.Paediatrie.ToString() + "/50";
            RefreshColorProgBar(paedProgBar);
            itsProgBar.Value = currentBelegung.Intensiv;
            labelIts.Text = currentBelegung.Intensiv.ToString() + "/10";
            RefreshColorProgBar(itsProgBar);
            gesKHProgBar.Value = currentBelegung.Gesamt();
            labelGes.Text = currentBelegung.Gesamt().ToString() + "/260";
            RefreshColorProgBar(gesKHProgBar);
        }

        private void RefreshColorProgBar(ProgressBar pb)
        {
            if (pb.Value > (pb.Maximum * 0.9))
            {
                pb.BackColor = Color.Coral;
                pb.ForeColor = Color.Crimson;
            }else if(pb.Value > (pb.Maximum * 0.8))
            {
                pb.BackColor = Color.PaleGoldenrod;
                pb.ForeColor = Color.Gold;
            }
            else
            {
                pb.BackColor = Color.GreenYellow;
                pb.ForeColor = Color.YellowGreen;
            }

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

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshHauptfenster();
        }
    }

    public class NewProgressBar : ProgressBar
    {
        public NewProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // None... Helps control the flicker.
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            const int inset = 2; // A single inset value to control teh sizing of the inner rect.

            using (Image offscreenImage = new Bitmap(this.Width, this.Height))
            {
                using (Graphics offscreen = Graphics.FromImage(offscreenImage))
                {
                    Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                    if (ProgressBarRenderer.IsSupported)
                        ProgressBarRenderer.DrawHorizontalBar(offscreen, rect);

                    rect.Inflate(new Size(-inset, -inset)); // Deflate inner rect.
                    rect.Width = (int)(rect.Width * ((double)this.Value / this.Maximum));
                    if (rect.Width == 0) rect.Width = 1; // Can't draw rec with width of 0.

                    LinearGradientBrush brush = new LinearGradientBrush(rect, this.BackColor, this.ForeColor, LinearGradientMode.Vertical);
                    offscreen.FillRectangle(brush, inset, inset, rect.Width, rect.Height);

                    e.Graphics.DrawImage(offscreenImage, 0, 0);
                    offscreenImage.Dispose();
                }
            }
        }
    }
}
