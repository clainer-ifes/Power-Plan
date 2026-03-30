namespace PowerPlan
{
    partial class ResultsAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsAnalysis));
            this.Sair = new System.Windows.Forms.Button();
            this.comboCenario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboAno = new System.Windows.Forms.ComboBox();
            this.Exportar = new System.Windows.Forms.Button();
            this.groupBoxOpcao = new System.Windows.Forms.GroupBox();
            this.Histograma = new System.Windows.Forms.RadioButton();
            this.GraficoRede = new System.Windows.Forms.RadioButton();
            this.comboClassesHistograma = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ToleranciaLimiteX = new System.Windows.Forms.ComboBox();
            this.labelLimiteX = new System.Windows.Forms.Label();
            this.groupBoxOpcao.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sair
            // 
            this.Sair.Location = new System.Drawing.Point(315, 262);
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(132, 49);
            this.Sair.TabIndex = 7;
            this.Sair.Text = "&Close";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // comboCenario
            // 
            this.comboCenario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCenario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCenario.FormattingEnabled = true;
            this.comboCenario.Location = new System.Drawing.Point(255, 87);
            this.comboCenario.Name = "comboCenario";
            this.comboCenario.Size = new System.Drawing.Size(316, 33);
            this.comboCenario.TabIndex = 2;
            this.comboCenario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboCenario_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Scenario:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Year:";
            // 
            // comboAno
            // 
            this.comboAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAno.FormattingEnabled = true;
            this.comboAno.Location = new System.Drawing.Point(255, 126);
            this.comboAno.Name = "comboAno";
            this.comboAno.Size = new System.Drawing.Size(316, 33);
            this.comboAno.TabIndex = 3;
            this.comboAno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboAno_KeyDown);
            // 
            // Exportar
            // 
            this.Exportar.Location = new System.Drawing.Point(162, 262);
            this.Exportar.Name = "Exportar";
            this.Exportar.Size = new System.Drawing.Size(132, 49);
            this.Exportar.TabIndex = 6;
            this.Exportar.Text = "E&xport";
            this.Exportar.UseVisualStyleBackColor = true;
            this.Exportar.Click += new System.EventHandler(this.Exportar_Click);
            // 
            // groupBoxOpcao
            // 
            this.groupBoxOpcao.Controls.Add(this.Histograma);
            this.groupBoxOpcao.Controls.Add(this.GraficoRede);
            this.groupBoxOpcao.Location = new System.Drawing.Point(25, 12);
            this.groupBoxOpcao.Name = "groupBoxOpcao";
            this.groupBoxOpcao.Size = new System.Drawing.Size(546, 56);
            this.groupBoxOpcao.TabIndex = 1;
            this.groupBoxOpcao.TabStop = false;
            this.groupBoxOpcao.Text = "Please select the desired option:";
            // 
            // Histograma
            // 
            this.Histograma.AutoSize = true;
            this.Histograma.Location = new System.Drawing.Point(322, 21);
            this.Histograma.Name = "Histograma";
            this.Histograma.Size = new System.Drawing.Size(154, 20);
            this.Histograma.TabIndex = 1;
            this.Histograma.TabStop = true;
            this.Histograma.Text = "Investment histogram";
            this.Histograma.UseVisualStyleBackColor = true;
            this.Histograma.CheckedChanged += new System.EventHandler(this.Histograma_CheckedChanged);
            // 
            // GraficoRede
            // 
            this.GraficoRede.AutoSize = true;
            this.GraficoRede.Location = new System.Drawing.Point(6, 21);
            this.GraficoRede.Name = "GraficoRede";
            this.GraficoRede.Size = new System.Drawing.Size(130, 20);
            this.GraficoRede.TabIndex = 0;
            this.GraficoRede.TabStop = true;
            this.GraficoRede.Text = "Network diagram";
            this.GraficoRede.UseVisualStyleBackColor = true;
            this.GraficoRede.CheckedChanged += new System.EventHandler(this.GraficoRede_CheckedChanged);
            // 
            // comboClassesHistograma
            // 
            this.comboClassesHistograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClassesHistograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboClassesHistograma.FormattingEnabled = true;
            this.comboClassesHistograma.Location = new System.Drawing.Point(255, 166);
            this.comboClassesHistograma.Name = "comboClassesHistograma";
            this.comboClassesHistograma.Size = new System.Drawing.Size(316, 33);
            this.comboClassesHistograma.TabIndex = 4;
            this.comboClassesHistograma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboClassesHistograma_KeyDown);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(32, 169);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(240, 25);
            this.label16.TabIndex = 43;
            this.label16.Text = "Histogram bins:";
            // 
            // ToleranciaLimiteX
            // 
            this.ToleranciaLimiteX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToleranciaLimiteX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToleranciaLimiteX.FormattingEnabled = true;
            this.ToleranciaLimiteX.Location = new System.Drawing.Point(255, 206);
            this.ToleranciaLimiteX.Name = "ToleranciaLimiteX";
            this.ToleranciaLimiteX.Size = new System.Drawing.Size(316, 33);
            this.ToleranciaLimiteX.TabIndex = 5;
            // 
            // labelLimiteX
            // 
            this.labelLimiteX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLimiteX.Location = new System.Drawing.Point(32, 209);
            this.labelLimiteX.Name = "labelLimiteX";
            this.labelLimiteX.Size = new System.Drawing.Size(240, 25);
            this.labelLimiteX.TabIndex = 45;
            this.labelLimiteX.Text = "X-axis limit:";
            // 
            // AnaliseResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 332);
            this.Controls.Add(this.ToleranciaLimiteX);
            this.Controls.Add(this.labelLimiteX);
            this.Controls.Add(this.comboClassesHistograma);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBoxOpcao);
            this.Controls.Add(this.Exportar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboAno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboCenario);
            this.Controls.Add(this.Sair);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnaliseResultados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Results Analysis";
            this.Load += new System.EventHandler(this.AnaliseResultados_Load);
            this.groupBoxOpcao.ResumeLayout(false);
            this.groupBoxOpcao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.ComboBox comboCenario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboAno;
        private System.Windows.Forms.Button Exportar;
        private System.Windows.Forms.GroupBox groupBoxOpcao;
        private System.Windows.Forms.RadioButton Histograma;
        private System.Windows.Forms.RadioButton GraficoRede;
        private System.Windows.Forms.ComboBox comboClassesHistograma;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox ToleranciaLimiteX;
        private System.Windows.Forms.Label labelLimiteX;
    }
}