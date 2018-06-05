namespace eRestoran.Client
{
    partial class ZaradeByDate
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
            this.zaradaTextLabel = new System.Windows.Forms.Label();
            this.backButton1 = new eRestoran.Client.BackButton();
            this.dnevneByDatedataGridView = new System.Windows.Forms.DataGridView();
            this.cbxOpen = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.datumIzvjestaj = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dnevneByDatedataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // zaradaTextLabel
            // 
            this.zaradaTextLabel.AutoSize = true;
            this.zaradaTextLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zaradaTextLabel.Location = new System.Drawing.Point(149, 36);
            this.zaradaTextLabel.Name = "zaradaTextLabel";
            this.zaradaTextLabel.Size = new System.Drawing.Size(312, 29);
            this.zaradaTextLabel.TabIndex = 20;
            this.zaradaTextLabel.Text = "Dnevne zarade po datumu";
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(72, 39);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(62, 29);
            this.backButton1.TabIndex = 21;
            // 
            // dnevneByDatedataGridView
            // 
            this.dnevneByDatedataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dnevneByDatedataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dnevneByDatedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dnevneByDatedataGridView.Location = new System.Drawing.Point(61, 104);
            this.dnevneByDatedataGridView.Name = "dnevneByDatedataGridView";
            this.dnevneByDatedataGridView.Size = new System.Drawing.Size(621, 289);
            this.dnevneByDatedataGridView.TabIndex = 22;
            // 
            // cbxOpen
            // 
            this.cbxOpen.AutoSize = true;
            this.cbxOpen.BackColor = System.Drawing.Color.Transparent;
            this.cbxOpen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOpen.ForeColor = System.Drawing.Color.Black;
            this.cbxOpen.Location = new System.Drawing.Point(586, 3);
            this.cbxOpen.Name = "cbxOpen";
            this.cbxOpen.Size = new System.Drawing.Size(178, 25);
            this.cbxOpen.TabIndex = 27;
            this.cbxOpen.Text = "Otvori poslije exporta";
            this.cbxOpen.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(648, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 28);
            this.button1.TabIndex = 26;
            this.button1.Text = "EXPORT";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // datumIzvjestaj
            // 
            this.datumIzvjestaj.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.datumIzvjestaj.CustomFormat = "dd/MM/yyyy";
            this.datumIzvjestaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datumIzvjestaj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datumIzvjestaj.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.datumIzvjestaj.Location = new System.Drawing.Point(487, 41);
            this.datumIzvjestaj.MinDate = new System.DateTime(2018, 5, 30, 21, 28, 12, 884);
            this.datumIzvjestaj.Name = "datumIzvjestaj";
            this.datumIzvjestaj.Size = new System.Drawing.Size(140, 26);
            this.datumIzvjestaj.TabIndex = 25;
            this.datumIzvjestaj.ValueChanged += new System.EventHandler(this.datumChanged);
            // 
            // ZaradeByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxOpen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datumIzvjestaj);
            this.Controls.Add(this.dnevneByDatedataGridView);
            this.Controls.Add(this.backButton1);
            this.Controls.Add(this.zaradaTextLabel);
            this.Name = "ZaradeByDate";
            this.Size = new System.Drawing.Size(794, 447);
            ((System.ComponentModel.ISupportInitialize)(this.dnevneByDatedataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label zaradaTextLabel;
        private BackButton backButton1;
        private System.Windows.Forms.DataGridView dnevneByDatedataGridView;
        private System.Windows.Forms.CheckBox cbxOpen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker datumIzvjestaj;
    }
}
