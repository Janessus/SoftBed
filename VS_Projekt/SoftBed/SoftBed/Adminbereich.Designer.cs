namespace SoftBed
{
    partial class Adminbereich
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
            this.zurueckBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zurueckBtn
            // 
            this.zurueckBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zurueckBtn.Location = new System.Drawing.Point(12, 12);
            this.zurueckBtn.Name = "zurueckBtn";
            this.zurueckBtn.Size = new System.Drawing.Size(84, 29);
            this.zurueckBtn.TabIndex = 23;
            this.zurueckBtn.Text = "< Zurück";
            this.zurueckBtn.UseVisualStyleBackColor = true;
            this.zurueckBtn.Click += new System.EventHandler(this.zurueckBtn_Click);
            // 
            // Adminbereich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.zurueckBtn);
            this.Name = "Adminbereich";
            this.Text = "Adminbereich";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button zurueckBtn;
    }
}