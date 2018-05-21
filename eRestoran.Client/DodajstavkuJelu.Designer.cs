namespace eRestoran.Client
{
    partial class DodajstavkuJelu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProizvodJelo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KolicinaJelotextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ProizvodJelo
            // 
            this.ProizvodJelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProizvodJelo.FormattingEnabled = true;
            this.ProizvodJelo.Location = new System.Drawing.Point(149, -1);
            this.ProizvodJelo.Name = "ProizvodJelo";
            this.ProizvodJelo.Size = new System.Drawing.Size(198, 21);
            this.ProizvodJelo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proizvod";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Količina";
            // 
            // KolicinaJelotextBox
            // 
            this.KolicinaJelotextBox.Location = new System.Drawing.Point(151, 38);
            this.KolicinaJelotextBox.Name = "KolicinaJelotextBox";
            this.KolicinaJelotextBox.Size = new System.Drawing.Size(196, 20);
            this.KolicinaJelotextBox.TabIndex = 3;
            // 
            // DodajstavkuJelu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.KolicinaJelotextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProizvodJelo);
            this.Name = "DodajstavkuJelu";
            this.Size = new System.Drawing.Size(355, 69);
            this.Load += new System.EventHandler(this.DodajstavkuJelu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProizvodJelo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KolicinaJelotextBox;
    }
}
