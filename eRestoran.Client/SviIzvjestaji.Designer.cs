namespace eRestoran.Client
{
    partial class SviIzvjestaji
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
            this.izvjestajiDataGrid = new System.Windows.Forms.DataGridView();
            this.unostextbox = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxOpen = new System.Windows.Forms.CheckBox();
            this.backButton1 = new eRestoran.Client.BackButton();
            ((System.ComponentModel.ISupportInitialize)(this.izvjestajiDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // izvjestajiDataGrid
            // 
            this.izvjestajiDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.izvjestajiDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.izvjestajiDataGrid.ColumnHeadersHeight = 22;
            this.izvjestajiDataGrid.Location = new System.Drawing.Point(66, 115);
            this.izvjestajiDataGrid.Name = "izvjestajiDataGrid";
            this.izvjestajiDataGrid.RowTemplate.Height = 30;
            this.izvjestajiDataGrid.Size = new System.Drawing.Size(621, 289);
            this.izvjestajiDataGrid.TabIndex = 0;
            // 
            // unostextbox
            // 
            this.unostextbox.AutoSize = true;
            this.unostextbox.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unostextbox.Location = new System.Drawing.Point(192, 47);
            this.unostextbox.Name = "unostextbox";
            this.unostextbox.Size = new System.Drawing.Size(156, 29);
            this.unostextbox.TabIndex = 18;
            this.unostextbox.Text = "Svi izvještaji";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(574, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 28);
            this.button1.TabIndex = 20;
            this.button1.Text = "EXPORT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbxOpen
            // 
            this.cbxOpen.AutoSize = true;
            this.cbxOpen.BackColor = System.Drawing.Color.Transparent;
            this.cbxOpen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOpen.ForeColor = System.Drawing.Color.Black;
            this.cbxOpen.Location = new System.Drawing.Point(526, 31);
            this.cbxOpen.Name = "cbxOpen";
            this.cbxOpen.Size = new System.Drawing.Size(178, 25);
            this.cbxOpen.TabIndex = 21;
            this.cbxOpen.Text = "Otvori poslije exporta";
            this.cbxOpen.UseVisualStyleBackColor = false;
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(83, 50);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(62, 29);
            this.backButton1.TabIndex = 19;
            // 
            // SviIzvjestaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxOpen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.backButton1);
            this.Controls.Add(this.unostextbox);
            this.Controls.Add(this.izvjestajiDataGrid);
            this.Name = "SviIzvjestaji";
            this.Size = new System.Drawing.Size(794, 447);
            ((System.ComponentModel.ISupportInitialize)(this.izvjestajiDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView izvjestajiDataGrid;
        private System.Windows.Forms.Label unostextbox;
        private BackButton backButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbxOpen;
    }
}
