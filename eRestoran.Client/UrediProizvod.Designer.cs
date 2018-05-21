namespace eRestoran.Client
{
    partial class UrediProizvod
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ProizvodpictureBox = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dodajSlikubutton = new System.Windows.Forms.Button();
            this.snimiProizvodbtn = new System.Windows.Forms.Button();
            this.MenucomboBox = new System.Windows.Forms.ComboBox();
            this.TipSkladistacomboBox = new System.Windows.Forms.ComboBox();
            this.TipProizvodacomboBox = new System.Windows.Forms.ComboBox();
            this.unostextbox = new System.Windows.Forms.Label();
            this.KriticnatextBox = new System.Windows.Forms.TextBox();
            this.KolicinatextBox = new System.Windows.Forms.TextBox();
            this.CijenatextBox = new System.Windows.Forms.TextBox();
            this.NazivtextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backButton1 = new eRestoran.Client.BackButton();
            ((System.ComponentModel.ISupportInitialize)(this.ProizvodpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ProizvodpictureBox
            // 
            this.ProizvodpictureBox.Location = new System.Drawing.Point(518, 136);
            this.ProizvodpictureBox.Name = "ProizvodpictureBox";
            this.ProizvodpictureBox.Size = new System.Drawing.Size(161, 149);
            this.ProizvodpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProizvodpictureBox.TabIndex = 46;
            this.ProizvodpictureBox.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(579, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 19);
            this.label9.TabIndex = 45;
            this.label9.Text = "Slika";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dodajSlikubutton
            // 
            this.dodajSlikubutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.dodajSlikubutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.dodajSlikubutton.ForeColor = System.Drawing.Color.White;
            this.dodajSlikubutton.Location = new System.Drawing.Point(533, 296);
            this.dodajSlikubutton.Name = "dodajSlikubutton";
            this.dodajSlikubutton.Size = new System.Drawing.Size(125, 34);
            this.dodajSlikubutton.TabIndex = 47;
            this.dodajSlikubutton.Text = "Učitaj sliku";
            this.dodajSlikubutton.UseVisualStyleBackColor = false;
            // 
            // snimiProizvodbtn
            // 
            this.snimiProizvodbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.snimiProizvodbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.snimiProizvodbtn.ForeColor = System.Drawing.Color.White;
            this.snimiProizvodbtn.Location = new System.Drawing.Point(223, 348);
            this.snimiProizvodbtn.Name = "snimiProizvodbtn";
            this.snimiProizvodbtn.Size = new System.Drawing.Size(141, 35);
            this.snimiProizvodbtn.TabIndex = 43;
            this.snimiProizvodbtn.Text = "Snimi ";
            this.snimiProizvodbtn.UseVisualStyleBackColor = false;
            this.snimiProizvodbtn.Click += new System.EventHandler(this.snimiProizvodbtn_Click);
            // 
            // MenucomboBox
            // 
            this.MenucomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MenucomboBox.FormattingEnabled = true;
            this.MenucomboBox.Location = new System.Drawing.Point(223, 202);
            this.MenucomboBox.Name = "MenucomboBox";
            this.MenucomboBox.Size = new System.Drawing.Size(196, 21);
            this.MenucomboBox.TabIndex = 42;
            this.MenucomboBox.Validating += new System.ComponentModel.CancelEventHandler(this.MenucomboBox_Validating);
            // 
            // TipSkladistacomboBox
            // 
            this.TipSkladistacomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipSkladistacomboBox.FormattingEnabled = true;
            this.TipSkladistacomboBox.Location = new System.Drawing.Point(223, 296);
            this.TipSkladistacomboBox.Name = "TipSkladistacomboBox";
            this.TipSkladistacomboBox.Size = new System.Drawing.Size(196, 21);
            this.TipSkladistacomboBox.TabIndex = 41;
            this.TipSkladistacomboBox.Validating += new System.ComponentModel.CancelEventHandler(this.TipSkladistacomboBox_Validating);
            // 
            // TipProizvodacomboBox
            // 
            this.TipProizvodacomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipProizvodacomboBox.FormattingEnabled = true;
            this.TipProizvodacomboBox.Location = new System.Drawing.Point(223, 264);
            this.TipProizvodacomboBox.Name = "TipProizvodacomboBox";
            this.TipProizvodacomboBox.Size = new System.Drawing.Size(196, 21);
            this.TipProizvodacomboBox.TabIndex = 40;
            this.TipProizvodacomboBox.Validating += new System.ComponentModel.CancelEventHandler(this.TipProizvodacomboBox_Validating);
            // 
            // unostextbox
            // 
            this.unostextbox.AutoSize = true;
            this.unostextbox.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unostextbox.Location = new System.Drawing.Point(179, 45);
            this.unostextbox.Name = "unostextbox";
            this.unostextbox.Size = new System.Drawing.Size(157, 24);
            this.unostextbox.TabIndex = 39;
            this.unostextbox.Text = "Uredi proizvod";
            // 
            // KriticnatextBox
            // 
            this.KriticnatextBox.Location = new System.Drawing.Point(223, 231);
            this.KriticnatextBox.Name = "KriticnatextBox";
            this.KriticnatextBox.Size = new System.Drawing.Size(196, 20);
            this.KriticnatextBox.TabIndex = 38;
            this.KriticnatextBox.Validating += new System.ComponentModel.CancelEventHandler(this.KriticnatextBox_Validating);
            // 
            // KolicinatextBox
            // 
            this.KolicinatextBox.Location = new System.Drawing.Point(223, 171);
            this.KolicinatextBox.Name = "KolicinatextBox";
            this.KolicinatextBox.Size = new System.Drawing.Size(196, 20);
            this.KolicinatextBox.TabIndex = 36;
            this.KolicinatextBox.Validating += new System.ComponentModel.CancelEventHandler(this.KolicinatextBox_Validating);
            // 
            // CijenatextBox
            // 
            this.CijenatextBox.Location = new System.Drawing.Point(223, 136);
            this.CijenatextBox.Name = "CijenatextBox";
            this.CijenatextBox.Size = new System.Drawing.Size(196, 20);
            this.CijenatextBox.TabIndex = 35;
            this.CijenatextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CijenatextBox_Validating);
            // 
            // NazivtextBox
            // 
            this.NazivtextBox.Location = new System.Drawing.Point(223, 98);
            this.NazivtextBox.Name = "NazivtextBox";
            this.NazivtextBox.Size = new System.Drawing.Size(196, 20);
            this.NazivtextBox.TabIndex = 34;
            this.NazivtextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NazivtextBox_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(77, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Skladište";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(77, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "Tip proizvoda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(81, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Kritična količina";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(76, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "U koji menu spada?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(76, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Količina proizvoda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(76, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Cijena proizvoda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(77, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Naziv proizvoda";
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(79, 45);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(62, 29);
            this.backButton1.TabIndex = 48;
            // 
            // UrediProizvod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backButton1);
            this.Controls.Add(this.ProizvodpictureBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dodajSlikubutton);
            this.Controls.Add(this.snimiProizvodbtn);
            this.Controls.Add(this.MenucomboBox);
            this.Controls.Add(this.TipSkladistacomboBox);
            this.Controls.Add(this.TipProizvodacomboBox);
            this.Controls.Add(this.unostextbox);
            this.Controls.Add(this.KriticnatextBox);
            this.Controls.Add(this.KolicinatextBox);
            this.Controls.Add(this.CijenatextBox);
            this.Controls.Add(this.NazivtextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UrediProizvod";
            this.Size = new System.Drawing.Size(754, 452);
            ((System.ComponentModel.ISupportInitialize)(this.ProizvodpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox ProizvodpictureBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button dodajSlikubutton;
        private System.Windows.Forms.Button snimiProizvodbtn;
        private System.Windows.Forms.ComboBox MenucomboBox;
        private System.Windows.Forms.ComboBox TipSkladistacomboBox;
        private System.Windows.Forms.ComboBox TipProizvodacomboBox;
        private System.Windows.Forms.Label unostextbox;
        private System.Windows.Forms.TextBox KriticnatextBox;
        private System.Windows.Forms.TextBox KolicinatextBox;
        private System.Windows.Forms.TextBox CijenatextBox;
        private System.Windows.Forms.TextBox NazivtextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private BackButton backButton1;
    }
}
