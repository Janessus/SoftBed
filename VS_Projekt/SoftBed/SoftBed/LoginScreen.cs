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

namespace SoftBed
{
    public partial class LoginScreen : Form
    {
        //const define of admin
        private const String sAdmin = "admin";
        private const String sAdminPW = "admin";

        private UserManagement userManage = UserManagement.GetInstance();
        
        

        public LoginScreen()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
        }

        /**
         * actionListener at loginBtn
         * tests wether user and pw are valid or not
         * and if it's admin and opens next GUI
         */
        private void loginBtn_Click(object sender, EventArgs e)
        {
            String sUser = userTxt.Text;
            String sPW = pwTxt.Text;

            if (sUser.Equals(sAdmin)  && sPW.Equals(sAdminPW)) //if admin, open adminbereich
            {
                openAdminbereich();
                UserManagement.GetInstance().UserLogin(sUser, sPW);
            }
            else if(sUser.Equals("") && sUser.Equals(""))
            {
                Message("hä", "Sorry aber nix eingeben bringt nix");
            }else if(sUser.Contains("Drop") || sPW.Contains("Drop") || sUser.Contains("DROP") || sPW.Contains("DROP"))
            {
                Message("Nice Try", "NENENE so nich");
            }else 
            {
                if (userManage.UserLogin(sUser, sPW) == true)   //if right username and password, open hauptfenster
                {
                    openHauptFenster();
                    UserManagement.GetInstance().UserLogin(sUser, sPW);
                }
                else
                {
                    noteLbl.Text = "Ungültiger Benutzer oder Passwort!";
                }
            }
        }


        /**
         * opens adminArea and hides LoginScreen
         */
        private void openAdminbereich()
        {
            this.SetVisibleCore(false);
            Form adminArea = new Adminbereich();
            adminArea.ShowDialog();
            this.SetVisibleCore(true);
        }



        /**
         * opens mainWindow and hides LoginScreen
         */
        private void openHauptFenster()
        {
            this.SetVisibleCore(false);
            Form mainWindow = new HauptFenster();
            mainWindow.ShowDialog();
            this.SetVisibleCore(true);
        }


        private void Message(string caption, string text)
        {
            MessageBoxButtons button = MessageBoxButtons.OK;

            DialogResult result = MessageBox.Show(text, caption, button);
        }
    }
}
