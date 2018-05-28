using System.Windows.Forms;

namespace FirstUserControlUsage
{
    partial class CartItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartItem));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDodajKolicinu = new System.Windows.Forms.Button();
            this.btnSmanjiKolicinu = new System.Windows.Forms.Button();
            this.lblKolicina = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.Label();
            this.txtCijena = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 60);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnDodajKolicinu
            // 
            this.btnDodajKolicinu.BackColor = System.Drawing.SystemColors.Control;
            this.btnDodajKolicinu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDodajKolicinu.BackgroundImage")));
            this.btnDodajKolicinu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDodajKolicinu.Location = new System.Drawing.Point(120, 200);
            this.btnDodajKolicinu.Name = "btnDodajKolicinu";
            this.btnDodajKolicinu.Size = new System.Drawing.Size(40, 40);
            this.btnDodajKolicinu.TabIndex = 8;
            this.btnDodajKolicinu.UseVisualStyleBackColor = false;
            this.btnDodajKolicinu.Click += new System.EventHandler(this.btnDodajKolicinu_Click);
            // 
            // btnSmanjiKolicinu
            // 
            this.btnSmanjiKolicinu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSmanjiKolicinu.BackgroundImage")));
            this.btnSmanjiKolicinu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSmanjiKolicinu.Location = new System.Drawing.Point(16, 200);
            this.btnSmanjiKolicinu.Name = "btnSmanjiKolicinu";
            this.btnSmanjiKolicinu.Size = new System.Drawing.Size(40, 40);
            this.btnSmanjiKolicinu.TabIndex = 9;
            this.btnSmanjiKolicinu.UseVisualStyleBackColor = true;
            this.btnSmanjiKolicinu.Click += new System.EventHandler(this.btnSmanjiKolicinu_Click);
            // 
            // lblKolicina
            // 
            this.lblKolicina.AutoSize = true;
            this.lblKolicina.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKolicina.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblKolicina.Location = new System.Drawing.Point(80, 208);
            this.lblKolicina.Name = "lblKolicina";
            this.lblKolicina.Size = new System.Drawing.Size(22, 25);
            this.lblKolicina.TabIndex = 10;
            this.lblKolicina.Text = "1";
           
            // 
            // txtNaziv
            // 
            this.txtNaziv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(67)))), ((int)(((byte)(69)))));
            this.txtNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtNaziv.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNaziv.Location = new System.Drawing.Point(0, 0);
            this.txtNaziv.MaximumSize = new System.Drawing.Size(180, 64);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(180, 56);
            this.txtNaziv.TabIndex = 11;
            this.txtNaziv.Text = "label1";
            this.txtNaziv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCijena
            // 
            this.txtCijena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtCijena.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCijena.Location = new System.Drawing.Point(0, 240);
            this.txtCijena.MaximumSize = new System.Drawing.Size(180, 64);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(180, 40);
            this.txtCijena.TabIndex = 12;
            this.txtCijena.Text = "label1";
            this.txtCijena.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // PonudaItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(67)))), ((int)(((byte)(69)))));
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.lblKolicina);
            this.Controls.Add(this.btnSmanjiKolicinu);
            this.Controls.Add(this.btnDodajKolicinu);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PonudaItem";
            this.Size = new System.Drawing.Size(181, 282);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox pictureBox1;
        private Button btnDodajKolicinu;
        private Button btnSmanjiKolicinu;
        private Label lblKolicina;
        private Label txtNaziv;
        private Label txtCijena;
    }
}
