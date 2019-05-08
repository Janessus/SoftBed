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
            Task refreshTask = new Task(()=>{
                while (true)
                {
                    //RefreshHauptfenster();
                    Thread.Sleep(30000);
                }
            });
            refreshTask.Start();
        }

        private void patVerwBtn_Click(object sender, EventArgs e)
        {
            openPatientenVerwaltung();
        }

        private void verlAugefBtn_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = transferListeDGV.SelectedRows;
            for(int i = 0; i < selectedRows.Count; i++)
            {
                ZimmerManagement.GetInstance().DeleteMemberTransferliste(selectedRows[i].Cells[0].Value.ToString(),selectedRows[i].Cells[1].Value.ToString());  //klappt vielleicht
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
            iMProgBar.Value = currentBelegung.Innere;
            onkProgBar.Value = currentBelegung.Onkologie;
            orthProgBar.Value = currentBelegung.Orthopaedie;
            paedProgBar.Value = currentBelegung.Paediatrie;
            itsProgBar.Value = currentBelegung.Intensiv;
            gesKHProgBar.Value = currentBelegung.Gesamt();
        }

        private void RefreshVerlegungsliste()
        {
            Verlegungsliste currentVerlegungsliste = UpdateManagement.GetInstance().GetCurrentVerlegungsliste();
            for(int i = 0; i < currentVerlegungsliste.Transferliste.Count; i++)
            {
                transferListeDGV.Rows.Add(currentVerlegungsliste.Transferliste[i]);     //klappt vielleicht
            }
        }
    }
}
