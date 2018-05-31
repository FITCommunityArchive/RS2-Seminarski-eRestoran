namespace eRestoran.Client
{
    partial class RezervacijaStola
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RezervacijaStola));
            this.datumRezervacije = new System.Windows.Forms.DateTimePicker();
            this.ctrlStolovi = new eRestoran.Client.Stolovi();
            this.SuspendLayout();
            // 
            // datumRezervacije
            // 
            this.datumRezervacije.Location = new System.Drawing.Point(526, 14);
            this.datumRezervacije.MinDate = new System.DateTime(2018, 5, 30, 21, 28, 12, 884);
            this.datumRezervacije.Name = "datumRezervacije";
            this.datumRezervacije.Size = new System.Drawing.Size(200, 20);
            this.datumRezervacije.TabIndex = 0;
            this.datumRezervacije.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datumRezervacije.CustomFormat = "dd/MM/yyyy hh:mm";
            this.datumRezervacije.ValueChanged += new System.EventHandler(this.datumRezervacije_ValueChanged);
            // 
            // ctrlStolovi
            // 
            this.ctrlStolovi.BackColor = System.Drawing.Color.Transparent;
            this.ctrlStolovi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctrlStolovi.BackgroundImage")));
            this.ctrlStolovi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctrlStolovi.DatumRezervacije = new System.DateTime(((long)(0)));
            this.ctrlStolovi.Location = new System.Drawing.Point(0, 40);
            this.ctrlStolovi.Name = "ctrlStolovi";
            this.ctrlStolovi.Size = new System.Drawing.Size(758, 479);
            this.ctrlStolovi.TabIndex = 1;
            // 
            // RezervacijaStola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlStolovi);
            this.Controls.Add(this.datumRezervacije);
            this.Name = "RezervacijaStola";
            this.Size = new System.Drawing.Size(758, 519);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datumRezervacije;
        private Stolovi ctrlStolovi;
    }
}
