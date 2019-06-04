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
            this.gesKHProgBar = new System.Windows.Forms.ProgressBar();
            this.transferListeDGV = new System.Windows.Forms.DataGridView();
            this.nameColmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameClmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vonClmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nachClmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progBarGesLbl = new System.Windows.Forms.Label();
            this.itsProgBar = new System.Windows.Forms.ProgressBar();
            this.auslastungITSLbl = new System.Windows.Forms.Label();
            this.patVerwBtn = new System.Windows.Forms.Button();
            this.abmeldenBtn = new System.Windows.Forms.Button();
            this.verlAugefBtn = new System.Windows.Forms.Button();
            this.gynLbl = new System.Windows.Forms.Label();
            this.iMLbl = new System.Windows.Forms.Label();
            this.onkLbl = new System.Windows.Forms.Label();
            this.OrthLbl = new System.Windows.Forms.Label();
            this.pädLbl = new System.Windows.Forms.Label();
            this.gynProgBar = new System.Windows.Forms.ProgressBar();
            this.iMProgBar = new System.Windows.Forms.ProgressBar();
            this.onkProgBar = new System.Windows.Forms.ProgressBar();
            this.orthProgBar = new System.Windows.Forms.ProgressBar();
            this.paedProgBar = new System.Windows.Forms.ProgressBar();
            this.bettbelegLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelGyn = new System.Windows.Forms.Label();
            this.labelIm = new System.Windows.Forms.Label();
            this.labelOnk = new System.Windows.Forms.Label();
            this.labelOrth = new System.Windows.Forms.Label();
            this.labelPaed = new System.Windows.Forms.Label();
            this.labelIts = new System.Windows.Forms.Label();
            this.labelGes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.transferListeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // gesKHProgBar
            // 
            this.gesKHProgBar.Enabled = false;
            this.gesKHProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.gesKHProgBar.Location = new System.Drawing.Point(16, 746);
            this.gesKHProgBar.Margin = new System.Windows.Forms.Padding(4);
            this.gesKHProgBar.Maximum = 260;
            this.gesKHProgBar.Name = "gesKHProgBar";
            this.gesKHProgBar.Size = new System.Drawing.Size(1517, 39);
            this.gesKHProgBar.TabIndex = 0;
            // 
            // transferListeDGV
            // 
            this.transferListeDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.transferListeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transferListeDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColmn,
            this.firstNameClmn,
            this.vonClmn,
            this.nachClmn});
            this.transferListeDGV.Enabled = false;
            this.transferListeDGV.Location = new System.Drawing.Point(943, 108);
            this.transferListeDGV.Margin = new System.Windows.Forms.Padding(4);
            this.transferListeDGV.MultiSelect = false;
            this.transferListeDGV.Name = "transferListeDGV";
            this.transferListeDGV.RowHeadersVisible = false;
            this.transferListeDGV.Size = new System.Drawing.Size(591, 494);
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
            this.progBarGesLbl.Location = new System.Drawing.Point(16, 718);
            this.progBarGesLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.progBarGesLbl.Name = "progBarGesLbl";
            this.progBarGesLbl.Size = new System.Drawing.Size(264, 25);
            this.progBarGesLbl.TabIndex = 2;
            this.progBarGesLbl.Text = "Auslastung Betten gesamt";
            // 
            // itsProgBar
            // 
            this.itsProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.itsProgBar.Location = new System.Drawing.Point(16, 682);
            this.itsProgBar.Margin = new System.Windows.Forms.Padding(4);
            this.itsProgBar.Maximum = 10;
            this.itsProgBar.Name = "itsProgBar";
            this.itsProgBar.Size = new System.Drawing.Size(499, 32);
            this.itsProgBar.TabIndex = 3;
            this.itsProgBar.Click += new System.EventHandler(this.itsProgBar_Click);
            // 
            // auslastungITSLbl
            // 
            this.auslastungITSLbl.AutoSize = true;
            this.auslastungITSLbl.BackColor = System.Drawing.Color.Transparent;
            this.auslastungITSLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auslastungITSLbl.Location = new System.Drawing.Point(11, 654);
            this.auslastungITSLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.auslastungITSLbl.Name = "auslastungITSLbl";
            this.auslastungITSLbl.Size = new System.Drawing.Size(265, 25);
            this.auslastungITSLbl.TabIndex = 4;
            this.auslastungITSLbl.Text = "Auslastung Intensivstation";
            // 
            // patVerwBtn
            // 
            this.patVerwBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.patVerwBtn.Location = new System.Drawing.Point(196, 44);
            this.patVerwBtn.Margin = new System.Windows.Forms.Padding(4);
            this.patVerwBtn.Name = "patVerwBtn";
            this.patVerwBtn.Size = new System.Drawing.Size(351, 206);
            this.patVerwBtn.TabIndex = 1;
            this.patVerwBtn.Text = "Patientenverwaltung...";
            this.patVerwBtn.UseVisualStyleBackColor = true;
            this.patVerwBtn.Click += new System.EventHandler(this.patVerwBtn_Click);
            // 
            // abmeldenBtn
            // 
            this.abmeldenBtn.Location = new System.Drawing.Point(1352, 15);
            this.abmeldenBtn.Margin = new System.Windows.Forms.Padding(4);
            this.abmeldenBtn.Name = "abmeldenBtn";
            this.abmeldenBtn.Size = new System.Drawing.Size(181, 39);
            this.abmeldenBtn.TabIndex = 2;
            this.abmeldenBtn.Text = "Abmelden";
            this.abmeldenBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.abmeldenBtn.UseVisualStyleBackColor = true;
            this.abmeldenBtn.Click += new System.EventHandler(this.abmeldenBtn_Click);
            // 
            // verlAugefBtn
            // 
            this.verlAugefBtn.Location = new System.Drawing.Point(1352, 620);
            this.verlAugefBtn.Margin = new System.Windows.Forms.Padding(4);
            this.verlAugefBtn.Name = "verlAugefBtn";
            this.verlAugefBtn.Size = new System.Drawing.Size(181, 39);
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
            this.gynLbl.Location = new System.Drawing.Point(36, 377);
            this.gynLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gynLbl.Name = "gynLbl";
            this.gynLbl.Size = new System.Drawing.Size(121, 25);
            this.gynLbl.TabIndex = 8;
            this.gynLbl.Text = "Gynäkologie";
            // 
            // iMLbl
            // 
            this.iMLbl.AutoSize = true;
            this.iMLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iMLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iMLbl.Location = new System.Drawing.Point(17, 423);
            this.iMLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.iMLbl.Name = "iMLbl";
            this.iMLbl.Size = new System.Drawing.Size(139, 25);
            this.iMLbl.TabIndex = 9;
            this.iMLbl.Text = "innere Medizin";
            // 
            // onkLbl
            // 
            this.onkLbl.AutoSize = true;
            this.onkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onkLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.onkLbl.Location = new System.Drawing.Point(59, 475);
            this.onkLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.onkLbl.Name = "onkLbl";
            this.onkLbl.Size = new System.Drawing.Size(101, 25);
            this.onkLbl.TabIndex = 10;
            this.onkLbl.Text = "Onkologie";
            // 
            // OrthLbl
            // 
            this.OrthLbl.AutoSize = true;
            this.OrthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrthLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OrthLbl.Location = new System.Drawing.Point(48, 524);
            this.OrthLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OrthLbl.Name = "OrthLbl";
            this.OrthLbl.Size = new System.Drawing.Size(109, 25);
            this.OrthLbl.TabIndex = 11;
            this.OrthLbl.Text = "Orthopädie";
            // 
            // pädLbl
            // 
            this.pädLbl.AutoSize = true;
            this.pädLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pädLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pädLbl.Location = new System.Drawing.Point(71, 575);
            this.pädLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pädLbl.Name = "pädLbl";
            this.pädLbl.Size = new System.Drawing.Size(88, 25);
            this.pädLbl.TabIndex = 12;
            this.pädLbl.Text = "Pädiatrie";
            // 
            // gynProgBar
            // 
            this.gynProgBar.ForeColor = System.Drawing.Color.Black;
            this.gynProgBar.Location = new System.Drawing.Point(200, 369);
            this.gynProgBar.Margin = new System.Windows.Forms.Padding(4);
            this.gynProgBar.Maximum = 50;
            this.gynProgBar.Name = "gynProgBar";
            this.gynProgBar.Size = new System.Drawing.Size(499, 32);
            this.gynProgBar.TabIndex = 13;
            // 
            // iMProgBar
            // 
            this.iMProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.iMProgBar.Location = new System.Drawing.Point(200, 416);
            this.iMProgBar.Margin = new System.Windows.Forms.Padding(4);
            this.iMProgBar.Maximum = 50;
            this.iMProgBar.Name = "iMProgBar";
            this.iMProgBar.Size = new System.Drawing.Size(499, 32);
            this.iMProgBar.TabIndex = 14;
            // 
            // onkProgBar
            // 
            this.onkProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.onkProgBar.Location = new System.Drawing.Point(200, 468);
            this.onkProgBar.Margin = new System.Windows.Forms.Padding(4);
            this.onkProgBar.Maximum = 50;
            this.onkProgBar.Name = "onkProgBar";
            this.onkProgBar.Size = new System.Drawing.Size(499, 32);
            this.onkProgBar.TabIndex = 15;
            // 
            // orthProgBar
            // 
            this.orthProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.orthProgBar.Location = new System.Drawing.Point(200, 517);
            this.orthProgBar.Margin = new System.Windows.Forms.Padding(4);
            this.orthProgBar.Maximum = 50;
            this.orthProgBar.Name = "orthProgBar";
            this.orthProgBar.Size = new System.Drawing.Size(499, 32);
            this.orthProgBar.TabIndex = 16;
            // 
            // paedProgBar
            // 
            this.paedProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.paedProgBar.Location = new System.Drawing.Point(200, 567);
            this.paedProgBar.Margin = new System.Windows.Forms.Padding(4);
            this.paedProgBar.Maximum = 50;
            this.paedProgBar.Name = "paedProgBar";
            this.paedProgBar.Size = new System.Drawing.Size(499, 32);
            this.paedProgBar.TabIndex = 17;
            // 
            // bettbelegLbl
            // 
            this.bettbelegLbl.AutoSize = true;
            this.bettbelegLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bettbelegLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bettbelegLbl.Location = new System.Drawing.Point(195, 313);
            this.bettbelegLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bettbelegLbl.Name = "bettbelegLbl";
            this.bettbelegLbl.Size = new System.Drawing.Size(198, 29);
            this.bettbelegLbl.TabIndex = 18;
            this.bettbelegLbl.Text = "Bettenbelegung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1013, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1151, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "label2";
            // 
            // labelGyn
            // 
            this.labelGyn.AutoSize = true;
            this.labelGyn.Location = new System.Drawing.Point(707, 377);
            this.labelGyn.Name = "labelGyn";
            this.labelGyn.Size = new System.Drawing.Size(64, 17);
            this.labelGyn.TabIndex = 21;
            this.labelGyn.Text = "labelGyn";
            // 
            // labelIm
            // 
            this.labelIm.AutoSize = true;
            this.labelIm.Location = new System.Drawing.Point(707, 423);
            this.labelIm.Name = "labelIm";
            this.labelIm.Size = new System.Drawing.Size(52, 17);
            this.labelIm.TabIndex = 22;
            this.labelIm.Text = "labelIm";
            // 
            // labelOnk
            // 
            this.labelOnk.AutoSize = true;
            this.labelOnk.Location = new System.Drawing.Point(707, 475);
            this.labelOnk.Name = "labelOnk";
            this.labelOnk.Size = new System.Drawing.Size(64, 17);
            this.labelOnk.TabIndex = 23;
            this.labelOnk.Text = "labelOnk";
            // 
            // labelOrth
            // 
            this.labelOrth.AutoSize = true;
            this.labelOrth.Location = new System.Drawing.Point(707, 524);
            this.labelOrth.Name = "labelOrth";
            this.labelOrth.Size = new System.Drawing.Size(66, 17);
            this.labelOrth.TabIndex = 24;
            this.labelOrth.Text = "labelOrth";
            // 
            // labelPaed
            // 
            this.labelPaed.AutoSize = true;
            this.labelPaed.Location = new System.Drawing.Point(707, 575);
            this.labelPaed.Name = "labelPaed";
            this.labelPaed.Size = new System.Drawing.Size(71, 17);
            this.labelPaed.TabIndex = 25;
            this.labelPaed.Text = "labelPaed";
            // 
            // labelIts
            // 
            this.labelIts.AutoSize = true;
            this.labelIts.Location = new System.Drawing.Point(308, 661);
            this.labelIts.Name = "labelIts";
            this.labelIts.Size = new System.Drawing.Size(52, 17);
            this.labelIts.TabIndex = 26;
            this.labelIts.Text = "labelIts";
            // 
            // labelGes
            // 
            this.labelGes.AutoSize = true;
            this.labelGes.Location = new System.Drawing.Point(308, 725);
            this.labelGes.Name = "labelGes";
            this.labelGes.Size = new System.Drawing.Size(64, 17);
            this.labelGes.TabIndex = 27;
            this.labelGes.Text = "labelGes";
            // 
            // HauptFenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1549, 794);
            this.Controls.Add(this.labelGes);
            this.Controls.Add(this.labelIts);
            this.Controls.Add(this.labelPaed);
            this.Controls.Add(this.labelOrth);
            this.Controls.Add(this.labelOnk);
            this.Controls.Add(this.labelIm);
            this.Controls.Add(this.labelGyn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HauptFenster";
            this.Text = "HauptFenster";
            this.MouseEnter += new System.EventHandler(this.HauptFenster_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.transferListeDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar gesKHProgBar;
        private System.Windows.Forms.DataGridView transferListeDGV;
        private System.Windows.Forms.Label progBarGesLbl;
        private System.Windows.Forms.ProgressBar itsProgBar;
        private System.Windows.Forms.Label auslastungITSLbl;
        private System.Windows.Forms.Button patVerwBtn;
        private System.Windows.Forms.Button abmeldenBtn;
        private System.Windows.Forms.Button verlAugefBtn;
        private System.Windows.Forms.Label gynLbl;
        private System.Windows.Forms.Label iMLbl;
        private System.Windows.Forms.Label onkLbl;
        private System.Windows.Forms.Label OrthLbl;
        private System.Windows.Forms.Label pädLbl;
        private System.Windows.Forms.ProgressBar gynProgBar;
        private System.Windows.Forms.ProgressBar iMProgBar;
        private System.Windows.Forms.ProgressBar onkProgBar;
        private System.Windows.Forms.ProgressBar orthProgBar;
        private System.Windows.Forms.ProgressBar paedProgBar;
        private System.Windows.Forms.Label bettbelegLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameClmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vonClmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nachClmn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelGyn;
        private System.Windows.Forms.Label labelIm;
        private System.Windows.Forms.Label labelOnk;
        private System.Windows.Forms.Label labelOrth;
        private System.Windows.Forms.Label labelPaed;
        private System.Windows.Forms.Label labelIts;
        private System.Windows.Forms.Label labelGes;
    }
}