using System.Windows.Forms;

namespace FirstUserControlUsage
{
    partial class CardControl
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
            this.Kategorija = new System.Windows.Forms.TextBox();
            this.Naziv = new System.Windows.Forms.TextBox();
            this.Cijena = new System.Windows.Forms.TextBox();
            this.Kolicina = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Kategorija
            // 
            this.Kategorija.BackColor = System.Drawing.SystemColors.Control;
            this.Kategorija.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Kategorija.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Kategorija.Enabled = false;
            this.Kategorija.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Kategorija.Location = new System.Drawing.Point(47, 36);
            this.Kategorija.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.Kategorija.Multiline = true;
            this.Kategorija.Name = "Kategorija";
            this.Kategorija.ReadOnly = true;
            this.Kategorija.Size = new System.Drawing.Size(200, 16);
            this.Kategorija.TabIndex = 0;
            // 
            // Naziv
            // 
            this.Naziv.BackColor = System.Drawing.SystemColors.Control;
            this.Naziv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Naziv.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Naziv.Enabled = false;
            this.Naziv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Naziv.Location = new System.Drawing.Point(47, 8);
            this.Naziv.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.Naziv.Multiline = true;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Size = new System.Drawing.Size(200, 20);
            this.Naziv.TabIndex = 1;
            this.Naziv.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // Cijena
            // 
            this.Cijena.BackColor = System.Drawing.SystemColors.Control;
            this.Cijena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Cijena.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Cijena.Enabled = false;
            this.Cijena.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Cijena.Location = new System.Drawing.Point(47, 64);
            this.Cijena.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.Cijena.Multiline = true;
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            this.Cijena.Size = new System.Drawing.Size(200, 20);
            this.Cijena.TabIndex = 3;
            // 
            // Kolicina
            // 
            this.Kolicina.BackColor = System.Drawing.SystemColors.Control;
            this.Kolicina.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Kolicina.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Kolicina.Enabled = false;
            this.Kolicina.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Kolicina.Location = new System.Drawing.Point(47, 92);
            this.Kolicina.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.Kolicina.Multiline = true;
            this.Kolicina.Name = "Kolicina";
            this.Kolicina.ReadOnly = true;
            this.Kolicina.Size = new System.Drawing.Size(200, 20);
            this.Kolicina.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(47, 112);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 160);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // CardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Naziv);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Kolicina);
            this.Controls.Add(this.Cijena);
            this.Controls.Add(this.Kategorija);
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.Name = "CardControl";
            this.Size = new System.Drawing.Size(300, 309);
            this.Load += new System.EventHandler(this.CardControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Kategorija;
        private System.Windows.Forms.TextBox Naziv;
        private TextBox Cijena;
        private TextBox Kolicina;
        private PictureBox pictureBox1;
    }
}
