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
            userManage.UserAnlegen(readUserFromGUI());
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
            pUser.Passwort = getRadioBtnValue();
            return pUser;
        }
    }
}