namespace eRestoran.Client
{
    partial class SkladisteCRUD
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
            this.SkladistaDataGrid = new System.Windows.Forms.DataGridView();
            this.snimiSklPbtn = new System.Windows.Forms.Button();
            this.backButton1 = new eRestoran.Client.BackButton();
            this.unostextbox = new System.Windows.Forms.Label();
            this.adresaSkladistaTextBox = new System.Windows.Forms.TextBox();
            this.NazivTipP = new System.Windows.Forms.Label();
            this.Izbrisibutton = new System.Windows.Forms.Button();
            this.Uredibutton = new System.Windows.Forms.Button();
            this.kvadraturaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tipSkladistaComboBox = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SkladistaDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // SkladistaDataGrid
            // 
            this.SkladistaDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SkladistaDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.SkladistaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SkladistaDataGrid.Location = new System.Drawing.Point(74, 244);
            this.SkladistaDataGrid.Name = "SkladistaDataGrid";
            this.SkladistaDataGrid.ReadOnly = true;
            this.SkladistaDataGrid.Size = new System.Drawing.Size(537, 176);
            this.SkladistaDataGrid.TabIndex = 53;
            // 
            // snimiSklPbtn
            // 
            this.snimiSklPbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.snimiSklPbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.snimiSklPbtn.ForeColor = System.Drawing.Color.White;
            this.snimiSklPbtn.Location = new System.Drawing.Point(283, 185);
            this.snimiSklPbtn.Name = "snimiSklPbtn";
            this.snimiSklPbtn.Size = new System.Drawing.Size(141, 35);
            this.snimiSklPbtn.TabIndex = 52;
            this.snimiSklPbtn.Text = "Snimi ";
            this.snimiSklPbtn.UseVisualStyleBackColor = false;
            this.snimiSklPbtn.Click += new System.EventHandler(this.snimiSklPbtn_Click);
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(117, 27);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(62, 29);
            this.backButton1.TabIndex = 51;
            // 
            // unostextbox
            // 
            this.unostextbox.AutoSize = true;
            this.unostextbox.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unostextbox.Location = new System.Drawing.Point(217, 27);
            this.unostextbox.Name = "unostextbox";
            this.unostextbox.Size = new System.Drawing.Size(159, 24);
            this.unostextbox.TabIndex = 50;
            this.unostextbox.Text = "Novo skladište";
            // 
            // adresaSkladistaTextBox
            // 
            this.adresaSkladistaTextBox.Location = new System.Drawing.Point(261, 80);
            this.adresaSkladistaTextBox.Name = "adresaSkladistaTextBox";
            this.adresaSkladistaTextBox.Size = new System.Drawing.Size(196, 20);
            this.adresaSkladistaTextBox.TabIndex = 49;
            this.adresaSkladistaTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.adresaSkladistaTextBox_Validating);
            // 
            // NazivTipP
            // 
            this.NazivTipP.AutoSize = true;
            this.NazivTipP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NazivTipP.Location = new System.Drawing.Point(115, 84);
            this.NazivTipP.Name = "NazivTipP";
            this.NazivTipP.Size = new System.Drawing.Size(111, 16);
            this.NazivTipP.TabIndex = 48;
            this.NazivTipP.Text = "Adresa skladišta";
            // 
            // Izbrisibutton
            // 
            this.Izbrisibutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.Izbrisibutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Izbrisibutton.ForeColor = System.Drawing.Color.White;
            this.Izbrisibutton.Location = new System.Drawing.Point(648, 296);
            this.Izbrisibutton.Name = "Izbrisibutton";
            this.Izbrisibutton.Size = new System.Drawing.Size(72, 35);
            this.Izbrisibutton.TabIndex = 55;
            this.Izbrisibutton.Text = "Izbriši";
            this.Izbrisibutton.UseVisualStyleBackColor = false;
            this.Izbrisibutton.Click += new System.EventHandler(this.Izbrisibutton_Click);
            // 
            // Uredibutton
            // 
            this.Uredibutton.BackColor = System.Drawing.Color.Silver;
            this.Uredibutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Uredibutton.ForeColor = System.Drawing.Color.White;
            this.Uredibutton.Location = new System.Drawing.Point(648, 244);
            this.Uredibutton.Name = "Uredibutton";
            this.Uredibutton.Size = new System.Drawing.Size(72, 35);
            this.Uredibutton.TabIndex = 54;
            this.Uredibutton.Text = "Uredi";
            this.Uredibutton.UseVisualStyleBackColor = false;
            this.Uredibutton.Click += new System.EventHandler(this.Uredibutton_Click);
            // 
            // kvadraturaTextBox
            // 
            this.kvadraturaTextBox.Location = new System.Drawing.Point(260, 112);
            this.kvadraturaTextBox.Name = "kvadraturaTextBox";
            this.kvadraturaTextBox.Size = new System.Drawing.Size(196, 20);
            this.kvadraturaTextBox.TabIndex = 57;
            this.kvadraturaTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.kvadraturaTextBox_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(114, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "Kvadratura skladišta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(114, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 58;
            this.label2.Text = "Tip skladišta";
            // 
            // tipSkladistaComboBox
            // 
            this.tipSkladistaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipSkladistaComboBox.FormattingEnabled = true;
            this.tipSkladistaComboBox.Location = new System.Drawing.Point(261, 145);
            this.tipSkladistaComboBox.Name = "tipSkladistaComboBox";
            this.tipSkladistaComboBox.Size = new System.Drawing.Size(195, 21);
            this.tipSkladistaComboBox.TabIndex = 59;
            this.tipSkladistaComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.tipSkladistaComboBox_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SkladisteCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tipSkladistaComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kvadraturaTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SkladistaDataGrid);
            this.Controls.Add(this.snimiSklPbtn);
            this.Controls.Add(this.backButton1);
            this.Controls.Add(this.unostextbox);
            this.Controls.Add(this.adresaSkladistaTextBox);
            this.Controls.Add(this.NazivTipP);
            this.Controls.Add(this.Izbrisibutton);
            this.Controls.Add(this.Uredibutton);
            this.Name = "SkladisteCRUD";
            this.Size = new System.Drawing.Size(794, 447);
            ((System.ComponentModel.ISupportInitialize)(this.SkladistaDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SkladistaDataGrid;
        private System.Windows.Forms.Button snimiSklPbtn;
        private BackButton backButton1;
        private System.Windows.Forms.Label unostextbox;
        private System.Windows.Forms.TextBox adresaSkladistaTextBox;
        private System.Windows.Forms.Label NazivTipP;
        private System.Windows.Forms.Button Izbrisibutton;
        private System.Windows.Forms.Button Uredibutton;
        private System.Windows.Forms.TextBox kvadraturaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipSkladistaComboBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
