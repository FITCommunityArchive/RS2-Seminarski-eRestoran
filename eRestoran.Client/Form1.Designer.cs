using eRestoran.Client;
using FirstUserControlUsage;

namespace FastFoodDemo
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPromocije = new System.Windows.Forms.Button();
            this.digitalClock1 = new eRestoran.Client.DigitalClock();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.btnIzvjestaji = new System.Windows.Forms.Button();
            this.btnRezervacije = new System.Windows.Forms.Button();
            this.btnNalozi = new System.Windows.Forms.Button();
            this.btnPonuda = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cardsPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.cartButton = new System.Windows.Forms.Button();
            this.btnOdaberiSto = new System.Windows.Forms.Button();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.korisnikUlogaLabel = new System.Windows.Forms.Label();
            this.korisnikLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.btnPromocije);
            this.panel1.Controls.Add(this.digitalClock1);
            this.panel1.Controls.Add(this.SidePanel);
            this.panel1.Controls.Add(this.btnIzvjestaji);
            this.panel1.Controls.Add(this.btnRezervacije);
            this.panel1.Controls.Add(this.btnNalozi);
            this.panel1.Controls.Add(this.btnPonuda);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 687);
            this.panel1.TabIndex = 0;
            // 
            // btnPromocije
            // 
            this.btnPromocije.FlatAppearance.BorderSize = 0;
            this.btnPromocije.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromocije.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromocije.ForeColor = System.Drawing.Color.White;
            this.btnPromocije.Image = ((System.Drawing.Image)(resources.GetObject("btnPromocije.Image")));
            this.btnPromocije.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPromocije.Location = new System.Drawing.Point(10, 383);
            this.btnPromocije.Name = "btnPromocije";
            this.btnPromocije.Size = new System.Drawing.Size(197, 54);
            this.btnPromocije.TabIndex = 13;
            this.btnPromocije.Text = "       Promocije";
            this.btnPromocije.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPromocije.UseVisualStyleBackColor = true;
            this.btnPromocije.Visible = false;
            this.btnPromocije.Click += new System.EventHandler(this.Button1_Click);
            // 
            // digitalClock1
            // 
            this.digitalClock1.BackColor = System.Drawing.Color.Transparent;
            this.digitalClock1.ForeColor = System.Drawing.Color.White;
            this.digitalClock1.Location = new System.Drawing.Point(32, 12);
            this.digitalClock1.Name = "digitalClock1";
            this.digitalClock1.Size = new System.Drawing.Size(149, 77);
            this.digitalClock1.TabIndex = 12;
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.SidePanel.Location = new System.Drawing.Point(1, 97);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(10, 54);
            this.SidePanel.TabIndex = 4;
            // 
            // btnIzvjestaji
            // 
            this.btnIzvjestaji.FlatAppearance.BorderSize = 0;
            this.btnIzvjestaji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzvjestaji.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzvjestaji.ForeColor = System.Drawing.Color.White;
            this.btnIzvjestaji.Image = ((System.Drawing.Image)(resources.GetObject("btnIzvjestaji.Image")));
            this.btnIzvjestaji.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIzvjestaji.Location = new System.Drawing.Point(12, 440);
            this.btnIzvjestaji.Name = "btnIzvjestaji";
            this.btnIzvjestaji.Size = new System.Drawing.Size(194, 54);
            this.btnIzvjestaji.TabIndex = 4;
            this.btnIzvjestaji.Text = "       Izvještaji";
            this.btnIzvjestaji.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIzvjestaji.UseVisualStyleBackColor = true;
            this.btnIzvjestaji.Visible = false;
            this.btnIzvjestaji.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnRezervacije
            // 
            this.btnRezervacije.FlatAppearance.BorderSize = 0;
            this.btnRezervacije.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezervacije.ForeColor = System.Drawing.Color.White;
            this.btnRezervacije.Image = ((System.Drawing.Image)(resources.GetObject("btnRezervacije.Image")));
            this.btnRezervacije.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRezervacije.Location = new System.Drawing.Point(12, 205);
            this.btnRezervacije.Name = "btnRezervacije";
            this.btnRezervacije.Size = new System.Drawing.Size(197, 54);
            this.btnRezervacije.TabIndex = 4;
            this.btnRezervacije.Text = "       Stolovi";
            this.btnRezervacije.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRezervacije.UseVisualStyleBackColor = true;
            this.btnRezervacije.Click += new System.EventHandler(this.btnRezervacije_Click);
            // 
            // btnNalozi
            // 
            this.btnNalozi.FlatAppearance.BorderSize = 0;
            this.btnNalozi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNalozi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNalozi.ForeColor = System.Drawing.Color.White;
            this.btnNalozi.Image = ((System.Drawing.Image)(resources.GetObject("btnNalozi.Image")));
            this.btnNalozi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNalozi.Location = new System.Drawing.Point(12, 324);
            this.btnNalozi.Name = "btnNalozi";
            this.btnNalozi.Size = new System.Drawing.Size(197, 54);
            this.btnNalozi.TabIndex = 4;
            this.btnNalozi.Text = "       Korisnički nalozi";
            this.btnNalozi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNalozi.UseVisualStyleBackColor = true;
            this.btnNalozi.Visible = false;
            this.btnNalozi.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnPonuda
            // 
            this.btnPonuda.FlatAppearance.BorderSize = 0;
            this.btnPonuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPonuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPonuda.ForeColor = System.Drawing.Color.White;
            this.btnPonuda.Image = ((System.Drawing.Image)(resources.GetObject("btnPonuda.Image")));
            this.btnPonuda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPonuda.Location = new System.Drawing.Point(12, 155);
            this.btnPonuda.Name = "btnPonuda";
            this.btnPonuda.Size = new System.Drawing.Size(197, 54);
            this.btnPonuda.TabIndex = 4;
            this.btnPonuda.Text = "       Menu";
            this.btnPonuda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPonuda.UseVisualStyleBackColor = true;
            this.btnPonuda.Click += new System.EventHandler(this.btnPonuda_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.Location = new System.Drawing.Point(12, 265);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(197, 54);
            this.btnMenu.TabIndex = 4;
            this.btnMenu.Text = "       Uredi ponudu";
            this.btnMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Visible = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(12, 95);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(197, 54);
            this.btnHome.TabIndex = 4;
            this.btnHome.Text = "       Home";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(209, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(871, 10);
            this.panel2.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1026, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 35);
            this.btnExit.TabIndex = 4;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button13_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Restaurant";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "eRestoran";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.Location = new System.Drawing.Point(243, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(111, 96);
            this.panel3.TabIndex = 2;
            // 
            // cardsPanel1
            // 
            this.cardsPanel1.Location = new System.Drawing.Point(243, 133);
            this.cardsPanel1.Name = "cardsPanel1";
            this.cardsPanel1.Size = new System.Drawing.Size(815, 525);
            this.cardsPanel1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(426, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "0 KM";
            // 
            // cartButton
            // 
            this.cartButton.BackColor = System.Drawing.Color.Transparent;
            this.cartButton.FlatAppearance.BorderSize = 0;
            this.cartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartButton.ForeColor = System.Drawing.Color.White;
            this.cartButton.Image = ((System.Drawing.Image)(resources.GetObject("cartButton.Image")));
            this.cartButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cartButton.Location = new System.Drawing.Point(357, 12);
            this.cartButton.Name = "cartButton";
            this.cartButton.Size = new System.Drawing.Size(63, 55);
            this.cartButton.TabIndex = 4;
            this.cartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cartButton.UseVisualStyleBackColor = false;
            this.cartButton.Click += new System.EventHandler(this.cartButton_Click);
            // 
            // btnOdaberiSto
            // 
            this.btnOdaberiSto.BackColor = System.Drawing.SystemColors.Control;
            this.btnOdaberiSto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdaberiSto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOdaberiSto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnOdaberiSto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOdaberiSto.Location = new System.Drawing.Point(372, 66);
            this.btnOdaberiSto.Name = "btnOdaberiSto";
            this.btnOdaberiSto.Size = new System.Drawing.Size(101, 30);
            this.btnOdaberiSto.TabIndex = 12;
            this.btnOdaberiSto.Text = "ODABERI STO";
            this.btnOdaberiSto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOdaberiSto.UseVisualStyleBackColor = false;
            this.btnOdaberiSto.Visible = false;
            this.btnOdaberiSto.Click += new System.EventHandler(this.btnRezervacije_Click);
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.FlatAppearance.BorderSize = 0;
            this.LogOutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutBtn.ForeColor = System.Drawing.Color.LightGray;
            this.LogOutBtn.Image = ((System.Drawing.Image)(resources.GetObject("LogOutBtn.Image")));
            this.LogOutBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LogOutBtn.Location = new System.Drawing.Point(988, 19);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(32, 35);
            this.LogOutBtn.TabIndex = 13;
            this.LogOutBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.LogOutBtn.UseVisualStyleBackColor = true;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(767, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Trenutni korisnik - ";
            // 
            // korisnikUlogaLabel
            // 
            this.korisnikUlogaLabel.AutoSize = true;
            this.korisnikUlogaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.korisnikUlogaLabel.Location = new System.Drawing.Point(785, 27);
            this.korisnikUlogaLabel.Name = "korisnikUlogaLabel";
            this.korisnikUlogaLabel.Size = new System.Drawing.Size(0, 18);
            this.korisnikUlogaLabel.TabIndex = 15;
            // 
            // korisnikLabel
            // 
            this.korisnikLabel.AutoSize = true;
            this.korisnikLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.korisnikLabel.Location = new System.Drawing.Point(913, 27);
            this.korisnikLabel.Name = "korisnikLabel";
            this.korisnikLabel.Size = new System.Drawing.Size(54, 18);
            this.korisnikLabel.TabIndex = 16;
            this.korisnikLabel.Text = "Klijent";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 687);
            this.Controls.Add(this.korisnikLabel);
            this.Controls.Add(this.korisnikUlogaLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogOutBtn);
            this.Controls.Add(this.btnOdaberiSto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cardsPanel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cartButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
         
        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Button btnIzvjestaji;
        private System.Windows.Forms.Button btnRezervacije;
        private System.Windows.Forms.Button btnNalozi;
        private System.Windows.Forms.Button btnPonuda;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private UrediProizvod firstCustomControl3;
        private PonudaVM viewModel;
        public System.Windows.Forms.FlowLayoutPanel cardsPanel1; // nije riješenje problema
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cartButton;
        private DigitalClock digitalClock1;
        private System.Windows.Forms.Button btnOdaberiSto;
        private System.Windows.Forms.Button btnPromocije;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label korisnikUlogaLabel;
        private System.Windows.Forms.Label korisnikLabel;
    }
}

