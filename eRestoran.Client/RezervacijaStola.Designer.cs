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
            this.ctrlStolovi = new eRestoran.Client.Stolovi();
            this.SuspendLayout();
            // 
            // ctrlStolovi
            // 
            this.ctrlStolovi.BackColor = System.Drawing.Color.Transparent;
            this.ctrlStolovi.BackgroundImage = global::eRestoran.Client.Properties.Resources.stolovi;
            this.ctrlStolovi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctrlStolovi.Location = new System.Drawing.Point(0, 16);
            this.ctrlStolovi.Name = "ctrlStolovi";
            this.ctrlStolovi.Size = new System.Drawing.Size(758, 479);
            this.ctrlStolovi.TabIndex = 1;
            // 
            // RezervacijaStola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlStolovi);
            this.Name = "RezervacijaStola";
            this.Size = new System.Drawing.Size(758, 519);
            this.ResumeLayout(false);

        }

        #endregion
        private Stolovi ctrlStolovi;
    }
}
