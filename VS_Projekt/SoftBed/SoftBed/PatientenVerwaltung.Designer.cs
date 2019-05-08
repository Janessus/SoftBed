namespace SoftBed
{
    partial class PatientenVerwaltung
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
            this.nameLbl = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.vornameTxt = new System.Windows.Forms.TextBox();
            this.vornameLbl = new System.Windows.Forms.Label();
            this.gebDatLbl = new System.Windows.Forms.Label();
            this.geschlLbl = new System.Windows.Forms.Label();
            this.wRadBtn = new System.Windows.Forms.RadioButton();
            this.mRadBtn = new System.Windows.Forms.RadioButton();
            this.versNrAufnTxt = new System.Windows.Forms.TextBox();
            this.versNrAufnLbl = new System.Windows.Forms.Label();
            this.abteilungLbl = new System.Windows.Forms.Label();
            this.abteilungDropDown = new System.Windows.Forms.ComboBox();
            this.sucheBtn = new System.Windows.Forms.Button();
            this.patAufnLbl = new System.Windows.Forms.Label();
            this.zurueckBtn = new System.Windows.Forms.Button();
            this.meldungLbl = new System.Windows.Forms.Label();
            this.editMeldungLdl = new System.Windows.Forms.Label();
            this.patSucheLbl = new System.Windows.Forms.Label();
            this.versNrSucheTxt = new System.Windows.Forms.TextBox();
            this.versNrSucheLbl = new System.Windows.Forms.Label();
            this.patAnzDGV = new System.Windows.Forms.DataGridView();
            this.versichtertenNrClmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameClmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bettNrClmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entlassenBtn = new System.Windows.Forms.Button();
            this.zimmerSuchenBtn = new System.Windows.Forms.Button();
            this.dTPGebDat = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.patAnzDGV)).BeginInit();
            this.SuspendLayout();
            // 
<<<<<<< Updated upstream
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(98, 168);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(51, 20);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Name";
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(156, 168);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(282, 26);
            this.nameTxt.TabIndex = 7;
            // 
            // vornameTxt
            // 
            this.vornameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vornameTxt.Location = new System.Drawing.Point(156, 202);
            this.vornameTxt.Name = "vornameTxt";
            this.vornameTxt.Size = new System.Drawing.Size(282, 26);
            this.vornameTxt.TabIndex = 9;
            // 
            // vornameLbl
            // 
            this.vornameLbl.AutoSize = true;
            this.vornameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vornameLbl.Location = new System.Drawing.Point(77, 202);
            this.vornameLbl.Name = "vornameLbl";
            this.vornameLbl.Size = new System.Drawing.Size(74, 20);
            this.vornameLbl.TabIndex = 8;
            this.vornameLbl.Text = "Vorname";
            // 
            // gebDatLbl
            // 
            this.gebDatLbl.AutoSize = true;
            this.gebDatLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gebDatLbl.Location = new System.Drawing.Point(41, 238);
            this.gebDatLbl.Name = "gebDatLbl";
            this.gebDatLbl.Size = new System.Drawing.Size(112, 20);
            this.gebDatLbl.TabIndex = 10;
            this.gebDatLbl.Text = "Geburtsdatum";
            // 
            // geschlLbl
            // 
            this.geschlLbl.AutoSize = true;
            this.geschlLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geschlLbl.Location = new System.Drawing.Point(60, 273);
            this.geschlLbl.Name = "geschlLbl";
            this.geschlLbl.Size = new System.Drawing.Size(90, 20);
            this.geschlLbl.TabIndex = 12;
            this.geschlLbl.Text = "Geschlecht";
            // 
            // wRadBtn
            // 
            this.wRadBtn.AutoSize = true;
            this.wRadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wRadBtn.Location = new System.Drawing.Point(156, 275);
            this.wRadBtn.Name = "wRadBtn";
            this.wRadBtn.Size = new System.Drawing.Size(82, 24);
            this.wRadBtn.TabIndex = 13;
            this.wRadBtn.TabStop = true;
            this.wRadBtn.Text = "weiblich";
            this.wRadBtn.UseVisualStyleBackColor = true;
            // 
            // mRadBtn
            // 
            this.mRadBtn.AutoSize = true;
            this.mRadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mRadBtn.Location = new System.Drawing.Point(251, 275);
            this.mRadBtn.Name = "mRadBtn";
            this.mRadBtn.Size = new System.Drawing.Size(90, 24);
            this.mRadBtn.TabIndex = 14;
            this.mRadBtn.TabStop = true;
            this.mRadBtn.Text = "männlich";
            this.mRadBtn.UseVisualStyleBackColor = true;
            // 
            // versNrAufnTxt
            // 
            this.versNrAufnTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versNrAufnTxt.Location = new System.Drawing.Point(156, 308);
            this.versNrAufnTxt.Name = "versNrAufnTxt";
            this.versNrAufnTxt.Size = new System.Drawing.Size(282, 26);
            this.versNrAufnTxt.TabIndex = 16;
            // 
            // versNrAufnLbl
            // 
            this.versNrAufnLbl.AutoSize = true;
            this.versNrAufnLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versNrAufnLbl.Location = new System.Drawing.Point(32, 308);
            this.versNrAufnLbl.Name = "versNrAufnLbl";
            this.versNrAufnLbl.Size = new System.Drawing.Size(117, 20);
            this.versNrAufnLbl.TabIndex = 15;
            this.versNrAufnLbl.Text = "Versichertennr.";
            // 
            // abteilungLbl
            // 
            this.abteilungLbl.AutoSize = true;
            this.abteilungLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abteilungLbl.Location = new System.Drawing.Point(77, 344);
            this.abteilungLbl.Name = "abteilungLbl";
            this.abteilungLbl.Size = new System.Drawing.Size(76, 20);
            this.abteilungLbl.TabIndex = 17;
            this.abteilungLbl.Text = "Abteilung";
            // 
            // abteilungDropDown
            // 
            this.abteilungDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abteilungDropDown.FormattingEnabled = true;
            this.abteilungDropDown.Items.AddRange(new object[] {
=======
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 22);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(137, 136);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(169, 22);
            this.textBox2.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Vorname";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(137, 164);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(169, 22);
            this.textBox3.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Geburtsdatum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Geschlecht";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(137, 193);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 21);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "weiblich";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(221, 193);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 21);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "männlich";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(137, 220);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(169, 22);
            this.textBox4.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Versichertennr.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Abteilung";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.comboBox1.Items.AddRange(new object[] {
>>>>>>> Stashed changes
            "Gynäkologie",
            "innere Medizin",
            "Onkologie",
            "Orthopädie",
            "Pädiatrie",
            "Intensivstation"});
            this.abteilungDropDown.Location = new System.Drawing.Point(156, 344);
            this.abteilungDropDown.Name = "abteilungDropDown";
            this.abteilungDropDown.Size = new System.Drawing.Size(190, 45);
            this.abteilungDropDown.TabIndex = 18;
            this.abteilungDropDown.TabStop = false;
            // 
            // sucheBtn
            // 
            this.sucheBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucheBtn.Location = new System.Drawing.Point(954, 167);
            this.sucheBtn.Name = "sucheBtn";
            this.sucheBtn.Size = new System.Drawing.Size(196, 29);
            this.sucheBtn.TabIndex = 20;
            this.sucheBtn.Text = "Patient suchen";
            this.sucheBtn.UseVisualStyleBackColor = true;
            this.sucheBtn.Click += new System.EventHandler(this.sucheBtn_Click);
            // 
            // patAufnLbl
            // 
            this.patAufnLbl.AutoSize = true;
            this.patAufnLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patAufnLbl.Location = new System.Drawing.Point(32, 118);
            this.patAufnLbl.Name = "patAufnLbl";
            this.patAufnLbl.Size = new System.Drawing.Size(311, 37);
            this.patAufnLbl.TabIndex = 21;
            this.patAufnLbl.Text = "Patientenaufnahme";
            // 
            // zurueckBtn
            // 
            this.zurueckBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zurueckBtn.Location = new System.Drawing.Point(14, 15);
            this.zurueckBtn.Name = "zurueckBtn";
            this.zurueckBtn.Size = new System.Drawing.Size(84, 29);
            this.zurueckBtn.TabIndex = 22;
            this.zurueckBtn.Text = "< Zurück";
            this.zurueckBtn.UseVisualStyleBackColor = true;
            this.zurueckBtn.Click += new System.EventHandler(this.zurueckBtn_Click);
            // 
            // meldungLbl
            // 
            this.meldungLbl.AutoSize = true;
            this.meldungLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meldungLbl.Location = new System.Drawing.Point(32, 497);
            this.meldungLbl.Name = "meldungLbl";
            this.meldungLbl.Size = new System.Drawing.Size(146, 37);
            this.meldungLbl.TabIndex = 23;
            this.meldungLbl.Text = "Meldung";
            // 
            // editMeldungLdl
            // 
            this.editMeldungLdl.AutoSize = true;
            this.editMeldungLdl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editMeldungLdl.Location = new System.Drawing.Point(32, 537);
            this.editMeldungLdl.Name = "editMeldungLdl";
            this.editMeldungLdl.Size = new System.Drawing.Size(0, 37);
            this.editMeldungLdl.TabIndex = 24;
            // 
            // patSucheLbl
            // 
            this.patSucheLbl.AutoSize = true;
            this.patSucheLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patSucheLbl.Location = new System.Drawing.Point(564, 127);
            this.patSucheLbl.Name = "patSucheLbl";
            this.patSucheLbl.Size = new System.Drawing.Size(250, 37);
            this.patSucheLbl.TabIndex = 25;
            this.patSucheLbl.Text = "Patientensuche";
            // 
            // versNrSucheTxt
            // 
            this.versNrSucheTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versNrSucheTxt.Location = new System.Drawing.Point(688, 168);
            this.versNrSucheTxt.Name = "versNrSucheTxt";
            this.versNrSucheTxt.Size = new System.Drawing.Size(238, 44);
            this.versNrSucheTxt.TabIndex = 27;
            // 
            // versNrSucheLbl
            // 
            this.versNrSucheLbl.AutoSize = true;
            this.versNrSucheLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versNrSucheLbl.Location = new System.Drawing.Point(564, 168);
            this.versNrSucheLbl.Name = "versNrSucheLbl";
            this.versNrSucheLbl.Size = new System.Drawing.Size(234, 37);
            this.versNrSucheLbl.TabIndex = 26;
            this.versNrSucheLbl.Text = "Versichertennr.";
            // 
            // patAnzDGV
            // 
            this.patAnzDGV.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.patAnzDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patAnzDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.versichtertenNrClmn,
            this.nameColmn,
            this.firstNameClmn,
            this.bettNrClmn});
            this.patAnzDGV.Enabled = false;
            this.patAnzDGV.Location = new System.Drawing.Point(568, 273);
            this.patAnzDGV.Name = "patAnzDGV";
            this.patAnzDGV.RowHeadersVisible = false;
            this.patAnzDGV.Size = new System.Drawing.Size(582, 52);
            this.patAnzDGV.TabIndex = 28;
            // 
            // versichtertenNrClmn
            // 
            this.versichtertenNrClmn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.versichtertenNrClmn.HeaderText = "Versichertennr.";
            this.versichtertenNrClmn.Name = "versichtertenNrClmn";
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
            // bettNrClmn
            // 
            this.bettNrClmn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bettNrClmn.HeaderText = "Bettnr.";
            this.bettNrClmn.Name = "bettNrClmn";
            // 
            // entlassenBtn
            // 
            this.entlassenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entlassenBtn.Location = new System.Drawing.Point(788, 339);
            this.entlassenBtn.Name = "entlassenBtn";
            this.entlassenBtn.Size = new System.Drawing.Size(141, 29);
            this.entlassenBtn.TabIndex = 29;
            this.entlassenBtn.Text = "Patient entlassen";
            this.entlassenBtn.UseVisualStyleBackColor = true;
            this.entlassenBtn.Click += new System.EventHandler(this.entlassenBtn_Click);
            // 
            // zimmerSuchenBtn
            // 
            this.zimmerSuchenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zimmerSuchenBtn.Location = new System.Drawing.Point(156, 397);
            this.zimmerSuchenBtn.Name = "zimmerSuchenBtn";
            this.zimmerSuchenBtn.Size = new System.Drawing.Size(282, 29);
            this.zimmerSuchenBtn.TabIndex = 31;
            this.zimmerSuchenBtn.Text = "Zimmer suchen";
            this.zimmerSuchenBtn.UseVisualStyleBackColor = true;
            this.zimmerSuchenBtn.Click += new System.EventHandler(this.zimmerSuchenBtn_Click);
            // 
            // dTPGebDat
            // 
            this.dTPGebDat.Location = new System.Drawing.Point(156, 238);
            this.dTPGebDat.Name = "dTPGebDat";
            this.dTPGebDat.Size = new System.Drawing.Size(282, 26);
            this.dTPGebDat.TabIndex = 32;
            // 
            // PatientenVerwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< Updated upstream
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1162, 645);
            this.Controls.Add(this.dTPGebDat);
            this.Controls.Add(this.zimmerSuchenBtn);
            this.Controls.Add(this.entlassenBtn);
            this.Controls.Add(this.patAnzDGV);
            this.Controls.Add(this.versNrSucheTxt);
            this.Controls.Add(this.versNrSucheLbl);
            this.Controls.Add(this.patSucheLbl);
            this.Controls.Add(this.editMeldungLdl);
            this.Controls.Add(this.meldungLbl);
            this.Controls.Add(this.zurueckBtn);
            this.Controls.Add(this.patAufnLbl);
            this.Controls.Add(this.sucheBtn);
            this.Controls.Add(this.abteilungDropDown);
            this.Controls.Add(this.abteilungLbl);
            this.Controls.Add(this.versNrAufnTxt);
            this.Controls.Add(this.versNrAufnLbl);
            this.Controls.Add(this.mRadBtn);
            this.Controls.Add(this.wRadBtn);
            this.Controls.Add(this.geschlLbl);
            this.Controls.Add(this.gebDatLbl);
            this.Controls.Add(this.vornameTxt);
            this.Controls.Add(this.vornameLbl);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.nameLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
=======
            this.ClientSize = new System.Drawing.Size(1160, 637);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
>>>>>>> Stashed changes
            this.Name = "PatientenVerwaltung";
            this.Text = "PatientenVerwaltung";
            ((System.ComponentModel.ISupportInitialize)(this.patAnzDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.TextBox vornameTxt;
        private System.Windows.Forms.Label vornameLbl;
        private System.Windows.Forms.Label gebDatLbl;
        private System.Windows.Forms.Label geschlLbl;
        private System.Windows.Forms.RadioButton wRadBtn;
        private System.Windows.Forms.RadioButton mRadBtn;
        private System.Windows.Forms.TextBox versNrAufnTxt;
        private System.Windows.Forms.Label versNrAufnLbl;
        private System.Windows.Forms.Label abteilungLbl;
        private System.Windows.Forms.ComboBox abteilungDropDown;
        private System.Windows.Forms.Button sucheBtn;
        private System.Windows.Forms.Label patAufnLbl;
        private System.Windows.Forms.Button zurueckBtn;
        private System.Windows.Forms.Label meldungLbl;
        private System.Windows.Forms.Label editMeldungLdl;
        private System.Windows.Forms.Label patSucheLbl;
        private System.Windows.Forms.TextBox versNrSucheTxt;
        private System.Windows.Forms.Label versNrSucheLbl;
        private System.Windows.Forms.DataGridView patAnzDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn versichtertenNrClmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameClmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bettNrClmn;
        private System.Windows.Forms.Button entlassenBtn;
        private System.Windows.Forms.Button zimmerSuchenBtn;
        private System.Windows.Forms.DateTimePicker dTPGebDat;
    }
}