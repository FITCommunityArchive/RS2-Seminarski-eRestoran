namespace eRestoran.Client
{
    partial class SlikaKontrola
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
            this.dodajSlikubutton = new System.Windows.Forms.Button();
            this.ProizvodpictureBox = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ProizvodpictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dodajSlikubutton
            // 
            this.dodajSlikubutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.dodajSlikubutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.dodajSlikubutton.ForeColor = System.Drawing.Color.White;
            this.dodajSlikubutton.Location = new System.Drawing.Point(39, 178);
            this.dodajSlikubutton.Margin = new System.Windows.Forms.Padding(4);
            this.dodajSlikubutton.Name = "dodajSlikubutton";
            this.dodajSlikubutton.Size = new System.Drawing.Size(99, 32);
            this.dodajSlikubutton.TabIndex = 28;
            this.dodajSlikubutton.Text = "Učitaj sliku";
            this.dodajSlikubutton.UseVisualStyleBackColor = false;
            this.dodajSlikubutton.Click += new System.EventHandler(this.dodajSlikubutton_Click);
            // 
            // ProizvodpictureBox
            // 
            this.ProizvodpictureBox.Location = new System.Drawing.Point(0, 35);
            this.ProizvodpictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.ProizvodpictureBox.Name = "ProizvodpictureBox";
            this.ProizvodpictureBox.Size = new System.Drawing.Size(188, 135);
            this.ProizvodpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProizvodpictureBox.TabIndex = 27;
            this.ProizvodpictureBox.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(63, 12);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 19);
            this.label9.TabIndex = 26;
            this.label9.Text = "Slika";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SlikaKontrola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dodajSlikubutton);
            this.Controls.Add(this.ProizvodpictureBox);
            this.Controls.Add(this.label9);
            this.Name = "SlikaKontrola";
            this.Size = new System.Drawing.Size(190, 226);
            ((System.ComponentModel.ISupportInitialize)(this.ProizvodpictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dodajSlikubutton;
        private System.Windows.Forms.PictureBox ProizvodpictureBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
