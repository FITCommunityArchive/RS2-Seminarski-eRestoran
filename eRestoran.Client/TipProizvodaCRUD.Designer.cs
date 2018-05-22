namespace eRestoran.Client
{
    partial class TipProizvodaCRUD
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
            this.backButton1 = new eRestoran.Client.BackButton();
            this.unostextbox = new System.Windows.Forms.Label();
            this.NazivTipPtextBox = new System.Windows.Forms.TextBox();
            this.MjernaJ = new System.Windows.Forms.Label();
            this.NazivTipP = new System.Windows.Forms.Label();
            this.snimiTipPbtn = new System.Windows.Forms.Button();
            this.MjernaJcomboBox = new System.Windows.Forms.ComboBox();
            this.TipoviDataGrid = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Uredibutton = new System.Windows.Forms.Button();
            this.Izbrisibutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TipoviDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(133, 21);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(62, 29);
            this.backButton1.TabIndex = 32;
            // 
            // unostextbox
            // 
            this.unostextbox.AutoSize = true;
            this.unostextbox.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unostextbox.Location = new System.Drawing.Point(233, 21);
            this.unostextbox.Name = "unostextbox";
            this.unostextbox.Size = new System.Drawing.Size(193, 24);
            this.unostextbox.TabIndex = 31;
            this.unostextbox.Text = "Novi tip proizvoda";
            // 
            // NazivTipPtextBox
            // 
            this.NazivTipPtextBox.Location = new System.Drawing.Point(277, 74);
            this.NazivTipPtextBox.Name = "NazivTipPtextBox";
            this.NazivTipPtextBox.Size = new System.Drawing.Size(196, 20);
            this.NazivTipPtextBox.TabIndex = 29;
            this.NazivTipPtextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NazivTipPtextBox_Validating);
            // 
            // MjernaJ
            // 
            this.MjernaJ.AutoSize = true;
            this.MjernaJ.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MjernaJ.Location = new System.Drawing.Point(130, 111);
            this.MjernaJ.Name = "MjernaJ";
            this.MjernaJ.Size = new System.Drawing.Size(111, 16);
            this.MjernaJ.TabIndex = 28;
            this.MjernaJ.Text = "Mjerna jedinica ";
            // 
            // NazivTipP
            // 
            this.NazivTipP.AutoSize = true;
            this.NazivTipP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NazivTipP.Location = new System.Drawing.Point(131, 78);
            this.NazivTipP.Name = "NazivTipP";
            this.NazivTipP.Size = new System.Drawing.Size(138, 16);
            this.NazivTipP.TabIndex = 27;
            this.NazivTipP.Text = "Naziv tipa proizvoda";
            // 
            // snimiTipPbtn
            // 
            this.snimiTipPbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.snimiTipPbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.snimiTipPbtn.ForeColor = System.Drawing.Color.White;
            this.snimiTipPbtn.Location = new System.Drawing.Point(298, 146);
            this.snimiTipPbtn.Name = "snimiTipPbtn";
            this.snimiTipPbtn.Size = new System.Drawing.Size(141, 35);
            this.snimiTipPbtn.TabIndex = 33;
            this.snimiTipPbtn.Text = "Snimi ";
            this.snimiTipPbtn.UseVisualStyleBackColor = false;
            this.snimiTipPbtn.Click += new System.EventHandler(this.snimiTipPbtn_Click);
            // 
            // MjernaJcomboBox
            // 
            this.MjernaJcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MjernaJcomboBox.FormattingEnabled = true;
            this.MjernaJcomboBox.Location = new System.Drawing.Point(277, 105);
            this.MjernaJcomboBox.Name = "MjernaJcomboBox";
            this.MjernaJcomboBox.Size = new System.Drawing.Size(196, 21);
            this.MjernaJcomboBox.TabIndex = 34;
            this.MjernaJcomboBox.Validating += new System.ComponentModel.CancelEventHandler(this.MjernaJcomboBox_Validating);
            // 
            // TipoviDataGrid
            // 
            this.TipoviDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TipoviDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TipoviDataGrid.Location = new System.Drawing.Point(90, 214);
            this.TipoviDataGrid.Name = "TipoviDataGrid";
            this.TipoviDataGrid.ReadOnly = true;
            this.TipoviDataGrid.Size = new System.Drawing.Size(537, 200);
            this.TipoviDataGrid.TabIndex = 35;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Uredibutton
            // 
            this.Uredibutton.BackColor = System.Drawing.Color.Silver;
            this.Uredibutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Uredibutton.ForeColor = System.Drawing.Color.White;
            this.Uredibutton.Location = new System.Drawing.Point(664, 214);
            this.Uredibutton.Name = "Uredibutton";
            this.Uredibutton.Size = new System.Drawing.Size(72, 35);
            this.Uredibutton.TabIndex = 36;
            this.Uredibutton.Text = "Uredi";
            this.Uredibutton.UseVisualStyleBackColor = false;
            this.Uredibutton.Click += new System.EventHandler(this.Uredibutton_Click);
            // 
            // Izbrisibutton
            // 
            this.Izbrisibutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.Izbrisibutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Izbrisibutton.ForeColor = System.Drawing.Color.White;
            this.Izbrisibutton.Location = new System.Drawing.Point(664, 262);
            this.Izbrisibutton.Name = "Izbrisibutton";
            this.Izbrisibutton.Size = new System.Drawing.Size(72, 35);
            this.Izbrisibutton.TabIndex = 37;
            this.Izbrisibutton.Text = "Izbriši";
            this.Izbrisibutton.UseVisualStyleBackColor = false;
            this.Izbrisibutton.Click += new System.EventHandler(this.Izbrisibutton_Click);
            // 
            // TipProizvodaDodaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Izbrisibutton);
            this.Controls.Add(this.Uredibutton);
            this.Controls.Add(this.TipoviDataGrid);
            this.Controls.Add(this.MjernaJcomboBox);
            this.Controls.Add(this.snimiTipPbtn);
            this.Controls.Add(this.backButton1);
            this.Controls.Add(this.unostextbox);
            this.Controls.Add(this.NazivTipPtextBox);
            this.Controls.Add(this.MjernaJ);
            this.Controls.Add(this.NazivTipP);
            this.Name = "TipProizvodaDodaj";
            this.Size = new System.Drawing.Size(794, 447);
            ((System.ComponentModel.ISupportInitialize)(this.TipoviDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BackButton backButton1;
        private System.Windows.Forms.Label unostextbox;
        private System.Windows.Forms.TextBox NazivTipPtextBox;
        private System.Windows.Forms.Label MjernaJ;
        private System.Windows.Forms.Label NazivTipP;
        private System.Windows.Forms.Button snimiTipPbtn;
        private System.Windows.Forms.ComboBox MjernaJcomboBox;
        private System.Windows.Forms.DataGridView TipoviDataGrid;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button Izbrisibutton;
        private System.Windows.Forms.Button Uredibutton;
    }
}
