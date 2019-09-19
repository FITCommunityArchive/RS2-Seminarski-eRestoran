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
            this.nazivProizvodaLabel = new System.Windows.Forms.Label();
            this.PrezimeLabel = new System.Windows.Forms.Label();
            this.staraCijenaLabel = new System.Windows.Forms.Label();
            this.datumOdLabel = new System.Windows.Forms.Label();
            this.sifraTextBox = new System.Windows.Forms.TextBox();
            this.nazivProizvodaTextBox = new System.Windows.Forms.TextBox();
            this.staraCijenaTextBox = new System.Windows.Forms.TextBox();
            this.datumOdDate = new System.Windows.Forms.DateTimePicker();
            this.snimiPromocijuBtn = new System.Windows.Forms.Button();
            this.NaslovLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.promocijeCijenaTextBox = new System.Windows.Forms.TextBox();
            this.promotivnaLabel = new System.Windows.Forms.Label();
            this.searchArtikal = new System.Windows.Forms.Button();
            this.datumDoDate = new System.Windows.Forms.DateTimePicker();
            this.datumDoLabel = new System.Windows.Forms.Label();
            this.slikaArtiklaPromocija = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slikaArtiklaPromocija)).BeginInit();
            this.SuspendLayout();
            // 
            // nazivProizvodaLabel
            // 
            this.nazivProizvodaLabel.AutoSize = true;
            this.nazivProizvodaLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.nazivProizvodaLabel.Location = new System.Drawing.Point(53, 131);
            this.nazivProizvodaLabel.Name = "nazivProizvodaLabel";
            this.nazivProizvodaLabel.Size = new System.Drawing.Size(123, 18);
            this.nazivProizvodaLabel.TabIndex = 0;
            this.nazivProizvodaLabel.Text = "Naziv proizvoda";
            this.nazivProizvodaLabel.Visible = false;
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
            // staraCijenaLabel
            // 
            this.staraCijenaLabel.AutoSize = true;
            this.staraCijenaLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.staraCijenaLabel.Location = new System.Drawing.Point(52, 175);
            this.staraCijenaLabel.Name = "staraCijenaLabel";
            this.staraCijenaLabel.Size = new System.Drawing.Size(91, 18);
            this.staraCijenaLabel.TabIndex = 2;
            this.staraCijenaLabel.Text = "Stara cijena";
            this.staraCijenaLabel.Visible = false;
            // 
            // datumOdLabel
            // 
            this.datumOdLabel.AutoSize = true;
            this.datumOdLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.datumOdLabel.Location = new System.Drawing.Point(53, 260);
            this.datumOdLabel.Name = "datumOdLabel";
            this.datumOdLabel.Size = new System.Drawing.Size(75, 18);
            this.datumOdLabel.TabIndex = 4;
            this.datumOdLabel.Text = "Datum od";
            this.datumOdLabel.Visible = false;
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
            this.nazivProizvodaTextBox.Location = new System.Drawing.Point(201, 130);
            this.nazivProizvodaTextBox.Name = "nazivProizvodaTextBox";
            this.nazivProizvodaTextBox.Size = new System.Drawing.Size(220, 20);
            this.nazivProizvodaTextBox.TabIndex = 8;
            this.nazivProizvodaTextBox.Visible = false;
            this.nazivProizvodaTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.prezimeTextBox_Validating);
            // 
            // staraCijenaTextBox
            // 
            this.staraCijenaTextBox.Location = new System.Drawing.Point(202, 174);
            this.staraCijenaTextBox.Name = "staraCijenaTextBox";
            this.staraCijenaTextBox.Size = new System.Drawing.Size(220, 20);
            this.staraCijenaTextBox.TabIndex = 9;
            this.staraCijenaTextBox.Visible = false;
            this.staraCijenaTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.usernamaTextBox_Validating);
            // 
            // datumOdDate
            // 
            this.datumOdDate.Location = new System.Drawing.Point(201, 261);
            this.datumOdDate.Name = "datumOdDate";
            this.datumOdDate.Size = new System.Drawing.Size(220, 20);
            this.datumOdDate.TabIndex = 12;
            this.datumOdDate.Visible = false;
            this.datumOdDate.Validating += new System.ComponentModel.CancelEventHandler(this.datumRodjenjaDateTimePicker_Validating);
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
            this.NaslovLabel.Location = new System.Drawing.Point(57, 16);
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
            this.promocijeCijenaTextBox.Location = new System.Drawing.Point(202, 218);
            this.promocijeCijenaTextBox.Name = "promocijeCijenaTextBox";
            this.promocijeCijenaTextBox.PasswordChar = '*';
            this.promocijeCijenaTextBox.Size = new System.Drawing.Size(220, 20);
            this.promocijeCijenaTextBox.TabIndex = 10;
            this.promocijeCijenaTextBox.Visible = false;
            this.promocijeCijenaTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.passwordTextBox_Validating);
            // 
            // promotivnaLabel
            // 
            this.promotivnaLabel.AutoSize = true;
            this.promotivnaLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.promotivnaLabel.Location = new System.Drawing.Point(53, 219);
            this.promotivnaLabel.Name = "promotivnaLabel";
            this.promotivnaLabel.Size = new System.Drawing.Size(135, 18);
            this.promotivnaLabel.TabIndex = 3;
            this.promotivnaLabel.Text = "Promotivna cijena";
            this.promotivnaLabel.Visible = false;
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
            this.searchArtikal.Click += new System.EventHandler(this.SearchArtikal_Click);
            // 
            // datumDoDate
            // 
            this.datumDoDate.Location = new System.Drawing.Point(202, 303);
            this.datumDoDate.Name = "datumDoDate";
            this.datumDoDate.Size = new System.Drawing.Size(220, 20);
            this.datumDoDate.TabIndex = 62;
            this.datumDoDate.Visible = false;
            // 
            // datumDoLabel
            // 
            this.datumDoLabel.AutoSize = true;
            this.datumDoLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.datumDoLabel.Location = new System.Drawing.Point(55, 305);
            this.datumDoLabel.Name = "datumDoLabel";
            this.datumDoLabel.Size = new System.Drawing.Size(75, 18);
            this.datumDoLabel.TabIndex = 61;
            this.datumDoLabel.Text = "Datum do";
            this.datumDoLabel.Visible = false;
            // 
            // slikaArtiklaPromocija
            // 
            this.slikaArtiklaPromocija.Location = new System.Drawing.Point(491, 127);
            this.slikaArtiklaPromocija.Name = "slikaArtiklaPromocija";
            this.slikaArtiklaPromocija.Size = new System.Drawing.Size(227, 198);
            this.slikaArtiklaPromocija.TabIndex = 63;
            this.slikaArtiklaPromocija.TabStop = false;
            this.slikaArtiklaPromocija.Visible = false;
            // 
            // Promocija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.slikaArtiklaPromocija);
            this.Controls.Add(this.datumDoDate);
            this.Controls.Add(this.datumDoLabel);
            this.Controls.Add(this.searchArtikal);
            this.Controls.Add(this.NaslovLabel);
            this.Controls.Add(this.snimiPromocijuBtn);
            this.Controls.Add(this.datumOdDate);
            this.Controls.Add(this.promocijeCijenaTextBox);
            this.Controls.Add(this.staraCijenaTextBox);
            this.Controls.Add(this.nazivProizvodaTextBox);
            this.Controls.Add(this.sifraTextBox);
            this.Controls.Add(this.datumOdLabel);
            this.Controls.Add(this.promotivnaLabel);
            this.Controls.Add(this.staraCijenaLabel);
            this.Controls.Add(this.PrezimeLabel);
            this.Controls.Add(this.nazivProizvodaLabel);
            this.Name = "Promocija";
            this.Size = new System.Drawing.Size(794, 447);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slikaArtiklaPromocija)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nazivProizvodaLabel;
        private System.Windows.Forms.Label PrezimeLabel;
        private System.Windows.Forms.Label staraCijenaLabel;
        private System.Windows.Forms.Label datumOdLabel;
        private System.Windows.Forms.TextBox sifraTextBox;
        private System.Windows.Forms.TextBox nazivProizvodaTextBox;
        private System.Windows.Forms.TextBox staraCijenaTextBox;
        private System.Windows.Forms.DateTimePicker datumOdDate;
        private System.Windows.Forms.Button snimiPromocijuBtn;
        private System.Windows.Forms.Label NaslovLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox promocijeCijenaTextBox;
        private System.Windows.Forms.Label promotivnaLabel;
        private System.Windows.Forms.DateTimePicker datumDoDate;
        private System.Windows.Forms.Label datumDoLabel;
        private System.Windows.Forms.Button searchArtikal;
        private System.Windows.Forms.PictureBox slikaArtiklaPromocija;
    }
}
