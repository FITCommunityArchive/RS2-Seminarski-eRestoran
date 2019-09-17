namespace eRestoran.Client
{
    partial class Promocija
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
            this.ImeLabel = new System.Windows.Forms.Label();
            this.PrezimeLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.DatumRodjenjaLabel = new System.Windows.Forms.Label();
            this.sifraTextBox = new System.Windows.Forms.TextBox();
            this.nazivProizvodaTextBox = new System.Windows.Forms.TextBox();
            this.staraCijenaTextBox = new System.Windows.Forms.TextBox();
            this.datumOd = new System.Windows.Forms.DateTimePicker();
            this.snimiPromocijuBtn = new System.Windows.Forms.Button();
            this.NaslovLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.promocijeCijenaTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.backButton1 = new eRestoran.Client.BackButton();
            this.searchArtikal = new System.Windows.Forms.Button();
            this.datumDo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.slikaArtiklaPromocija = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slikaArtiklaPromocija)).BeginInit();
            this.SuspendLayout();
            // 
            // ImeLabel
            // 
            this.ImeLabel.AutoSize = true;
            this.ImeLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.ImeLabel.Location = new System.Drawing.Point(53, 128);
            this.ImeLabel.Name = "ImeLabel";
            this.ImeLabel.Size = new System.Drawing.Size(123, 18);
            this.ImeLabel.TabIndex = 0;
            this.ImeLabel.Text = "Naziv proizvoda";
            // 
            // PrezimeLabel
            // 
            this.PrezimeLabel.AutoSize = true;
            this.PrezimeLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.PrezimeLabel.Location = new System.Drawing.Point(52, 84);
            this.PrezimeLabel.Name = "PrezimeLabel";
            this.PrezimeLabel.Size = new System.Drawing.Size(116, 18);
            this.PrezimeLabel.TabIndex = 1;
            this.PrezimeLabel.Text = "Sifra proizvoda";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.UsernameLabel.Location = new System.Drawing.Point(52, 172);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(91, 18);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Stara cijena";
            // 
            // DatumRodjenjaLabel
            // 
            this.DatumRodjenjaLabel.AutoSize = true;
            this.DatumRodjenjaLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.DatumRodjenjaLabel.Location = new System.Drawing.Point(54, 256);
            this.DatumRodjenjaLabel.Name = "DatumRodjenjaLabel";
            this.DatumRodjenjaLabel.Size = new System.Drawing.Size(75, 18);
            this.DatumRodjenjaLabel.TabIndex = 4;
            this.DatumRodjenjaLabel.Text = "Datum od";
            // 
            // sifraTextBox
            // 
            this.sifraTextBox.Location = new System.Drawing.Point(202, 84);
            this.sifraTextBox.Name = "sifraTextBox";
            this.sifraTextBox.Size = new System.Drawing.Size(220, 20);
            this.sifraTextBox.TabIndex = 7;
            this.sifraTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.imeTextBox_Validating);
            // 
            // nazivProizvodaTextBox
            // 
            this.nazivProizvodaTextBox.Location = new System.Drawing.Point(201, 127);
            this.nazivProizvodaTextBox.Name = "nazivProizvodaTextBox";
            this.nazivProizvodaTextBox.Size = new System.Drawing.Size(220, 20);
            this.nazivProizvodaTextBox.TabIndex = 8;
            this.nazivProizvodaTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.prezimeTextBox_Validating);
            // 
            // staraCijenaTextBox
            // 
            this.staraCijenaTextBox.Location = new System.Drawing.Point(202, 171);
            this.staraCijenaTextBox.Name = "staraCijenaTextBox";
            this.staraCijenaTextBox.Size = new System.Drawing.Size(220, 20);
            this.staraCijenaTextBox.TabIndex = 9;
            this.staraCijenaTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.usernamaTextBox_Validating);
            // 
            // datumOd
            // 
            this.datumOd.Location = new System.Drawing.Point(201, 257);
            this.datumOd.Name = "datumOd";
            this.datumOd.Size = new System.Drawing.Size(220, 20);
            this.datumOd.TabIndex = 12;
            this.datumOd.Validating += new System.ComponentModel.CancelEventHandler(this.datumRodjenjaDateTimePicker_Validating);
            // 
            // snimiPromocijuBtn
            // 
            this.snimiPromocijuBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.snimiPromocijuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.snimiPromocijuBtn.ForeColor = System.Drawing.Color.White;
            this.snimiPromocijuBtn.Location = new System.Drawing.Point(309, 375);
            this.snimiPromocijuBtn.Name = "snimiPromocijuBtn";
            this.snimiPromocijuBtn.Size = new System.Drawing.Size(141, 35);
            this.snimiPromocijuBtn.TabIndex = 44;
            this.snimiPromocijuBtn.Text = "Snimi promociju";
            this.snimiPromocijuBtn.UseVisualStyleBackColor = false;
            this.snimiPromocijuBtn.Click += new System.EventHandler(this.snimiKorbtn_Click);
            // 
            // NaslovLabel
            // 
            this.NaslovLabel.AutoSize = true;
            this.NaslovLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NaslovLabel.Location = new System.Drawing.Point(215, 16);
            this.NaslovLabel.Name = "NaslovLabel";
            this.NaslovLabel.Size = new System.Drawing.Size(252, 29);
            this.NaslovLabel.TabIndex = 45;
            this.NaslovLabel.Text = "Promocija proizvoda";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // promocijeCijenaTextBox
            // 
            this.promocijeCijenaTextBox.Location = new System.Drawing.Point(202, 214);
            this.promocijeCijenaTextBox.Name = "promocijeCijenaTextBox";
            this.promocijeCijenaTextBox.PasswordChar = '*';
            this.promocijeCijenaTextBox.Size = new System.Drawing.Size(220, 20);
            this.promocijeCijenaTextBox.TabIndex = 10;
            this.promocijeCijenaTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.passwordTextBox_Validating);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.PasswordLabel.Location = new System.Drawing.Point(53, 216);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(135, 18);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Promotivna cijena";
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(114, 16);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(62, 29);
            this.backButton1.TabIndex = 59;
            // 
            // searchArtikal
            // 
            this.searchArtikal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.searchArtikal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.searchArtikal.ForeColor = System.Drawing.Color.White;
            this.searchArtikal.Location = new System.Drawing.Point(528, 76);
            this.searchArtikal.Name = "searchArtikal";
            this.searchArtikal.Size = new System.Drawing.Size(141, 35);
            this.searchArtikal.TabIndex = 60;
            this.searchArtikal.Text = "Trazi proizvod";
            this.searchArtikal.UseVisualStyleBackColor = false;
            // 
            // datumDo
            // 
            this.datumDo.Location = new System.Drawing.Point(202, 297);
            this.datumDo.Name = "datumDo";
            this.datumDo.Size = new System.Drawing.Size(220, 20);
            this.datumDo.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(55, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 61;
            this.label1.Text = "Datum do";
            // 
            // slikaArtiklaPromocija
            // 
            this.slikaArtiklaPromocija.Location = new System.Drawing.Point(491, 117);
            this.slikaArtiklaPromocija.Name = "slikaArtiklaPromocija";
            this.slikaArtiklaPromocija.Size = new System.Drawing.Size(227, 198);
            this.slikaArtiklaPromocija.TabIndex = 63;
            this.slikaArtiklaPromocija.TabStop = false;
            // 
            // Promocija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.slikaArtiklaPromocija);
            this.Controls.Add(this.datumDo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchArtikal);
            this.Controls.Add(this.backButton1);
            this.Controls.Add(this.NaslovLabel);
            this.Controls.Add(this.snimiPromocijuBtn);
            this.Controls.Add(this.datumOd);
            this.Controls.Add(this.promocijeCijenaTextBox);
            this.Controls.Add(this.staraCijenaTextBox);
            this.Controls.Add(this.nazivProizvodaTextBox);
            this.Controls.Add(this.sifraTextBox);
            this.Controls.Add(this.DatumRodjenjaLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PrezimeLabel);
            this.Controls.Add(this.ImeLabel);
            this.Name = "Promocija";
            this.Size = new System.Drawing.Size(794, 447);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slikaArtiklaPromocija)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ImeLabel;
        private System.Windows.Forms.Label PrezimeLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label DatumRodjenjaLabel;
        private System.Windows.Forms.TextBox sifraTextBox;
        private System.Windows.Forms.TextBox nazivProizvodaTextBox;
        private System.Windows.Forms.TextBox staraCijenaTextBox;
        private System.Windows.Forms.DateTimePicker datumOd;
        private System.Windows.Forms.Button snimiPromocijuBtn;
        private System.Windows.Forms.Label NaslovLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox promocijeCijenaTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private BackButton backButton1;
        private System.Windows.Forms.DateTimePicker datumDo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchArtikal;
        private System.Windows.Forms.PictureBox slikaArtiklaPromocija;
    }
}
