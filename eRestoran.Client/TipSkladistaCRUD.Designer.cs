namespace eRestoran.Client
{
    partial class TipSkladistaCRUD
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
            this.NazivTipPtextBox = new System.Windows.Forms.TextBox();
            this.NazivTipP = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Izbrisibutton = new System.Windows.Forms.Button();
            this.Uredibutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SkladistaDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // SkladistaDataGrid
            // 
            this.SkladistaDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SkladistaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SkladistaDataGrid.Location = new System.Drawing.Point(74, 220);
            this.SkladistaDataGrid.Name = "SkladistaDataGrid";
            this.SkladistaDataGrid.ReadOnly = true;
            this.SkladistaDataGrid.Size = new System.Drawing.Size(537, 200);
            this.SkladistaDataGrid.TabIndex = 45;
            // 
            // snimiSklPbtn
            // 
            this.snimiSklPbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.snimiSklPbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.snimiSklPbtn.ForeColor = System.Drawing.Color.White;
            this.snimiSklPbtn.Location = new System.Drawing.Point(291, 132);
            this.snimiSklPbtn.Name = "snimiSklPbtn";
            this.snimiSklPbtn.Size = new System.Drawing.Size(141, 35);
            this.snimiSklPbtn.TabIndex = 43;
            this.snimiSklPbtn.Text = "Snimi ";
            this.snimiSklPbtn.UseVisualStyleBackColor = false;
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(117, 27);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(62, 29);
            this.backButton1.TabIndex = 42;
            // 
            // unostextbox
            // 
            this.unostextbox.AutoSize = true;
            this.unostextbox.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unostextbox.Location = new System.Drawing.Point(217, 27);
            this.unostextbox.Name = "unostextbox";
            this.unostextbox.Size = new System.Drawing.Size(182, 24);
            this.unostextbox.TabIndex = 41;
            this.unostextbox.Text = "Novi tip skladišta";
            // 
            // NazivTipPtextBox
            // 
            this.NazivTipPtextBox.Location = new System.Drawing.Point(261, 80);
            this.NazivTipPtextBox.Name = "NazivTipPtextBox";
            this.NazivTipPtextBox.Size = new System.Drawing.Size(196, 20);
            this.NazivTipPtextBox.TabIndex = 40;
            // 
            // NazivTipP
            // 
            this.NazivTipP.AutoSize = true;
            this.NazivTipP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NazivTipP.Location = new System.Drawing.Point(115, 84);
            this.NazivTipP.Name = "NazivTipP";
            this.NazivTipP.Size = new System.Drawing.Size(102, 16);
            this.NazivTipP.TabIndex = 38;
            this.NazivTipP.Text = "Naziv skladišta";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Izbrisibutton
            // 
            this.Izbrisibutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.Izbrisibutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Izbrisibutton.ForeColor = System.Drawing.Color.White;
            this.Izbrisibutton.Location = new System.Drawing.Point(648, 268);
            this.Izbrisibutton.Name = "Izbrisibutton";
            this.Izbrisibutton.Size = new System.Drawing.Size(72, 35);
            this.Izbrisibutton.TabIndex = 47;
            this.Izbrisibutton.Text = "Izbriši";
            this.Izbrisibutton.UseVisualStyleBackColor = false;
            // 
            // Uredibutton
            // 
            this.Uredibutton.BackColor = System.Drawing.Color.Silver;
            this.Uredibutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Uredibutton.ForeColor = System.Drawing.Color.White;
            this.Uredibutton.Location = new System.Drawing.Point(648, 220);
            this.Uredibutton.Name = "Uredibutton";
            this.Uredibutton.Size = new System.Drawing.Size(72, 35);
            this.Uredibutton.TabIndex = 46;
            this.Uredibutton.Text = "Uredi";
            this.Uredibutton.UseVisualStyleBackColor = false;
            // 
            // TipSkladistaCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SkladistaDataGrid);
            this.Controls.Add(this.snimiSklPbtn);
            this.Controls.Add(this.backButton1);
            this.Controls.Add(this.unostextbox);
            this.Controls.Add(this.NazivTipPtextBox);
            this.Controls.Add(this.NazivTipP);
            this.Controls.Add(this.Izbrisibutton);
            this.Controls.Add(this.Uredibutton);
            this.Name = "TipSkladistaCRUD";
            this.Size = new System.Drawing.Size(794, 447);
            ((System.ComponentModel.ISupportInitialize)(this.SkladistaDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SkladistaDataGrid;
        private System.Windows.Forms.Button snimiSklPbtn;
        private BackButton backButton1;
        private System.Windows.Forms.Label unostextbox;
        private System.Windows.Forms.TextBox NazivTipPtextBox;
        private System.Windows.Forms.Label NazivTipP;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button Izbrisibutton;
        private System.Windows.Forms.Button Uredibutton;
    }
}
