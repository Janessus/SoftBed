namespace SoftBed
{
    partial class HauptFenster
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
            this.gesKHProgBar = new SoftBed.NewProgressBar();
            this.transferListeDGV = new System.Windows.Forms.DataGridView();
            this.nameColmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameClmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vonClmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nachClmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progBarGesLbl = new System.Windows.Forms.Label();
            this.itsProgBar = new SoftBed.NewProgressBar();
            this.auslastungITSLbl = new System.Windows.Forms.Label();
            this.patVerwBtn = new System.Windows.Forms.Button();
            this.abmeldenBtn = new System.Windows.Forms.Button();
            this.verlAugefBtn = new System.Windows.Forms.Button();
            this.gynLbl = new System.Windows.Forms.Label();
            this.iMLbl = new System.Windows.Forms.Label();
            this.onkLbl = new System.Windows.Forms.Label();
            this.OrthLbl = new System.Windows.Forms.Label();
            this.pädLbl = new System.Windows.Forms.Label();
            this.gynProgBar = new SoftBed.NewProgressBar();
            this.iMProgBar = new SoftBed.NewProgressBar();
            this.onkProgBar = new SoftBed.NewProgressBar();
            this.orthProgBar = new SoftBed.NewProgressBar();
            this.paedProgBar = new SoftBed.NewProgressBar();
            this.bettbelegLbl = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelRechte = new System.Windows.Forms.Label();
            this.labelGyn = new System.Windows.Forms.Label();
            this.labelIm = new System.Windows.Forms.Label();
            this.labelOnk = new System.Windows.Forms.Label();
            this.labelOrth = new System.Windows.Forms.Label();
            this.labelPaed = new System.Windows.Forms.Label();
            this.labelIts = new System.Windows.Forms.Label();
            this.labelGes = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.transferListeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // gesKHProgBar
            // 
            this.gesKHProgBar.Enabled = false;
            this.gesKHProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.gesKHProgBar.Location = new System.Drawing.Point(12, 606);
            this.gesKHProgBar.Maximum = 260;
            this.gesKHProgBar.Name = "gesKHProgBar";
            this.gesKHProgBar.Size = new System.Drawing.Size(1138, 32);
            this.gesKHProgBar.TabIndex = 0;
            // 
            // transferListeDGV
            // 
            this.transferListeDGV.AllowUserToResizeColumns = false;
            this.transferListeDGV.AllowUserToResizeRows = false;
            this.transferListeDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.transferListeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transferListeDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColmn,
            this.firstNameClmn,
            this.vonClmn,
            this.nachClmn});
            this.transferListeDGV.Location = new System.Drawing.Point(707, 88);
            this.transferListeDGV.MultiSelect = false;
            this.transferListeDGV.Name = "transferListeDGV";
            this.transferListeDGV.RowHeadersVisible = false;
            this.transferListeDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.transferListeDGV.Size = new System.Drawing.Size(443, 401);
            this.transferListeDGV.TabIndex = 1;
            // 
            // nameColmn
            // 
            this.nameColmn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameColmn.HeaderText = "Nachname";
            this.nameColmn.Name = "nameColmn";
            // 
            // firstNameClmn
            // 
            this.firstNameClmn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.firstNameClmn.HeaderText = "Vorname";
            this.firstNameClmn.Name = "firstNameClmn";
            // 
            // vonClmn
            // 
            this.vonClmn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.vonClmn.HeaderText = "Von";
            this.vonClmn.Name = "vonClmn";
            // 
            // nachClmn
            // 
            this.nachClmn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nachClmn.HeaderText = "Nach";
            this.nachClmn.Name = "nachClmn";
            // 
            // progBarGesLbl
            // 
            this.progBarGesLbl.AutoSize = true;
            this.progBarGesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progBarGesLbl.Location = new System.Drawing.Point(12, 583);
            this.progBarGesLbl.Name = "progBarGesLbl";
            this.progBarGesLbl.Size = new System.Drawing.Size(222, 20);
            this.progBarGesLbl.TabIndex = 2;
            this.progBarGesLbl.Text = "Auslastung Betten gesamt";
            // 
            // itsProgBar
            // 
            this.itsProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.itsProgBar.Location = new System.Drawing.Point(12, 554);
            this.itsProgBar.Maximum = 10;
            this.itsProgBar.Name = "itsProgBar";
            this.itsProgBar.Size = new System.Drawing.Size(374, 26);
            this.itsProgBar.TabIndex = 3;
            // 
            // auslastungITSLbl
            // 
            this.auslastungITSLbl.AutoSize = true;
            this.auslastungITSLbl.BackColor = System.Drawing.Color.Transparent;
            this.auslastungITSLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auslastungITSLbl.Location = new System.Drawing.Point(8, 531);
            this.auslastungITSLbl.Name = "auslastungITSLbl";
            this.auslastungITSLbl.Size = new System.Drawing.Size(222, 20);
            this.auslastungITSLbl.TabIndex = 4;
            this.auslastungITSLbl.Text = "Auslastung Intensivstation";
            // 
            // patVerwBtn
            // 
            this.patVerwBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.patVerwBtn.Location = new System.Drawing.Point(147, 36);
            this.patVerwBtn.Name = "patVerwBtn";
            this.patVerwBtn.Size = new System.Drawing.Size(263, 167);
            this.patVerwBtn.TabIndex = 1;
            this.patVerwBtn.Text = "Patientenverwaltung...";
            this.patVerwBtn.UseVisualStyleBackColor = true;
            this.patVerwBtn.Click += new System.EventHandler(this.patVerwBtn_Click);
            // 
            // abmeldenBtn
            // 
            this.abmeldenBtn.Location = new System.Drawing.Point(1014, 12);
            this.abmeldenBtn.Name = "abmeldenBtn";
            this.abmeldenBtn.Size = new System.Drawing.Size(136, 32);
            this.abmeldenBtn.TabIndex = 2;
            this.abmeldenBtn.Text = "Abmelden";
            this.abmeldenBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.abmeldenBtn.UseVisualStyleBackColor = true;
            this.abmeldenBtn.Click += new System.EventHandler(this.abmeldenBtn_Click);
            // 
            // verlAugefBtn
            // 
            this.verlAugefBtn.Location = new System.Drawing.Point(1014, 489);
            this.verlAugefBtn.Name = "verlAugefBtn";
            this.verlAugefBtn.Size = new System.Drawing.Size(136, 32);
            this.verlAugefBtn.TabIndex = 3;
            this.verlAugefBtn.Text = "Verlegung ausgeführt";
            this.verlAugefBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.verlAugefBtn.UseVisualStyleBackColor = true;
            this.verlAugefBtn.Click += new System.EventHandler(this.verlAugefBtn_Click);
            // 
            // gynLbl
            // 
            this.gynLbl.AutoSize = true;
            this.gynLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gynLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.gynLbl.Location = new System.Drawing.Point(27, 306);
            this.gynLbl.Name = "gynLbl";
            this.gynLbl.Size = new System.Drawing.Size(97, 20);
            this.gynLbl.TabIndex = 8;
            this.gynLbl.Text = "Gynäkologie";
            // 
            // iMLbl
            // 
            this.iMLbl.AutoSize = true;
            this.iMLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iMLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iMLbl.Location = new System.Drawing.Point(13, 344);
            this.iMLbl.Name = "iMLbl";
            this.iMLbl.Size = new System.Drawing.Size(113, 20);
            this.iMLbl.TabIndex = 9;
            this.iMLbl.Text = "Innere Medizin";
            // 
            // onkLbl
            // 
            this.onkLbl.AutoSize = true;
            this.onkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onkLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.onkLbl.Location = new System.Drawing.Point(44, 386);
            this.onkLbl.Name = "onkLbl";
            this.onkLbl.Size = new System.Drawing.Size(80, 20);
            this.onkLbl.TabIndex = 10;
            this.onkLbl.Text = "Onkologie";
            // 
            // OrthLbl
            // 
            this.OrthLbl.AutoSize = true;
            this.OrthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrthLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OrthLbl.Location = new System.Drawing.Point(36, 426);
            this.OrthLbl.Name = "OrthLbl";
            this.OrthLbl.Size = new System.Drawing.Size(88, 20);
            this.OrthLbl.TabIndex = 11;
            this.OrthLbl.Text = "Orthopädie";
            // 
            // pädLbl
            // 
            this.pädLbl.AutoSize = true;
            this.pädLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pädLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pädLbl.Location = new System.Drawing.Point(53, 467);
            this.pädLbl.Name = "pädLbl";
            this.pädLbl.Size = new System.Drawing.Size(71, 20);
            this.pädLbl.TabIndex = 12;
            this.pädLbl.Text = "Pädiatrie";
            // 
            // gynProgBar
            // 
            this.gynProgBar.ForeColor = System.Drawing.Color.Black;
            this.gynProgBar.Location = new System.Drawing.Point(150, 300);
            this.gynProgBar.Maximum = 50;
            this.gynProgBar.Name = "gynProgBar";
            this.gynProgBar.Size = new System.Drawing.Size(374, 26);
            this.gynProgBar.TabIndex = 13;
            // 
            // iMProgBar
            // 
            this.iMProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.iMProgBar.Location = new System.Drawing.Point(150, 338);
            this.iMProgBar.Maximum = 50;
            this.iMProgBar.Name = "iMProgBar";
            this.iMProgBar.Size = new System.Drawing.Size(374, 26);
            this.iMProgBar.TabIndex = 14;
            // 
            // onkProgBar
            // 
            this.onkProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.onkProgBar.Location = new System.Drawing.Point(150, 380);
            this.onkProgBar.Maximum = 50;
            this.onkProgBar.Name = "onkProgBar";
            this.onkProgBar.Size = new System.Drawing.Size(374, 26);
            this.onkProgBar.TabIndex = 15;
            // 
            // orthProgBar
            // 
            this.orthProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.orthProgBar.Location = new System.Drawing.Point(150, 420);
            this.orthProgBar.Maximum = 50;
            this.orthProgBar.Name = "orthProgBar";
            this.orthProgBar.Size = new System.Drawing.Size(374, 26);
            this.orthProgBar.TabIndex = 16;
            // 
            // paedProgBar
            // 
            this.paedProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.paedProgBar.Location = new System.Drawing.Point(150, 461);
            this.paedProgBar.Maximum = 50;
            this.paedProgBar.Name = "paedProgBar";
            this.paedProgBar.Size = new System.Drawing.Size(374, 26);
            this.paedProgBar.TabIndex = 17;
            // 
            // bettbelegLbl
            // 
            this.bettbelegLbl.AutoSize = true;
            this.bettbelegLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bettbelegLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bettbelegLbl.Location = new System.Drawing.Point(146, 254);
            this.bettbelegLbl.Name = "bettbelegLbl";
            this.bettbelegLbl.Size = new System.Drawing.Size(158, 24);
            this.bettbelegLbl.TabIndex = 18;
            this.bettbelegLbl.Text = "Bettenbelegung";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(704, 31);
            this.labelUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(51, 13);
            this.labelUser.TabIndex = 19;
            this.labelUser.Text = "labelUser";
            // 
            // labelRechte
            // 
            this.labelRechte.AutoSize = true;
            this.labelRechte.Location = new System.Drawing.Point(818, 31);
            this.labelRechte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRechte.Name = "labelRechte";
            this.labelRechte.Size = new System.Drawing.Size(64, 13);
            this.labelRechte.TabIndex = 20;
            this.labelRechte.Text = "labelRechte";
            // 
            // labelGyn
            // 
            this.labelGyn.AutoSize = true;
            this.labelGyn.Location = new System.Drawing.Point(530, 306);
            this.labelGyn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGyn.Name = "labelGyn";
            this.labelGyn.Size = new System.Drawing.Size(48, 13);
            this.labelGyn.TabIndex = 21;
            this.labelGyn.Text = "labelGyn";
            // 
            // labelIm
            // 
            this.labelIm.AutoSize = true;
            this.labelIm.Location = new System.Drawing.Point(530, 344);
            this.labelIm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIm.Name = "labelIm";
            this.labelIm.Size = new System.Drawing.Size(40, 13);
            this.labelIm.TabIndex = 22;
            this.labelIm.Text = "labelIm";
            // 
            // labelOnk
            // 
            this.labelOnk.AutoSize = true;
            this.labelOnk.Location = new System.Drawing.Point(530, 386);
            this.labelOnk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOnk.Name = "labelOnk";
            this.labelOnk.Size = new System.Drawing.Size(49, 13);
            this.labelOnk.TabIndex = 23;
            this.labelOnk.Text = "labelOnk";
            // 
            // labelOrth
            // 
            this.labelOrth.AutoSize = true;
            this.labelOrth.Location = new System.Drawing.Point(530, 426);
            this.labelOrth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrth.Name = "labelOrth";
            this.labelOrth.Size = new System.Drawing.Size(49, 13);
            this.labelOrth.TabIndex = 24;
            this.labelOrth.Text = "labelOrth";
            // 
            // labelPaed
            // 
            this.labelPaed.AutoSize = true;
            this.labelPaed.Location = new System.Drawing.Point(530, 467);
            this.labelPaed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPaed.Name = "labelPaed";
            this.labelPaed.Size = new System.Drawing.Size(54, 13);
            this.labelPaed.TabIndex = 25;
            this.labelPaed.Text = "labelPaed";
            // 
            // labelIts
            // 
            this.labelIts.AutoSize = true;
            this.labelIts.Location = new System.Drawing.Point(231, 537);
            this.labelIts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIts.Name = "labelIts";
            this.labelIts.Size = new System.Drawing.Size(40, 13);
            this.labelIts.TabIndex = 26;
            this.labelIts.Text = "labelIts";
            // 
            // labelGes
            // 
            this.labelGes.AutoSize = true;
            this.labelGes.Location = new System.Drawing.Point(231, 589);
            this.labelGes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGes.Name = "labelGes";
            this.labelGes.Size = new System.Drawing.Size(48, 13);
            this.labelGes.TabIndex = 27;
            this.labelGes.Text = "labelGes";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(707, 489);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(2);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(136, 32);
            this.refreshButton.TabIndex = 28;
            this.refreshButton.Text = "Aktualisieren";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // HauptFenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1162, 645);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.labelGes);
            this.Controls.Add(this.labelIts);
            this.Controls.Add(this.labelPaed);
            this.Controls.Add(this.labelOrth);
            this.Controls.Add(this.labelOnk);
            this.Controls.Add(this.labelIm);
            this.Controls.Add(this.labelGyn);
            this.Controls.Add(this.labelRechte);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.bettbelegLbl);
            this.Controls.Add(this.paedProgBar);
            this.Controls.Add(this.orthProgBar);
            this.Controls.Add(this.onkProgBar);
            this.Controls.Add(this.iMProgBar);
            this.Controls.Add(this.gynProgBar);
            this.Controls.Add(this.pädLbl);
            this.Controls.Add(this.OrthLbl);
            this.Controls.Add(this.onkLbl);
            this.Controls.Add(this.iMLbl);
            this.Controls.Add(this.gynLbl);
            this.Controls.Add(this.verlAugefBtn);
            this.Controls.Add(this.abmeldenBtn);
            this.Controls.Add(this.patVerwBtn);
            this.Controls.Add(this.auslastungITSLbl);
            this.Controls.Add(this.itsProgBar);
            this.Controls.Add(this.progBarGesLbl);
            this.Controls.Add(this.transferListeDGV);
            this.Controls.Add(this.gesKHProgBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HauptFenster";
            this.Text = "HauptFenster";
            ((System.ComponentModel.ISupportInitialize)(this.transferListeDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView transferListeDGV;
        private System.Windows.Forms.Label progBarGesLbl;
        private System.Windows.Forms.Label auslastungITSLbl;
        private System.Windows.Forms.Button patVerwBtn;
        private System.Windows.Forms.Button abmeldenBtn;
        private System.Windows.Forms.Button verlAugefBtn;
        private System.Windows.Forms.Label gynLbl;
        private System.Windows.Forms.Label iMLbl;
        private System.Windows.Forms.Label onkLbl;
        private System.Windows.Forms.Label OrthLbl;
        private System.Windows.Forms.Label pädLbl;
        private System.Windows.Forms.Label bettbelegLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameClmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vonClmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nachClmn;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelRechte;
        private System.Windows.Forms.Label labelGyn;
        private System.Windows.Forms.Label labelIm;
        private System.Windows.Forms.Label labelOnk;
        private System.Windows.Forms.Label labelOrth;
        private System.Windows.Forms.Label labelPaed;
        private System.Windows.Forms.Label labelIts;
        private System.Windows.Forms.Label labelGes;
        private System.Windows.Forms.Button refreshButton;
        private NewProgressBar gesKHProgBar;
        private NewProgressBar itsProgBar;
        private NewProgressBar gynProgBar;
        private NewProgressBar iMProgBar;
        private NewProgressBar onkProgBar;
        private NewProgressBar orthProgBar;
        private NewProgressBar paedProgBar;
    }
}