namespace eRestoran.Client
{
    partial class NarudzbeByDate
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
            this.unostextbox = new System.Windows.Forms.Label();
            this.datumIzvjestaj = new System.Windows.Forms.DateTimePicker();
            this.dateIzvjestajidataGrid = new System.Windows.Forms.DataGridView();
            this.cbxOpen = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.backButton1 = new eRestoran.Client.BackButton();
            ((System.ComponentModel.ISupportInitialize)(this.dateIzvjestajidataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // unostextbox
            // 
            this.unostextbox.AutoSize = true;
            this.unostextbox.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unostextbox.Location = new System.Drawing.Point(150, 46);
            this.unostextbox.Name = "unostextbox";
            this.unostextbox.Size = new System.Drawing.Size(244, 29);
            this.unostextbox.TabIndex = 19;
            this.unostextbox.Text = "Izvjestaji po datumu";
            // 
            // datumIzvjestaj
            // 
            this.datumIzvjestaj.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.datumIzvjestaj.CustomFormat = "dd/MM/yyyy";
            this.datumIzvjestaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datumIzvjestaj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datumIzvjestaj.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.datumIzvjestaj.Location = new System.Drawing.Point(413, 49);
            this.datumIzvjestaj.MinDate = new System.DateTime(2018, 5, 30, 21, 28, 12, 884);
            this.datumIzvjestaj.Name = "datumIzvjestaj";
            this.datumIzvjestaj.Size = new System.Drawing.Size(200, 26);
            this.datumIzvjestaj.TabIndex = 21;
            this.datumIzvjestaj.ValueChanged += new System.EventHandler(this.datumChanged);
            // 
            // dateIzvjestajidataGrid
            // 
            this.dateIzvjestajidataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dateIzvjestajidataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dateIzvjestajidataGrid.ColumnHeadersHeight = 22;
            this.dateIzvjestajidataGrid.Location = new System.Drawing.Point(61, 117);
            this.dateIzvjestajidataGrid.Name = "dateIzvjestajidataGrid";
            this.dateIzvjestajidataGrid.RowTemplate.Height = 30;
            this.dateIzvjestajidataGrid.Size = new System.Drawing.Size(621, 289);
            this.dateIzvjestajidataGrid.TabIndex = 22;
            // 
            // cbxOpen
            // 
            this.cbxOpen.AutoSize = true;
            this.cbxOpen.BackColor = System.Drawing.Color.Transparent;
            this.cbxOpen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOpen.ForeColor = System.Drawing.Color.Black;
            this.cbxOpen.Location = new System.Drawing.Point(574, 15);
            this.cbxOpen.Name = "cbxOpen";
            this.cbxOpen.Size = new System.Drawing.Size(178, 25);
            this.cbxOpen.TabIndex = 24;
            this.cbxOpen.Text = "Otvori poslije exporta";
            this.cbxOpen.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(643, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 28);
            this.button1.TabIndex = 23;
            this.button1.Text = "EXPORT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(82, 46);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(62, 29);
            this.backButton1.TabIndex = 20;
            // 
            // NarudzbeByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxOpen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateIzvjestajidataGrid);
            this.Controls.Add(this.datumIzvjestaj);
            this.Controls.Add(this.backButton1);
            this.Controls.Add(this.unostextbox);
            this.Name = "NarudzbeByDate";
            this.Size = new System.Drawing.Size(794, 447);
            ((System.ComponentModel.ISupportInitialize)(this.dateIzvjestajidataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label unostextbox;
        private BackButton backButton1;
        private System.Windows.Forms.DateTimePicker datumIzvjestaj;
        private System.Windows.Forms.DataGridView dateIzvjestajidataGrid;
        private System.Windows.Forms.CheckBox cbxOpen;
        private System.Windows.Forms.Button button1;
    }
}
