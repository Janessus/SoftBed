namespace SoftBed
{
    partial class LoginScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.loginLbl = new System.Windows.Forms.Label();
            this.userTxt = new System.Windows.Forms.TextBox();
            this.pwTxt = new System.Windows.Forms.TextBox();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.noteLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLbl.Location = new System.Drawing.Point(646, 452);
            this.loginLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(170, 67);
            this.loginLbl.TabIndex = 0;
            this.loginLbl.Text = "Login";
            // 
            // userTxt
            // 
            this.userTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTxt.Location = new System.Drawing.Point(658, 556);
            this.userTxt.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.userTxt.Name = "userTxt";
            this.userTxt.Size = new System.Drawing.Size(270, 44);
            this.userTxt.TabIndex = 1;
            this.userTxt.Text = "Schokokeks";
            // 
            // pwTxt
            // 
            this.pwTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwTxt.Location = new System.Drawing.Point(656, 623);
            this.pwTxt.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pwTxt.Name = "pwTxt";
            this.pwTxt.PasswordChar = '*';
            this.pwTxt.Size = new System.Drawing.Size(272, 44);
            this.pwTxt.TabIndex = 2;
            this.pwTxt.Text = "schokolade";
            // 
            // logoBox
            // 
            this.logoBox.Image = ((System.Drawing.Image)(resources.GetObject("logoBox.Image")));
            this.logoBox.Location = new System.Drawing.Point(506, 67);
            this.logoBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(554, 356);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoBox.TabIndex = 3;
            this.logoBox.TabStop = false;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.loginBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(162)))), ((int)(((byte)(62)))));
            this.loginBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(162)))), ((int)(((byte)(62)))));
            this.loginBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(162)))), ((int)(((byte)(62)))));
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(656, 700);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(276, 69);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "anmelden";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // noteLbl
            // 
            this.noteLbl.AutoSize = true;
            this.noteLbl.ForeColor = System.Drawing.Color.Brown;
            this.noteLbl.Location = new System.Drawing.Point(628, 798);
            this.noteLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(0, 25);
            this.noteLbl.TabIndex = 5;
            // 
            // LoginScreen
            // 
            this.AcceptButton = this.loginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.noteLbl);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.pwTxt);
            this.Controls.Add(this.userTxt);
            this.Controls.Add(this.loginLbl);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "LoginScreen";
            this.Text = "LoginScreen";
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLbl;
        private System.Windows.Forms.TextBox userTxt;
        private System.Windows.Forms.TextBox pwTxt;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label noteLbl;
    }
}

