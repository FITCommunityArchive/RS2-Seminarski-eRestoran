using FirstUserControlUsage;

namespace FastFoodDemo
{
    partial class UnosProizvoda
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NazivtextBox = new System.Windows.Forms.TextBox();
            this.CijenatextBox = new System.Windows.Forms.TextBox();
            this.KolicinatextBox = new System.Windows.Forms.TextBox();
            this.SifratextBox = new System.Windows.Forms.TextBox();
            this.KriticnatextBox = new System.Windows.Forms.TextBox();
            this.unostextbox = new System.Windows.Forms.Label();
            this.TipProizvodacomboBox = new System.Windows.Forms.ComboBox();
            this.TipSkladistacomboBox = new System.Windows.Forms.ComboBox();
            this.MenucomboBox = new System.Windows.Forms.ComboBox();
            this.snimiProizvodbtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backButton1 = new eRestoran.Client.BackButton();
            this.slikaKontrola1 = new eRestoran.Client.SlikaKontrola();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(130, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv proizvoda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(129, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cijena proizvoda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(129, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Šifra proizvoda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(129, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Količina proizvoda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(129, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Kritična količina";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(129, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "U koji menu spada?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(130, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Skladište";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(129, 263);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tip proizvoda";
            // 
            // NazivtextBox
            // 
            this.NazivtextBox.Location = new System.Drawing.Point(276, 65);
            this.NazivtextBox.Name = "NazivtextBox";
            this.NazivtextBox.Size = new System.Drawing.Size(196, 20);
            this.NazivtextBox.TabIndex = 8;
            this.NazivtextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NazivtextBox_Validating);
            // 
            // CijenatextBox
            // 
            this.CijenatextBox.Location = new System.Drawing.Point(276, 103);
            this.CijenatextBox.Name = "CijenatextBox";
            this.CijenatextBox.Size = new System.Drawing.Size(196, 20);
            this.CijenatextBox.TabIndex = 9;
            this.CijenatextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CijenatextBox_Validating);
            // 
            // KolicinatextBox
            // 
            this.KolicinatextBox.Location = new System.Drawing.Point(276, 138);
            this.KolicinatextBox.Name = "KolicinatextBox";
            this.KolicinatextBox.Size = new System.Drawing.Size(196, 20);
            this.KolicinatextBox.TabIndex = 10;
            this.KolicinatextBox.Validating += new System.ComponentModel.CancelEventHandler(this.KolicinatextBox_Validating);
            // 
            // SifratextBox
            // 
            this.SifratextBox.Location = new System.Drawing.Point(276, 171);
            this.SifratextBox.Name = "SifratextBox";
            this.SifratextBox.Size = new System.Drawing.Size(196, 20);
            this.SifratextBox.TabIndex = 11;
            this.SifratextBox.Validating += new System.ComponentModel.CancelEventHandler(this.SifratextBox_Validating);
            // 
            // KriticnatextBox
            // 
            this.KriticnatextBox.Location = new System.Drawing.Point(276, 232);
            this.KriticnatextBox.Name = "KriticnatextBox";
            this.KriticnatextBox.Size = new System.Drawing.Size(196, 20);
            this.KriticnatextBox.TabIndex = 13;
            this.KriticnatextBox.Validating += new System.ComponentModel.CancelEventHandler(this.KriticnatextBox_Validating);
            // 
            // unostextbox
            // 
            this.unostextbox.AutoSize = true;
            this.unostextbox.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unostextbox.Location = new System.Drawing.Point(232, 12);
            this.unostextbox.Name = "unostextbox";
            this.unostextbox.Size = new System.Drawing.Size(169, 24);
            this.unostextbox.TabIndex = 17;
            this.unostextbox.Text = "Unos proizvoda";
            // 
            // TipProizvodacomboBox
            // 
            this.TipProizvodacomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipProizvodacomboBox.FormattingEnabled = true;
            this.TipProizvodacomboBox.Location = new System.Drawing.Point(276, 263);
            this.TipProizvodacomboBox.Name = "TipProizvodacomboBox";
            this.TipProizvodacomboBox.Size = new System.Drawing.Size(196, 21);
            this.TipProizvodacomboBox.TabIndex = 18;
            this.TipProizvodacomboBox.Validating += new System.ComponentModel.CancelEventHandler(this.TipProizvodacomboBox_Validating);
            // 
            // TipSkladistacomboBox
            // 
            this.TipSkladistacomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipSkladistacomboBox.FormattingEnabled = true;
            this.TipSkladistacomboBox.Location = new System.Drawing.Point(276, 291);
            this.TipSkladistacomboBox.Name = "TipSkladistacomboBox";
            this.TipSkladistacomboBox.Size = new System.Drawing.Size(196, 21);
            this.TipSkladistacomboBox.TabIndex = 19;
            this.TipSkladistacomboBox.Validating += new System.ComponentModel.CancelEventHandler(this.TipSkladistacomboBox_Validating);
            // 
            // MenucomboBox
            // 
            this.MenucomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MenucomboBox.FormattingEnabled = true;
            this.MenucomboBox.Location = new System.Drawing.Point(276, 201);
            this.MenucomboBox.Name = "MenucomboBox";
            this.MenucomboBox.Size = new System.Drawing.Size(196, 21);
            this.MenucomboBox.TabIndex = 20;
            this.MenucomboBox.Validating += new System.ComponentModel.CancelEventHandler(this.MenucomboBox_Validating);
            // 
            // snimiProizvodbtn
            // 
            this.snimiProizvodbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.snimiProizvodbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.snimiProizvodbtn.ForeColor = System.Drawing.Color.White;
            this.snimiProizvodbtn.Location = new System.Drawing.Point(276, 346);
            this.snimiProizvodbtn.Name = "snimiProizvodbtn";
            this.snimiProizvodbtn.Size = new System.Drawing.Size(141, 35);
            this.snimiProizvodbtn.TabIndex = 21;
            this.snimiProizvodbtn.Text = "Snimi ";
            this.snimiProizvodbtn.UseVisualStyleBackColor = false;
            this.snimiProizvodbtn.Click += new System.EventHandler(this.snimiProizvodbtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(132, 12);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(62, 29);
            this.backButton1.TabIndex = 26;
            // 
            // slikaKontrola1
            // 
            this.slikaKontrola1.File = null;
            this.slikaKontrola1.Location = new System.Drawing.Point(574, 69);
            this.slikaKontrola1.Name = "slikaKontrola1";
            this.slikaKontrola1.Size = new System.Drawing.Size(190, 226);
            this.slikaKontrola1.TabIndex = 27;
            // 
            // UnosProizvoda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.slikaKontrola1);
            this.Controls.Add(this.backButton1);
            this.Controls.Add(this.snimiProizvodbtn);
            this.Controls.Add(this.MenucomboBox);
            this.Controls.Add(this.TipSkladistacomboBox);
            this.Controls.Add(this.TipProizvodacomboBox);
            this.Controls.Add(this.unostextbox);
            this.Controls.Add(this.KriticnatextBox);
            this.Controls.Add(this.SifratextBox);
            this.Controls.Add(this.KolicinatextBox);
            this.Controls.Add(this.CijenatextBox);
            this.Controls.Add(this.NazivtextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UnosProizvoda";
            this.Size = new System.Drawing.Size(794, 447);
            this.Load += new System.EventHandler(this.UnosProizvoda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NazivtextBox;
        private System.Windows.Forms.TextBox CijenatextBox;
        private System.Windows.Forms.TextBox KolicinatextBox;
        private System.Windows.Forms.TextBox SifratextBox;
        private System.Windows.Forms.TextBox KriticnatextBox;
        private System.Windows.Forms.Label unostextbox;
        private System.Windows.Forms.ComboBox TipProizvodacomboBox;
        private System.Windows.Forms.ComboBox TipSkladistacomboBox;
        private System.Windows.Forms.ComboBox MenucomboBox;
        private System.Windows.Forms.Button snimiProizvodbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private eRestoran.Client.BackButton backButton1;
        private eRestoran.Client.SlikaKontrola slikaKontrola1;
    }
}
