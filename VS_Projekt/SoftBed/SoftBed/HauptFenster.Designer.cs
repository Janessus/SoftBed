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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.progressBar5 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gesKHProgBar
            // 
            this.gesKHProgBar.Enabled = false;
            this.gesKHProgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(209)))), ((int)(((byte)(79)))));
            this.gesKHProgBar.Location = new System.Drawing.Point(12, 606);
            this.gesKHProgBar.Name = "gesKHProgBar";
            this.gesKHProgBar.Size = new System.Drawing.Size(1138, 32);
            this.gesKHProgBar.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColmn,
            this.firstNameClmn,
            this.vonClmn,
            this.nachClmn});
            this.dataGridView1.Location = new System.Drawing.Point(707, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 401);
            this.dataGridView1.TabIndex = 1;
            // 
            // nameColmn
            // 
            this.nameColmn.HeaderText = "Nachname";
            this.nameColmn.Name = "nameColmn";
            // 
            // firstNameClmn
            // 
            this.firstNameClmn.HeaderText = "Vorname";
            this.firstNameClmn.Name = "firstNameClmn";
            // 
            // vonClmn
            // 
            this.vonClmn.HeaderText = "Von";
            this.vonClmn.Name = "vonClmn";
            // 
            // nachClmn
            // 
            this.nachClmn.HeaderText = "Nach";
            this.nachClmn.Name = "nachClmn";
            // 
            // progBarGesLbl
            // 
            this.progBarGesLbl.AutoSize = true;
            this.progBarGesLbl.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progBarGesLbl.Location = new System.Drawing.Point(15, 612);
            this.progBarGesLbl.Name = "progBarGesLbl";
            this.progBarGesLbl.Size = new System.Drawing.Size(207, 20);
            this.progBarGesLbl.TabIndex = 2;
            this.progBarGesLbl.Text = "Auslastung Betten Gesamt";
            // 
            // itsProgBar
            // 
            this.itsProgBar.Location = new System.Drawing.Point(12, 574);
            this.itsProgBar.Name = "itsProgBar";
            this.itsProgBar.Size = new System.Drawing.Size(374, 26);
            this.itsProgBar.TabIndex = 3;
            // 
            // auslastungITSLbl
            // 
            this.auslastungITSLbl.AutoSize = true;
            this.auslastungITSLbl.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auslastungITSLbl.Location = new System.Drawing.Point(15, 577);
            this.auslastungITSLbl.Name = "auslastungITSLbl";
            this.auslastungITSLbl.Size = new System.Drawing.Size(206, 20);
            this.auslastungITSLbl.TabIndex = 4;
            this.auslastungITSLbl.Text = "Auslastung Intensivstation";
            // 
            // patVerwBtn
            // 
            this.patVerwBtn.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.patVerwBtn.Location = new System.Drawing.Point(147, 36);
            this.patVerwBtn.Name = "patVerwBtn";
            this.patVerwBtn.Size = new System.Drawing.Size(263, 167);
            this.patVerwBtn.TabIndex = 5;
            this.patVerwBtn.Text = "Patientenverwaltung...";
            this.patVerwBtn.UseVisualStyleBackColor = true;
            this.patVerwBtn.Click += new System.EventHandler(this.patVerwBtn_Click);
            // 
            // abmeldenBtn
            // 
            this.abmeldenBtn.Location = new System.Drawing.Point(1014, 12);
            this.abmeldenBtn.Name = "abmeldenBtn";
            this.abmeldenBtn.Size = new System.Drawing.Size(136, 32);
            this.abmeldenBtn.TabIndex = 6;
            this.abmeldenBtn.Text = "Abmelden";
            this.abmeldenBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.abmeldenBtn.UseVisualStyleBackColor = true;
            this.abmeldenBtn.Click += new System.EventHandler(this.abmeldenBtn_Click);
            // 
            // verlAugefBtn
            // 
            this.verlAugefBtn.Location = new System.Drawing.Point(1014, 504);
            this.verlAugefBtn.Name = "verlAugefBtn";
            this.verlAugefBtn.Size = new System.Drawing.Size(136, 32);
            this.verlAugefBtn.TabIndex = 7;
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
            this.gynLbl.Location = new System.Drawing.Point(24, 303);
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
            this.iMLbl.Location = new System.Drawing.Point(10, 341);
            this.iMLbl.Name = "iMLbl";
            this.iMLbl.Size = new System.Drawing.Size(111, 20);
            this.iMLbl.TabIndex = 9;
            this.iMLbl.Text = "innere Medizin";
            // 
            // onkLbl
            // 
            this.onkLbl.AutoSize = true;
            this.onkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onkLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.onkLbl.Location = new System.Drawing.Point(41, 383);
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
            this.OrthLbl.Location = new System.Drawing.Point(33, 423);
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
            this.pädLbl.Location = new System.Drawing.Point(50, 464);
            this.pädLbl.Name = "pädLbl";
            this.pädLbl.Size = new System.Drawing.Size(71, 20);
            this.pädLbl.TabIndex = 12;
            this.pädLbl.Text = "Pädiatrie";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(147, 297);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(374, 26);
            this.progressBar1.TabIndex = 13;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(147, 335);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(374, 26);
            this.progressBar2.TabIndex = 14;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(147, 377);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(374, 26);
            this.progressBar3.TabIndex = 15;
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(147, 417);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(374, 26);
            this.progressBar4.TabIndex = 16;
            // 
            // progressBar5
            // 
            this.progressBar5.Location = new System.Drawing.Point(147, 458);
            this.progressBar5.Name = "progressBar5";
            this.progressBar5.Size = new System.Drawing.Size(374, 26);
            this.progressBar5.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(143, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Bettenbelegung";
            // 
            // HauptFenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 645);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar5);
            this.Controls.Add(this.progressBar4);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
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
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gesKHProgBar);
            this.Name = "HauptFenster";
            this.Text = "HauptFenster";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar gesKHProgBar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameClmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vonClmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nachClmn;
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.ProgressBar progressBar5;
        private System.Windows.Forms.Label label1;
    }
}