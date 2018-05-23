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
            this.Naziv = new System.Windows.Forms.TextBox();
            this.Cijena = new System.Windows.Forms.TextBox();
            this.Kolicina = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Naziv
            // 
            this.Naziv.BackColor = System.Drawing.SystemColors.Control;
            this.Naziv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Naziv.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Naziv.Enabled = false;
            this.Naziv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Naziv.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Naziv.Location = new System.Drawing.Point(1, 2);
            this.Naziv.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.Naziv.Multiline = true;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Size = new System.Drawing.Size(179, 20);
            this.Naziv.TabIndex = 1;
            this.Naziv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cijena
            // 
            this.Cijena.BackColor = System.Drawing.SystemColors.Control;
            this.Cijena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Cijena.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Cijena.Enabled = false;
            this.Cijena.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Cijena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.Cijena.Location = new System.Drawing.Point(1, 22);
            this.Cijena.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.Cijena.Multiline = true;
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            this.Cijena.Size = new System.Drawing.Size(179, 20);
            this.Cijena.TabIndex = 3;
            this.Cijena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Kolicina
            // 
            this.Kolicina.BackColor = System.Drawing.SystemColors.Control;
            this.Kolicina.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Kolicina.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Kolicina.Enabled = false;
            this.Kolicina.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Kolicina.Location = new System.Drawing.Point(0, 42);
            this.Kolicina.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.Kolicina.Multiline = true;
            this.Kolicina.Name = "Kolicina";
            this.Kolicina.ReadOnly = true;
            this.Kolicina.Size = new System.Drawing.Size(179, 20);
            this.Kolicina.TabIndex = 4;
            this.Kolicina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 81);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(16, 231);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Uredi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.button2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(16, 277);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "Izbriši";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Naziv);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Kolicina);
            this.Controls.Add(this.Cijena);
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CardControl";
            this.Size = new System.Drawing.Size(180, 340);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Naziv;
        private TextBox Cijena;
        private TextBox Kolicina;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
    }
}
