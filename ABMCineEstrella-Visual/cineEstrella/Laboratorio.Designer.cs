namespace cineEstrella
{
    partial class Laboratorio
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
            this.btnParametro = new System.Windows.Forms.Button();
            this.btnFijas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnParametro
            // 
            this.btnParametro.BackColor = System.Drawing.Color.Transparent;
            this.btnParametro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParametro.Location = new System.Drawing.Point(80, 225);
            this.btnParametro.Margin = new System.Windows.Forms.Padding(4);
            this.btnParametro.Name = "btnParametro";
            this.btnParametro.Size = new System.Drawing.Size(424, 93);
            this.btnParametro.TabIndex = 0;
            this.btnParametro.Text = "Consultas con Parametros";
            this.btnParametro.UseVisualStyleBackColor = false;
            this.btnParametro.Click += new System.EventHandler(this.btnParametro_Click);
            // 
            // btnFijas
            // 
            this.btnFijas.BackColor = System.Drawing.Color.Transparent;
            this.btnFijas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFijas.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFijas.Location = new System.Drawing.Point(584, 225);
            this.btnFijas.Margin = new System.Windows.Forms.Padding(4);
            this.btnFijas.Name = "btnFijas";
            this.btnFijas.Size = new System.Drawing.Size(424, 93);
            this.btnFijas.TabIndex = 1;
            this.btnFijas.Text = "Consultas Fijas";
            this.btnFijas.UseVisualStyleBackColor = false;
            this.btnFijas.Click += new System.EventHandler(this.btnFijas_Click);
            // 
            // Laboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cineEstrella.Properties.Resources.IMAGEN_FORM;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnFijas);
            this.Controls.Add(this.btnParametro);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Laboratorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laboratorio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnParametro;
        private System.Windows.Forms.Button btnFijas;
    }
}