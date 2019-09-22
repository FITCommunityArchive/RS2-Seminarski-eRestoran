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
            this.nazivProizvodaLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nazivProizvodaLabel.Location = new System.Drawing.Point(33, 142);
            this.nazivProizvodaLabel.Name = "nazivProizvodaLabel";
            this.nazivProizvodaLabel.Size = new System.Drawing.Size(133, 19);
            this.nazivProizvodaLabel.TabIndex = 0;
            this.nazivProizvodaLabel.Text = "Naziv proizvoda";
            this.nazivProizvodaLabel.Visible = false;
            // 
            // PrezimeLabel
            // 
            this.PrezimeLabel.AutoSize = true;
            this.PrezimeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrezimeLabel.Location = new System.Drawing.Point(31, 84);
            this.PrezimeLabel.Name = "PrezimeLabel";
            this.PrezimeLabel.Size = new System.Drawing.Size(125, 19);
            this.PrezimeLabel.TabIndex = 1;
            this.PrezimeLabel.Text = "Sifra proizvoda";
            // 
            // staraCijenaLabel
            // 
            this.staraCijenaLabel.AutoSize = true;
            this.staraCijenaLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staraCijenaLabel.Location = new System.Drawing.Point(31, 197);
            this.staraCijenaLabel.Name = "staraCijenaLabel";
            this.staraCijenaLabel.Size = new System.Drawing.Size(98, 19);
            this.staraCijenaLabel.TabIndex = 2;
            this.staraCijenaLabel.Text = "Stara cijena";
            this.staraCijenaLabel.Visible = false;
            // 
            // datumOdLabel
            // 
            this.datumOdLabel.AutoSize = true;
            this.datumOdLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datumOdLabel.Location = new System.Drawing.Point(33, 300);
            this.datumOdLabel.Name = "datumOdLabel";
            this.datumOdLabel.Size = new System.Drawing.Size(151, 19);
            this.datumOdLabel.TabIndex = 4;
            this.datumOdLabel.Text = "Početak promocije";
            this.datumOdLabel.Visible = false;
            // 
            // sifraTextBox
            // 
            this.sifraTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sifraTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sifraTextBox.Location = new System.Drawing.Point(215, 84);
            this.sifraTextBox.Name = "sifraTextBox";
            this.sifraTextBox.Size = new System.Drawing.Size(261, 26);
            this.sifraTextBox.TabIndex = 7;
            this.sifraTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sifraTextBox_KeyDown);
            // 
            // nazivProizvodaTextBox
            // 
            this.nazivProizvodaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nazivProizvodaTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.nazivProizvodaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nazivProizvodaTextBox.Location = new System.Drawing.Point(215, 140);
            this.nazivProizvodaTextBox.Name = "nazivProizvodaTextBox";
            this.nazivProizvodaTextBox.ReadOnly = true;
            this.nazivProizvodaTextBox.Size = new System.Drawing.Size(261, 19);
            this.nazivProizvodaTextBox.TabIndex = 8;
            this.nazivProizvodaTextBox.Visible = false;
            // 
            // staraCijenaTextBox
            // 
            this.staraCijenaTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.staraCijenaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.staraCijenaTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.staraCijenaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staraCijenaTextBox.Location = new System.Drawing.Point(214, 195);
            this.staraCijenaTextBox.Name = "staraCijenaTextBox";
            this.staraCijenaTextBox.ReadOnly = true;
            this.staraCijenaTextBox.Size = new System.Drawing.Size(262, 19);
            this.staraCijenaTextBox.TabIndex = 9;
            this.staraCijenaTextBox.Visible = false;
            // 
            // datumOdDate
            // 
            this.datumOdDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datumOdDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datumOdDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumOdDate.Location = new System.Drawing.Point(210, 299);
            this.datumOdDate.Name = "datumOdDate";
            this.datumOdDate.Size = new System.Drawing.Size(263, 22);
            this.datumOdDate.TabIndex = 12;
            this.datumOdDate.Visible = false;
            // 
            // snimiPromocijuBtn
            // 
            this.snimiPromocijuBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.snimiPromocijuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.snimiPromocijuBtn.ForeColor = System.Drawing.Color.White;
            this.snimiPromocijuBtn.Location = new System.Drawing.Point(309, 394);
            this.snimiPromocijuBtn.Name = "snimiPromocijuBtn";
            this.snimiPromocijuBtn.Size = new System.Drawing.Size(141, 35);
            this.snimiPromocijuBtn.TabIndex = 44;
            this.snimiPromocijuBtn.Text = "Snimi promociju";
            this.snimiPromocijuBtn.UseVisualStyleBackColor = false;
            this.snimiPromocijuBtn.Visible = false;
            this.snimiPromocijuBtn.Click += new System.EventHandler(this.SnimiPromocijuBtn_Click);
            // 
            // NaslovLabel
            // 
            this.NaslovLabel.AutoSize = true;
            this.NaslovLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NaslovLabel.Location = new System.Drawing.Point(31, 15);
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
            this.promocijeCijenaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.promocijeCijenaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promocijeCijenaTextBox.Location = new System.Drawing.Point(212, 247);
            this.promocijeCijenaTextBox.MaxLength = 15;
            this.promocijeCijenaTextBox.Name = "promocijeCijenaTextBox";
            this.promocijeCijenaTextBox.Size = new System.Drawing.Size(262, 26);
            this.promocijeCijenaTextBox.TabIndex = 10;
            this.promocijeCijenaTextBox.Visible = false;
            this.promocijeCijenaTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.promocijeCijenaTextBox_Validating);
            // 
            // promotivnaLabel
            // 
            this.promotivnaLabel.AutoSize = true;
            this.promotivnaLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promotivnaLabel.Location = new System.Drawing.Point(32, 249);
            this.promotivnaLabel.Name = "promotivnaLabel";
            this.promotivnaLabel.Size = new System.Drawing.Size(146, 19);
            this.promotivnaLabel.TabIndex = 3;
            this.promotivnaLabel.Text = "Promotivna cijena";
            this.promotivnaLabel.Visible = false;
            // 
            // searchArtikal
            // 
            this.searchArtikal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.searchArtikal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.searchArtikal.ForeColor = System.Drawing.Color.White;
            this.searchArtikal.Location = new System.Drawing.Point(576, 78);
            this.searchArtikal.Name = "searchArtikal";
            this.searchArtikal.Size = new System.Drawing.Size(141, 35);
            this.searchArtikal.TabIndex = 60;
            this.searchArtikal.Text = "Trazi proizvod";
            this.searchArtikal.UseVisualStyleBackColor = false;
            this.searchArtikal.Click += new System.EventHandler(this.SearchArtikal_Click);
            // 
            // datumDoDate
            // 
            this.datumDoDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datumDoDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datumDoDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumDoDate.Location = new System.Drawing.Point(212, 344);
            this.datumDoDate.Name = "datumDoDate";
            this.datumDoDate.Size = new System.Drawing.Size(262, 22);
            this.datumDoDate.TabIndex = 62;
            this.datumDoDate.Visible = false;
            // 
            // datumDoLabel
            // 
            this.datumDoLabel.AutoSize = true;
            this.datumDoLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datumDoLabel.Location = new System.Drawing.Point(35, 347);
            this.datumDoLabel.Name = "datumDoLabel";
            this.datumDoLabel.Size = new System.Drawing.Size(120, 19);
            this.datumDoLabel.TabIndex = 61;
            this.datumDoLabel.Text = "Kraj promocije";
            this.datumDoLabel.Visible = false;
            // 
            // slikaArtiklaPromocija
            // 
            this.slikaArtiklaPromocija.Location = new System.Drawing.Point(537, 133);
            this.slikaArtiklaPromocija.Name = "slikaArtiklaPromocija";
            this.slikaArtiklaPromocija.Size = new System.Drawing.Size(227, 233);
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
            this.Load += new System.EventHandler(this.Promocija_Load);
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
