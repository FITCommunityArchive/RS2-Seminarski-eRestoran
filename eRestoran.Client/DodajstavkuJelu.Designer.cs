namespace eRestoran.Client
{
    partial class DodajstavkuJelu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DodajstavkuJelu));
            this.ProizvodJelo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KolicinaJelotextBox = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProizvodJelo
            // 
            this.ProizvodJelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProizvodJelo.FormattingEnabled = true;
            this.ProizvodJelo.Location = new System.Drawing.Point(109, -1);
            this.ProizvodJelo.Name = "ProizvodJelo";
            this.ProizvodJelo.Size = new System.Drawing.Size(198, 21);
            this.ProizvodJelo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proizvod";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Količina";
            // 
            // KolicinaJelotextBox
            // 
            this.KolicinaJelotextBox.Location = new System.Drawing.Point(109, 37);
            this.KolicinaJelotextBox.Name = "KolicinaJelotextBox";
            this.KolicinaJelotextBox.Size = new System.Drawing.Size(198, 20);
            this.KolicinaJelotextBox.TabIndex = 3;
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(313, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(40, 42);
            this.button8.TabIndex = 6;
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // DodajstavkuJelu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button8);
            this.Controls.Add(this.KolicinaJelotextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProizvodJelo);
            this.Name = "DodajstavkuJelu";
            this.Size = new System.Drawing.Size(355, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProizvodJelo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KolicinaJelotextBox;
        private System.Windows.Forms.Button button8;
    }
}
