using FirstUserControlUsage;

namespace FastFoodDemo
{
    partial class UnosJela
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
            this.label6 = new System.Windows.Forms.Label();
            this.NazivJelatextBox = new System.Windows.Forms.TextBox();
            this.CijenaJelatextBox = new System.Windows.Forms.TextBox();
            this.SifraJelatextBox = new System.Windows.Forms.TextBox();
            this.unostextbox = new System.Windows.Forms.Label();
            this.MenuJelacomboBox = new System.Windows.Forms.ComboBox();
            this.snimiProizvodbtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.ProizvodpictureBox = new System.Windows.Forms.PictureBox();
            this.dodajSlikubutton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dodajStavkuLink = new System.Windows.Forms.LinkLabel();
            this.backButton1 = new eRestoran.Client.BackButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProizvodpictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(44, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv jela";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(43, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cijena jela";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(43, 177);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Šifra jela";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(43, 218);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "U koji menu spada?";
            // 
            // NazivJelatextBox
            // 
            this.NazivJelatextBox.Location = new System.Drawing.Point(239, 97);
            this.NazivJelatextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NazivJelatextBox.Name = "NazivJelatextBox";
            this.NazivJelatextBox.Size = new System.Drawing.Size(260, 22);
            this.NazivJelatextBox.TabIndex = 8;
            this.NazivJelatextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NazivtextBox_Validating);
            // 
            // CijenaJelatextBox
            // 
            this.CijenaJelatextBox.Location = new System.Drawing.Point(239, 144);
            this.CijenaJelatextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CijenaJelatextBox.Name = "CijenaJelatextBox";
            this.CijenaJelatextBox.Size = new System.Drawing.Size(260, 22);
            this.CijenaJelatextBox.TabIndex = 9;
            this.CijenaJelatextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CijenatextBox_Validating);
            // 
            // SifraJelatextBox
            // 
            this.SifraJelatextBox.Location = new System.Drawing.Point(239, 177);
            this.SifraJelatextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SifraJelatextBox.Name = "SifraJelatextBox";
            this.SifraJelatextBox.Size = new System.Drawing.Size(260, 22);
            this.SifraJelatextBox.TabIndex = 11;
            this.SifraJelatextBox.Validating += new System.ComponentModel.CancelEventHandler(this.SifratextBox_Validating);
            // 
            // unostextbox
            // 
            this.unostextbox.AutoSize = true;
            this.unostextbox.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unostextbox.Location = new System.Drawing.Point(180, 32);
            this.unostextbox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.unostextbox.Name = "unostextbox";
            this.unostextbox.Size = new System.Drawing.Size(102, 24);
            this.unostextbox.TabIndex = 17;
            this.unostextbox.Text = "Unos jela";
            // 
            // MenuJelacomboBox
            // 
            this.MenuJelacomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MenuJelacomboBox.FormattingEnabled = true;
            this.MenuJelacomboBox.Location = new System.Drawing.Point(239, 218);
            this.MenuJelacomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MenuJelacomboBox.Name = "MenuJelacomboBox";
            this.MenuJelacomboBox.Size = new System.Drawing.Size(260, 24);
            this.MenuJelacomboBox.TabIndex = 20;
            this.MenuJelacomboBox.Validating += new System.ComponentModel.CancelEventHandler(this.MenucomboBox_Validating);
            // 
            // snimiProizvodbtn
            // 
            this.snimiProizvodbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.snimiProizvodbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.snimiProizvodbtn.ForeColor = System.Drawing.Color.White;
            this.snimiProizvodbtn.Location = new System.Drawing.Point(296, 325);
            this.snimiProizvodbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.snimiProizvodbtn.Name = "snimiProizvodbtn";
            this.snimiProizvodbtn.Size = new System.Drawing.Size(150, 36);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(616, 49);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 19);
            this.label9.TabIndex = 23;
            this.label9.Text = "Slika";
            // 
            // ProizvodpictureBox
            // 
            this.ProizvodpictureBox.Location = new System.Drawing.Point(553, 97);
            this.ProizvodpictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProizvodpictureBox.Name = "ProizvodpictureBox";
            this.ProizvodpictureBox.Size = new System.Drawing.Size(162, 140);
            this.ProizvodpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProizvodpictureBox.TabIndex = 24;
            this.ProizvodpictureBox.TabStop = false;
            // 
            // dodajSlikubutton
            // 
            this.dodajSlikubutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.dodajSlikubutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.dodajSlikubutton.ForeColor = System.Drawing.Color.White;
            this.dodajSlikubutton.Location = new System.Drawing.Point(572, 265);
            this.dodajSlikubutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dodajSlikubutton.Name = "dodajSlikubutton";
            this.dodajSlikubutton.Size = new System.Drawing.Size(132, 41);
            this.dodajSlikubutton.TabIndex = 25;
            this.dodajSlikubutton.Text = "Učitaj sliku";
            this.dodajSlikubutton.UseVisualStyleBackColor = false;
            this.dodajSlikubutton.Click += new System.EventHandler(this.dodajSlikubutton_Click);
            // 
            // dodajStavkuLink
            // 
            this.dodajStavkuLink.AutoSize = true;
            this.dodajStavkuLink.Location = new System.Drawing.Point(400, 277);
            this.dodajStavkuLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dodajStavkuLink.Name = "dodajStavkuLink";
            this.dodajStavkuLink.Size = new System.Drawing.Size(99, 16);
            this.dodajStavkuLink.TabIndex = 27;
            this.dodajStavkuLink.TabStop = true;
            this.dodajStavkuLink.Text = "Dodaj sastojak";
            this.dodajStavkuLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dodajStavkuLink_LinkClicked);
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(47, 32);
            this.backButton1.Margin = new System.Windows.Forms.Padding(4);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(83, 36);
            this.backButton1.TabIndex = 26;
            // 
            // UnosJela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.dodajStavkuLink);
            this.Controls.Add(this.backButton1);
            this.Controls.Add(this.dodajSlikubutton);
            this.Controls.Add(this.ProizvodpictureBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.snimiProizvodbtn);
            this.Controls.Add(this.MenuJelacomboBox);
            this.Controls.Add(this.unostextbox);
            this.Controls.Add(this.SifraJelatextBox);
            this.Controls.Add(this.CijenaJelatextBox);
            this.Controls.Add(this.NazivJelatextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UnosJela";
            this.Size = new System.Drawing.Size(754, 452);
            this.Load += new System.EventHandler(this.UnosProizvoda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProizvodpictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NazivJelatextBox;
        private System.Windows.Forms.TextBox CijenaJelatextBox;
        private System.Windows.Forms.TextBox SifraJelatextBox;
        private System.Windows.Forms.Label unostextbox;
        private System.Windows.Forms.ComboBox MenuJelacomboBox;
        private System.Windows.Forms.Button snimiProizvodbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button dodajSlikubutton;
        private System.Windows.Forms.PictureBox ProizvodpictureBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private eRestoran.Client.BackButton backButton1;
        private System.Windows.Forms.LinkLabel dodajStavkuLink;
    }
}
