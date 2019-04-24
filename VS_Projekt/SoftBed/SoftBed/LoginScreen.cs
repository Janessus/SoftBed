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
        public const String sAdmin = "admin";
        public const String sAdminPW = "admin";


        public LoginScreen()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            String sUser = userTxt.Text;
            String sPW = pwTxt.Text;

            if (sUser == sAdmin && sPW == sAdminPW)
            {

            }
            else
            {

            }

        }
    }
}
