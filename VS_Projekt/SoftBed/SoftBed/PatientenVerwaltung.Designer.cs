﻿namespace SoftBed
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
            this.gebDatTxt = new System.Windows.Forms.TextBox();
            this.gebDatLbl = new System.Windows.Forms.Label();
            this.geschlLbl = new System.Windows.Forms.Label();
            this.wRadBtn = new System.Windows.Forms.RadioButton();
            this.mRadBtn = new System.Windows.Forms.RadioButton();
            this.versNrAufnTxt = new System.Windows.Forms.TextBox();
            this.versNrAufnLbl = new System.Windows.Forms.Label();
            this.abteilungLbl = new System.Windows.Forms.Label();
            this.abteilungDropDown = new System.Windows.Forms.ComboBox();
            this.aufnahmeBtn = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.patAnzDGV)).BeginInit();
            this.SuspendLayout();
            // 
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
            this.nameTxt.Size = new System.Drawing.Size(190, 26);
            this.nameTxt.TabIndex = 7;
            // 
            // vornameTxt
            // 
            this.vornameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vornameTxt.Location = new System.Drawing.Point(156, 202);
            this.vornameTxt.Name = "vornameTxt";
            this.vornameTxt.Size = new System.Drawing.Size(190, 26);
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
            // gebDatTxt
            // 
            this.gebDatTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gebDatTxt.Location = new System.Drawing.Point(156, 238);
            this.gebDatTxt.Name = "gebDatTxt";
            this.gebDatTxt.Size = new System.Drawing.Size(190, 26);
            this.gebDatTxt.TabIndex = 11;
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
            this.versNrAufnTxt.Size = new System.Drawing.Size(190, 26);
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
            "Gynäkologie",
            "innere Medizin",
            "Onkologie",
            "Orthopädie",
            "Pädiatrie",
            "Intensivstation"});
            this.abteilungDropDown.Location = new System.Drawing.Point(156, 344);
            this.abteilungDropDown.Name = "abteilungDropDown";
            this.abteilungDropDown.Size = new System.Drawing.Size(190, 28);
            this.abteilungDropDown.TabIndex = 18;
            this.abteilungDropDown.TabStop = false;
            // 
            // aufnahmeBtn
            // 
            this.aufnahmeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aufnahmeBtn.Location = new System.Drawing.Point(156, 396);
            this.aufnahmeBtn.Name = "aufnahmeBtn";
            this.aufnahmeBtn.Size = new System.Drawing.Size(190, 29);
            this.aufnahmeBtn.TabIndex = 19;
            this.aufnahmeBtn.Text = "Patient aufnehmen";
            this.aufnahmeBtn.UseVisualStyleBackColor = true;
            this.aufnahmeBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // sucheBtn
            // 
            this.sucheBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucheBtn.Location = new System.Drawing.Point(954, 167);
            this.sucheBtn.Name = "sucheBtn";
            this.sucheBtn.Size = new System.Drawing.Size(196, 29);
            this.sucheBtn.TabIndex = 20;
            this.sucheBtn.Text = "Patient Suchen";
            this.sucheBtn.UseVisualStyleBackColor = true;
            this.sucheBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // patAufnLbl
            // 
            this.patAufnLbl.AutoSize = true;
            this.patAufnLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patAufnLbl.Location = new System.Drawing.Point(32, 118);
            this.patAufnLbl.Name = "patAufnLbl";
            this.patAufnLbl.Size = new System.Drawing.Size(166, 20);
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
            this.zurueckBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // meldungLbl
            // 
            this.meldungLbl.AutoSize = true;
            this.meldungLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meldungLbl.Location = new System.Drawing.Point(32, 497);
            this.meldungLbl.Name = "meldungLbl";
            this.meldungLbl.Size = new System.Drawing.Size(77, 20);
            this.meldungLbl.TabIndex = 23;
            this.meldungLbl.Text = "Meldung";
            // 
            // editMeldungLdl
            // 
            this.editMeldungLdl.AutoSize = true;
            this.editMeldungLdl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editMeldungLdl.Location = new System.Drawing.Point(32, 552);
            this.editMeldungLdl.Name = "editMeldungLdl";
            this.editMeldungLdl.Size = new System.Drawing.Size(190, 20);
            this.editMeldungLdl.TabIndex = 24;
            this.editMeldungLdl.Text = "hier kommt eine Meldung!";
            // 
            // patSucheLbl
            // 
            this.patSucheLbl.AutoSize = true;
            this.patSucheLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patSucheLbl.Location = new System.Drawing.Point(564, 127);
            this.patSucheLbl.Name = "patSucheLbl";
            this.patSucheLbl.Size = new System.Drawing.Size(134, 20);
            this.patSucheLbl.TabIndex = 25;
            this.patSucheLbl.Text = "Patientensuche";
            // 
            // versNrSucheTxt
            // 
            this.versNrSucheTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versNrSucheTxt.Location = new System.Drawing.Point(688, 168);
            this.versNrSucheTxt.Name = "versNrSucheTxt";
            this.versNrSucheTxt.Size = new System.Drawing.Size(238, 26);
            this.versNrSucheTxt.TabIndex = 27;
            // 
            // versNrSucheLbl
            // 
            this.versNrSucheLbl.AutoSize = true;
            this.versNrSucheLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versNrSucheLbl.Location = new System.Drawing.Point(564, 168);
            this.versNrSucheLbl.Name = "versNrSucheLbl";
            this.versNrSucheLbl.Size = new System.Drawing.Size(117, 20);
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
            this.patAnzDGV.Location = new System.Drawing.Point(568, 238);
            this.patAnzDGV.Name = "patAnzDGV";
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
            // PatientenVerwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1162, 645);
            this.Controls.Add(this.patAnzDGV);
            this.Controls.Add(this.versNrSucheTxt);
            this.Controls.Add(this.versNrSucheLbl);
            this.Controls.Add(this.patSucheLbl);
            this.Controls.Add(this.editMeldungLdl);
            this.Controls.Add(this.meldungLbl);
            this.Controls.Add(this.zurueckBtn);
            this.Controls.Add(this.patAufnLbl);
            this.Controls.Add(this.sucheBtn);
            this.Controls.Add(this.aufnahmeBtn);
            this.Controls.Add(this.abteilungDropDown);
            this.Controls.Add(this.abteilungLbl);
            this.Controls.Add(this.versNrAufnTxt);
            this.Controls.Add(this.versNrAufnLbl);
            this.Controls.Add(this.mRadBtn);
            this.Controls.Add(this.wRadBtn);
            this.Controls.Add(this.geschlLbl);
            this.Controls.Add(this.gebDatTxt);
            this.Controls.Add(this.gebDatLbl);
            this.Controls.Add(this.vornameTxt);
            this.Controls.Add(this.vornameLbl);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.nameLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.TextBox gebDatTxt;
        private System.Windows.Forms.Label gebDatLbl;
        private System.Windows.Forms.Label geschlLbl;
        private System.Windows.Forms.RadioButton wRadBtn;
        private System.Windows.Forms.RadioButton mRadBtn;
        private System.Windows.Forms.TextBox versNrAufnTxt;
        private System.Windows.Forms.Label versNrAufnLbl;
        private System.Windows.Forms.Label abteilungLbl;
        private System.Windows.Forms.ComboBox abteilungDropDown;
        private System.Windows.Forms.Button aufnahmeBtn;
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
    }
}