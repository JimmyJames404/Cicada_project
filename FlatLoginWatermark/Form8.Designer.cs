namespace Jimmy
{
    partial class Form8
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbprogreso = new System.Windows.Forms.Label();
            this.pbprogreso = new System.Windows.Forms.ProgressBar();
            this.btndescargar = new System.Windows.Forms.Button();
            this.txturl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbprogreso
            // 
            this.lbprogreso.AutoSize = true;
            this.lbprogreso.Location = new System.Drawing.Point(65, 181);
            this.lbprogreso.Name = "lbprogreso";
            this.lbprogreso.Size = new System.Drawing.Size(28, 17);
            this.lbprogreso.TabIndex = 29;
            this.lbprogreso.Text = "0%";
            // 
            // pbprogreso
            // 
            this.pbprogreso.Location = new System.Drawing.Point(119, 168);
            this.pbprogreso.Name = "pbprogreso";
            this.pbprogreso.Size = new System.Drawing.Size(896, 58);
            this.pbprogreso.TabIndex = 28;
            // 
            // btndescargar
            // 
            this.btndescargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndescargar.Location = new System.Drawing.Point(890, 118);
            this.btndescargar.Name = "btndescargar";
            this.btndescargar.Size = new System.Drawing.Size(125, 34);
            this.btndescargar.TabIndex = 27;
            this.btndescargar.Text = "Descargar";
            this.btndescargar.UseVisualStyleBackColor = true;
            this.btndescargar.Click += new System.EventHandler(this.btndescargar_Click);
            // 
            // txturl
            // 
            this.txturl.Location = new System.Drawing.Point(70, 118);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(814, 22);
            this.txturl.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(145)))));
            this.label6.Location = new System.Drawing.Point(403, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(319, 40);
            this.label6.TabIndex = 48;
            this.label6.Text = "Descarga Archivos";
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 588);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbprogreso);
            this.Controls.Add(this.pbprogreso);
            this.Controls.Add(this.btndescargar);
            this.Controls.Add(this.txturl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form8";
            this.Text = "Form8";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbprogreso;
        private System.Windows.Forms.ProgressBar pbprogreso;
        private System.Windows.Forms.Button btndescargar;
        private System.Windows.Forms.TextBox txturl;
        private System.Windows.Forms.Label label6;
    }
}