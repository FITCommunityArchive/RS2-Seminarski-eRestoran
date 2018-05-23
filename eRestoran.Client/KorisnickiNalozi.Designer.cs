namespace eRestoran.Client
{
    partial class KorisnickiNalozi
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
            this.kNalozidataGridView = new System.Windows.Forms.DataGridView();
            this.kNalozilabel = new System.Windows.Forms.Label();
            this.Izbrisibutton = new System.Windows.Forms.Button();
            this.Uredibutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.kNalozidataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // kNalozidataGridView
            // 
            this.kNalozidataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kNalozidataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kNalozidataGridView.Location = new System.Drawing.Point(35, 97);
            this.kNalozidataGridView.Name = "kNalozidataGridView";
            this.kNalozidataGridView.Size = new System.Drawing.Size(539, 325);
            this.kNalozidataGridView.TabIndex = 0;
            // 
            // kNalozilabel
            // 
            this.kNalozilabel.AutoSize = true;
            this.kNalozilabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kNalozilabel.Location = new System.Drawing.Point(247, 31);
            this.kNalozilabel.Name = "kNalozilabel";
            this.kNalozilabel.Size = new System.Drawing.Size(164, 22);
            this.kNalozilabel.TabIndex = 1;
            this.kNalozilabel.Text = "Korisnički nalozi";
            // 
            // Izbrisibutton
            // 
            this.Izbrisibutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.Izbrisibutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Izbrisibutton.ForeColor = System.Drawing.Color.White;
            this.Izbrisibutton.Location = new System.Drawing.Point(605, 153);
            this.Izbrisibutton.Name = "Izbrisibutton";
            this.Izbrisibutton.Size = new System.Drawing.Size(72, 35);
            this.Izbrisibutton.TabIndex = 39;
            this.Izbrisibutton.Text = "Izbriši";
            this.Izbrisibutton.UseVisualStyleBackColor = false;
            this.Izbrisibutton.Click += new System.EventHandler(this.Izbrisibutton_Click);
            // 
            // Uredibutton
            // 
            this.Uredibutton.BackColor = System.Drawing.Color.Silver;
            this.Uredibutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Uredibutton.ForeColor = System.Drawing.Color.White;
            this.Uredibutton.Location = new System.Drawing.Point(605, 97);
            this.Uredibutton.Name = "Uredibutton";
            this.Uredibutton.Size = new System.Drawing.Size(72, 35);
            this.Uredibutton.TabIndex = 38;
            this.Uredibutton.Text = "Uredi";
            this.Uredibutton.UseVisualStyleBackColor = false;
            this.Uredibutton.Click += new System.EventHandler(this.Uredibutton_Click);
            // 
            // KorisnickiNalozi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Izbrisibutton);
            this.Controls.Add(this.Uredibutton);
            this.Controls.Add(this.kNalozilabel);
            this.Controls.Add(this.kNalozidataGridView);
            this.Name = "KorisnickiNalozi";
            this.Size = new System.Drawing.Size(706, 459);
            ((System.ComponentModel.ISupportInitialize)(this.kNalozidataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView kNalozidataGridView;
        private System.Windows.Forms.Label kNalozilabel;
        private System.Windows.Forms.Button Izbrisibutton;
        private System.Windows.Forms.Button Uredibutton;
    }
}
