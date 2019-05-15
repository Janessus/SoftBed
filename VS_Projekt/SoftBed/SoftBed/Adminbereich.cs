using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wrapperklassen;

namespace SoftBed
{
    public partial class Adminbereich : Form
    {
        private UserManagement userManage = UserManagement.GetInstance();

        public Adminbereich()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
        }


        /**
         * Action Listener for zurück Button
         * closes Admin Window
         * todo: needs to show login Screen again!!
         */
        private void zurueckBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /**
         * ActionListener for Benutzer anlegen Button
         * sets all user components
         * and calls UserManagementmethod to add new User in DB
         */
        private void usrAnlBtn_Click(object sender, EventArgs e)
        {
            bool done = userManage.UserAnlegen(readUserFromGUI());
            if (done == false)
            {
                MessageBox.Show("ungültige Eingabe!");
            }
        }



        /**
         * opens adminArea and hides LoginScreen
         */
        private String getRadioBtnValue()
        {
            if (standardRadBtn.AutoCheck == true)
            {
                return "Standard";
            }
            else
            {
                return "Praktikant";
            }
        }



        /**
         * reads all Data of new User into an object
         * returns User Object
         */
        private User readUserFromGUI()
        {
            User pUser = new User();
            pUser.Benutzername = userTxt.Text;
            pUser.Passwort = pwTxt.Text;
            pUser.Rechte = getRadioBtnValue();
            return pUser;
        }

        private void btnLoeschen_Click(object sender, EventArgs e)
        {
            if (userTxt.Text != String.Empty)
            {
                if (showUserDeleteConfirmingDialog() == DialogResult.Yes)
                {
                    userManage.UserLöschen(userTxt.Text);

                }
            }
            
        }

        /**
         * shows dialog for Admin to confirm deleting User
         * @return which button has been clicked
         */
        private DialogResult showUserDeleteConfirmingDialog()
        {
            string messageBoxText = "Wollen Sie den User wirklich aus dem System löschen?";
            string caption = "Bestätigung";
            MessageBoxButtons button = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(messageBoxText, caption, button);

            return result;
        }
    }
}