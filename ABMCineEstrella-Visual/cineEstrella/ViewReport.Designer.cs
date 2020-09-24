namespace cineEstrella
{
    partial class ViewReport
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
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnImpriFiltro = new System.Windows.Forms.Button();
            this.cboClasi = new System.Windows.Forms.ComboBox();
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.cboVersion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReportePeliculas1 = new cineEstrella.ReportePeliculas();
            this.gboFiltroID = new System.Windows.Forms.GroupBox();
            this.rbtHabilitarID = new System.Windows.Forms.RadioButton();
            this.rbtHabilitarTxt = new System.Windows.Forms.RadioButton();
            this.gboFiltrotxt = new System.Windows.Forms.GroupBox();
            this.btnImprimirFiltro = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.ckbDuracion = new System.Windows.Forms.CheckBox();
            this.ckbMes = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDurHasta = new System.Windows.Forms.TextBox();
            this.txtDurDesde = new System.Windows.Forms.TextBox();
            this.txtMesHasta = new System.Windows.Forms.TextBox();
            this.txtMesDesde = new System.Windows.Forms.TextBox();
            this.txtPeliculas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gboFiltroID.SuspendLayout();
            this.gboFiltrotxt.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(12, 602);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(111, 35);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnImpriFiltro
            // 
            this.btnImpriFiltro.Location = new System.Drawing.Point(123, 182);
            this.btnImpriFiltro.Name = "btnImpriFiltro";
            this.btnImpriFiltro.Size = new System.Drawing.Size(153, 35);
            this.btnImpriFiltro.TabIndex = 3;
            this.btnImpriFiltro.Text = "Imprimir Filtro";
            this.btnImpriFiltro.UseVisualStyleBackColor = true;
            this.btnImpriFiltro.Click += new System.EventHandler(this.btnImpriFiltro_Click);
            // 
            // cboClasi
            // 
            this.cboClasi.FormattingEnabled = true;
            this.cboClasi.Location = new System.Drawing.Point(178, 34);
            this.cboClasi.Name = "cboClasi";
            this.cboClasi.Size = new System.Drawing.Size(121, 24);
            this.cboClasi.TabIndex = 4;
            // 
            // cboGenero
            // 
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Location = new System.Drawing.Point(178, 127);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(121, 24);
            this.cboGenero.TabIndex = 5;
            // 
            // cboVersion
            // 
            this.cboVersion.FormattingEnabled = true;
            this.cboVersion.Location = new System.Drawing.Point(178, 78);
            this.cboVersion.Name = "cboVersion";
            this.cboVersion.Size = new System.Drawing.Size(253, 24);
            this.cboVersion.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Clasificaciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Generos Pelicuas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Versiones";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1381, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 12);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.ReportePeliculas1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1357, 515);
            this.crystalReportViewer1.TabIndex = 11;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // gboFiltroID
            // 
            this.gboFiltroID.Controls.Add(this.cboVersion);
            this.gboFiltroID.Controls.Add(this.btnImpriFiltro);
            this.gboFiltroID.Controls.Add(this.label3);
            this.gboFiltroID.Controls.Add(this.cboClasi);
            this.gboFiltroID.Controls.Add(this.cboGenero);
            this.gboFiltroID.Controls.Add(this.label1);
            this.gboFiltroID.Controls.Add(this.label2);
            this.gboFiltroID.Location = new System.Drawing.Point(158, 585);
            this.gboFiltroID.Name = "gboFiltroID";
            this.gboFiltroID.Size = new System.Drawing.Size(436, 251);
            this.gboFiltroID.TabIndex = 12;
            this.gboFiltroID.TabStop = false;
            this.gboFiltroID.Text = "Filtros por id";
            // 
            // rbtHabilitarID
            // 
            this.rbtHabilitarID.AutoSize = true;
            this.rbtHabilitarID.Location = new System.Drawing.Point(258, 551);
            this.rbtHabilitarID.Name = "rbtHabilitarID";
            this.rbtHabilitarID.Size = new System.Drawing.Size(159, 21);
            this.rbtHabilitarID.TabIndex = 13;
            this.rbtHabilitarID.TabStop = true;
            this.rbtHabilitarID.Text = "Habilitar filtros por id";
            this.rbtHabilitarID.UseVisualStyleBackColor = true;
            this.rbtHabilitarID.CheckedChanged += new System.EventHandler(this.rbtHabilitarID_CheckedChanged);
            // 
            // rbtHabilitarTxt
            // 
            this.rbtHabilitarTxt.AutoSize = true;
            this.rbtHabilitarTxt.Location = new System.Drawing.Point(780, 552);
            this.rbtHabilitarTxt.Name = "rbtHabilitarTxt";
            this.rbtHabilitarTxt.Size = new System.Drawing.Size(178, 21);
            this.rbtHabilitarTxt.TabIndex = 14;
            this.rbtHabilitarTxt.TabStop = true;
            this.rbtHabilitarTxt.Text = "Habilitar filtros por texto";
            this.rbtHabilitarTxt.UseVisualStyleBackColor = true;
            this.rbtHabilitarTxt.CheckedChanged += new System.EventHandler(this.rbtHabilitarTxt_CheckedChanged);
            // 
            // gboFiltrotxt
            // 
            this.gboFiltrotxt.Controls.Add(this.btnImprimirFiltro);
            this.gboFiltrotxt.Controls.Add(this.label11);
            this.gboFiltrotxt.Controls.Add(this.ckbDuracion);
            this.gboFiltrotxt.Controls.Add(this.ckbMes);
            this.gboFiltrotxt.Controls.Add(this.label10);
            this.gboFiltrotxt.Controls.Add(this.label9);
            this.gboFiltrotxt.Controls.Add(this.label7);
            this.gboFiltrotxt.Controls.Add(this.label8);
            this.gboFiltrotxt.Controls.Add(this.txtDurHasta);
            this.gboFiltrotxt.Controls.Add(this.txtDurDesde);
            this.gboFiltrotxt.Controls.Add(this.txtMesHasta);
            this.gboFiltrotxt.Controls.Add(this.txtMesDesde);
            this.gboFiltrotxt.Controls.Add(this.txtPeliculas);
            this.gboFiltrotxt.Controls.Add(this.label6);
            this.gboFiltrotxt.Controls.Add(this.label5);
            this.gboFiltrotxt.Controls.Add(this.label4);
            this.gboFiltrotxt.Location = new System.Drawing.Point(668, 585);
            this.gboFiltrotxt.Name = "gboFiltrotxt";
            this.gboFiltrotxt.Size = new System.Drawing.Size(701, 251);
            this.gboFiltrotxt.TabIndex = 15;
            this.gboFiltrotxt.TabStop = false;
            this.gboFiltrotxt.Text = "Filtros por texto";
            // 
            // btnImprimirFiltro
            // 
            this.btnImprimirFiltro.Location = new System.Drawing.Point(238, 210);
            this.btnImprimirFiltro.Name = "btnImprimirFiltro";
            this.btnImprimirFiltro.Size = new System.Drawing.Size(153, 35);
            this.btnImprimirFiltro.TabIndex = 10;
            this.btnImprimirFiltro.Text = "Imprimir Filtro";
            this.btnImprimirFiltro.UseVisualStyleBackColor = true;
            this.btnImprimirFiltro.Click += new System.EventHandler(this.btnImprimirFiltro_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(206, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Boton para rango de busqueda";
            // 
            // ckbDuracion
            // 
            this.ckbDuracion.AutoSize = true;
            this.ckbDuracion.Location = new System.Drawing.Point(155, 165);
            this.ckbDuracion.Name = "ckbDuracion";
            this.ckbDuracion.Size = new System.Drawing.Size(18, 17);
            this.ckbDuracion.TabIndex = 14;
            this.ckbDuracion.UseVisualStyleBackColor = true;
            this.ckbDuracion.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // ckbMes
            // 
            this.ckbMes.AutoSize = true;
            this.ckbMes.Location = new System.Drawing.Point(155, 112);
            this.ckbMes.Name = "ckbMes";
            this.ckbMes.Size = new System.Drawing.Size(18, 17);
            this.ckbMes.TabIndex = 13;
            this.ckbMes.UseVisualStyleBackColor = true;
            this.ckbMes.CheckedChanged += new System.EventHandler(this.ckbMes_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(418, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "hasta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(226, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "desde";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "desde";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(418, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "hasta";
            // 
            // txtDurHasta
            // 
            this.txtDurHasta.Location = new System.Drawing.Point(479, 162);
            this.txtDurHasta.Name = "txtDurHasta";
            this.txtDurHasta.Size = new System.Drawing.Size(100, 22);
            this.txtDurHasta.TabIndex = 7;
            // 
            // txtDurDesde
            // 
            this.txtDurDesde.Location = new System.Drawing.Point(297, 160);
            this.txtDurDesde.Name = "txtDurDesde";
            this.txtDurDesde.Size = new System.Drawing.Size(105, 22);
            this.txtDurDesde.TabIndex = 6;
            // 
            // txtMesHasta
            // 
            this.txtMesHasta.Location = new System.Drawing.Point(479, 105);
            this.txtMesHasta.Name = "txtMesHasta";
            this.txtMesHasta.Size = new System.Drawing.Size(100, 22);
            this.txtMesHasta.TabIndex = 5;
            // 
            // txtMesDesde
            // 
            this.txtMesDesde.Location = new System.Drawing.Point(297, 105);
            this.txtMesDesde.Name = "txtMesDesde";
            this.txtMesDesde.Size = new System.Drawing.Size(105, 22);
            this.txtMesDesde.TabIndex = 4;
            // 
            // txtPeliculas
            // 
            this.txtPeliculas.Location = new System.Drawing.Point(131, 30);
            this.txtPeliculas.Name = "txtPeliculas";
            this.txtPeliculas.Size = new System.Drawing.Size(208, 22);
            this.txtPeliculas.TabIndex = 3;
            this.txtPeliculas.TextChanged += new System.EventHandler(this.txtPeliculas_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Duracion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Dia Estreno:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pelicula:";
            // 
            // ViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 860);
            this.Controls.Add(this.gboFiltrotxt);
            this.Controls.Add(this.rbtHabilitarTxt);
            this.Controls.Add(this.rbtHabilitarID);
            this.Controls.Add(this.gboFiltroID);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ViewReport";
            this.Text = "ViewReport";
            this.Load += new System.EventHandler(this.ViewReport_Load);
            this.gboFiltroID.ResumeLayout(false);
            this.gboFiltroID.PerformLayout();
            this.gboFiltrotxt.ResumeLayout(false);
            this.gboFiltrotxt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnImpriFiltro;
        private System.Windows.Forms.ComboBox cboClasi;
        private System.Windows.Forms.ComboBox cboGenero;
        private System.Windows.Forms.ComboBox cboVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private ReportePeliculas ReportePeliculas1;
        private System.Windows.Forms.GroupBox gboFiltroID;
        private System.Windows.Forms.RadioButton rbtHabilitarID;
        private System.Windows.Forms.RadioButton rbtHabilitarTxt;
        private System.Windows.Forms.GroupBox gboFiltrotxt;
        private System.Windows.Forms.CheckBox ckbDuracion;
        private System.Windows.Forms.CheckBox ckbMes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDurHasta;
        private System.Windows.Forms.TextBox txtDurDesde;
        private System.Windows.Forms.TextBox txtPeliculas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnImprimirFiltro;
        private System.Windows.Forms.TextBox txtMesHasta;
        private System.Windows.Forms.TextBox txtMesDesde;
    }
}