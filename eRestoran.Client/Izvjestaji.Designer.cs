namespace eRestoran.Client
{
    partial class Izvjestaji
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Izvjestaji));
            this.button1 = new System.Windows.Forms.Button();
            this.sviizvjestajiBtn = new System.Windows.Forms.Button();
            this.zaradaTextLabel = new System.Windows.Forms.Label();
            this.dnZarada = new System.Windows.Forms.Label();
            this.Zaradebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.button1.ForeColor = System.Drawing.Color.DimGray;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(319, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 153);
            this.button1.TabIndex = 10;
            this.button1.Text = "PREGLED RAČUNA PO DATUMU";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sviizvjestajiBtn
            // 
            this.sviizvjestajiBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sviizvjestajiBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sviizvjestajiBtn.FlatAppearance.BorderSize = 0;
            this.sviizvjestajiBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.sviizvjestajiBtn.ForeColor = System.Drawing.Color.DimGray;
            this.sviizvjestajiBtn.Image = ((System.Drawing.Image)(resources.GetObject("sviizvjestajiBtn.Image")));
            this.sviizvjestajiBtn.Location = new System.Drawing.Point(106, 147);
            this.sviizvjestajiBtn.Name = "sviizvjestajiBtn";
            this.sviizvjestajiBtn.Size = new System.Drawing.Size(157, 153);
            this.sviizvjestajiBtn.TabIndex = 9;
            this.sviizvjestajiBtn.Text = "SVI IZVJEŠTAJI";
            this.sviizvjestajiBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sviizvjestajiBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.sviizvjestajiBtn.UseVisualStyleBackColor = false;
            this.sviizvjestajiBtn.Click += new System.EventHandler(this.sviizvjestajiBtn_Click);
            // 
            // zaradaTextLabel
            // 
            this.zaradaTextLabel.AutoSize = true;
            this.zaradaTextLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zaradaTextLabel.Location = new System.Drawing.Point(238, 30);
            this.zaradaTextLabel.Name = "zaradaTextLabel";
            this.zaradaTextLabel.Size = new System.Drawing.Size(277, 29);
            this.zaradaTextLabel.TabIndex = 19;
            this.zaradaTextLabel.Text = "Današnja zarada iznosi";
            // 
            // dnZarada
            // 
            this.dnZarada.AutoSize = true;
            this.dnZarada.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dnZarada.Location = new System.Drawing.Point(347, 79);
            this.dnZarada.Name = "dnZarada";
            this.dnZarada.Size = new System.Drawing.Size(71, 29);
            this.dnZarada.TabIndex = 20;
            this.dnZarada.Text = "0 KM";
            // 
            // Zaradebutton
            // 
            this.Zaradebutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Zaradebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Zaradebutton.FlatAppearance.BorderSize = 0;
            this.Zaradebutton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.Zaradebutton.ForeColor = System.Drawing.Color.DimGray;
            this.Zaradebutton.Image = ((System.Drawing.Image)(resources.GetObject("Zaradebutton.Image")));
            this.Zaradebutton.Location = new System.Drawing.Point(517, 147);
            this.Zaradebutton.Name = "Zaradebutton";
            this.Zaradebutton.Size = new System.Drawing.Size(157, 153);
            this.Zaradebutton.TabIndex = 21;
            this.Zaradebutton.Text = "PREGLED DNEVNIH ZARADA PO DATUMU";
            this.Zaradebutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Zaradebutton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Zaradebutton.UseVisualStyleBackColor = false;
            this.Zaradebutton.Click += new System.EventHandler(this.Zaradebutton_Click);
            // 
            // Izvjestaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Zaradebutton);
            this.Controls.Add(this.dnZarada);
            this.Controls.Add(this.zaradaTextLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sviizvjestajiBtn);
            this.Name = "Izvjestaji";
            this.Size = new System.Drawing.Size(794, 447);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button sviizvjestajiBtn;
        private System.Windows.Forms.Label zaradaTextLabel;
        private System.Windows.Forms.Label dnZarada;
        private System.Windows.Forms.Button Zaradebutton;
    }
}
