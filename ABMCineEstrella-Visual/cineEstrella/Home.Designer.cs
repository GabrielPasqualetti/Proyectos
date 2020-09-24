namespace cineEstrella
{
    partial class Home
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
            this.btnLaboratorio = new System.Windows.Forms.Button();
            this.btnProgramacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReporte = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLaboratorio
            // 
            this.btnLaboratorio.BackColor = System.Drawing.Color.Transparent;
            this.btnLaboratorio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLaboratorio.Font = new System.Drawing.Font("Candara", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaboratorio.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLaboratorio.Location = new System.Drawing.Point(637, 36);
            this.btnLaboratorio.Margin = new System.Windows.Forms.Padding(4);
            this.btnLaboratorio.Name = "btnLaboratorio";
            this.btnLaboratorio.Size = new System.Drawing.Size(316, 107);
            this.btnLaboratorio.TabIndex = 0;
            this.btnLaboratorio.Text = "Laboratorio";
            this.btnLaboratorio.UseVisualStyleBackColor = false;
            this.btnLaboratorio.Click += new System.EventHandler(this.btnLaboratorio_Click);
            // 
            // btnProgramacion
            // 
            this.btnProgramacion.BackColor = System.Drawing.Color.Transparent;
            this.btnProgramacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProgramacion.Font = new System.Drawing.Font("Candara", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgramacion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProgramacion.Location = new System.Drawing.Point(176, 36);
            this.btnProgramacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnProgramacion.Name = "btnProgramacion";
            this.btnProgramacion.Size = new System.Drawing.Size(316, 107);
            this.btnProgramacion.TabIndex = 1;
            this.btnProgramacion.Text = "Programación";
            this.btnProgramacion.UseVisualStyleBackColor = false;
            this.btnProgramacion.Click += new System.EventHandler(this.btnProgramacion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Candara", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(376, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 49);
            this.label1.TabIndex = 2;
            this.label1.Text = "* CINE ESTRELLA *";
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.Transparent;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReporte.Font = new System.Drawing.Font("Candara", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReporte.Location = new System.Drawing.Point(375, 224);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(316, 107);
            this.btnReporte.TabIndex = 3;
            this.btnReporte.Text = "Reportes";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cineEstrella.Properties.Resources.MINIONS;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProgramacion);
            this.Controls.Add(this.btnLaboratorio);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLaboratorio;
        private System.Windows.Forms.Button btnProgramacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReporte;
    }
}