namespace PowerPlan
{
    partial class PowerPlan
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerPlan));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirRedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArquivoDeCoordenadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planejamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executarFluxoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otimizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotarDiagramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.análiseDeResultadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmosDeOtimizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condutoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recondutoramentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreOPowerPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CaixaAberturaArquivo = new System.Windows.Forms.OpenFileDialog();
            this.staBarraStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelRede = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCoordenadas = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.staBarraStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.planejamentoToolStripMenuItem,
            this.sistemaToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1095, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirRedeToolStripMenuItem,
            this.abrirArquivoDeCoordenadasToolStripMenuItem,
            this.toolStripSeparator1,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.arquivoToolStripMenuItem.Text = "&File";
            // 
            // abrirRedeToolStripMenuItem
            // 
            this.abrirRedeToolStripMenuItem.Name = "abrirRedeToolStripMenuItem";
            this.abrirRedeToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.abrirRedeToolStripMenuItem.Text = "&Open Network File...";
            this.abrirRedeToolStripMenuItem.Click += new System.EventHandler(this.abrirRedeToolStripMenuItem_Click);
            // 
            // abrirArquivoDeCoordenadasToolStripMenuItem
            // 
            this.abrirArquivoDeCoordenadasToolStripMenuItem.Name = "abrirArquivoDeCoordenadasToolStripMenuItem";
            this.abrirArquivoDeCoordenadasToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.abrirArquivoDeCoordenadasToolStripMenuItem.Text = "Open &Coordinates File...";
            this.abrirArquivoDeCoordenadasToolStripMenuItem.Click += new System.EventHandler(this.abrirArquivoDeCoordenadasToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.sairToolStripMenuItem.Text = "&Exit";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // planejamentoToolStripMenuItem
            // 
            this.planejamentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executarFluxoToolStripMenuItem,
            this.otimizaçãoToolStripMenuItem,
            this.plotarDiagramaToolStripMenuItem,
            this.análiseDeResultadosToolStripMenuItem});
            this.planejamentoToolStripMenuItem.Name = "planejamentoToolStripMenuItem";
            this.planejamentoToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.planejamentoToolStripMenuItem.Text = "&Plan";
            // 
            // executarFluxoToolStripMenuItem
            // 
            this.executarFluxoToolStripMenuItem.Name = "executarFluxoToolStripMenuItem";
            this.executarFluxoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.executarFluxoToolStripMenuItem.Text = "&Run Power Flow";
            this.executarFluxoToolStripMenuItem.Visible = false;
            this.executarFluxoToolStripMenuItem.Click += new System.EventHandler(this.executarFluxoToolStripMenuItem_Click);
            // 
            // otimizaçãoToolStripMenuItem
            // 
            this.otimizaçãoToolStripMenuItem.Name = "otimizaçãoToolStripMenuItem";
            this.otimizaçãoToolStripMenuItem.ShortcutKeyDisplayString = "F4";
            this.otimizaçãoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.otimizaçãoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.otimizaçãoToolStripMenuItem.Text = "&Optimization";
            this.otimizaçãoToolStripMenuItem.Click += new System.EventHandler(this.otimizaçãoToolStripMenuItem_Click);
            // 
            // plotarDiagramaToolStripMenuItem
            // 
            this.plotarDiagramaToolStripMenuItem.Name = "plotarDiagramaToolStripMenuItem";
            this.plotarDiagramaToolStripMenuItem.ShortcutKeyDisplayString = "F5";
            this.plotarDiagramaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.plotarDiagramaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.plotarDiagramaToolStripMenuItem.Text = "&Plot Diagram";
            this.plotarDiagramaToolStripMenuItem.Click += new System.EventHandler(this.plotarDiagramaToolStripMenuItem_Click);
            // 
            // análiseDeResultadosToolStripMenuItem
            // 
            this.análiseDeResultadosToolStripMenuItem.Name = "análiseDeResultadosToolStripMenuItem";
            this.análiseDeResultadosToolStripMenuItem.ShortcutKeyDisplayString = "F6";
            this.análiseDeResultadosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.análiseDeResultadosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.análiseDeResultadosToolStripMenuItem.Text = "Re&sults";
            this.análiseDeResultadosToolStripMenuItem.Click += new System.EventHandler(this.análiseDeResultadosToolStripMenuItem_Click);
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDFsToolStripMenuItem,
            this.algoritmosDeOtimizaçãoToolStripMenuItem,
            this.condutoresToolStripMenuItem,
            this.recondutoramentoToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.sistemaToolStripMenuItem.Text = "&System";
            // 
            // pDFsToolStripMenuItem
            // 
            this.pDFsToolStripMenuItem.Name = "pDFsToolStripMenuItem";
            this.pDFsToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.pDFsToolStripMenuItem.Text = "&PDFs";
            this.pDFsToolStripMenuItem.Click += new System.EventHandler(this.pDFsToolStripMenuItem_Click_1);
            // 
            // algoritmosDeOtimizaçãoToolStripMenuItem
            // 
            this.algoritmosDeOtimizaçãoToolStripMenuItem.Name = "algoritmosDeOtimizaçãoToolStripMenuItem";
            this.algoritmosDeOtimizaçãoToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.algoritmosDeOtimizaçãoToolStripMenuItem.Text = "&Optimization Algorithms";
            this.algoritmosDeOtimizaçãoToolStripMenuItem.Click += new System.EventHandler(this.algoritmosDeOtimizaçãoToolStripMenuItem_Click);
            // 
            // condutoresToolStripMenuItem
            // 
            this.condutoresToolStripMenuItem.Name = "condutoresToolStripMenuItem";
            this.condutoresToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.condutoresToolStripMenuItem.Text = "&Conductors";
            this.condutoresToolStripMenuItem.Click += new System.EventHandler(this.condutoresToolStripMenuItem_Click);
            // 
            // recondutoramentoToolStripMenuItem
            // 
            this.recondutoramentoToolStripMenuItem.Name = "recondutoramentoToolStripMenuItem";
            this.recondutoramentoToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.recondutoramentoToolStripMenuItem.Text = "&Reconductoring Cost";
            this.recondutoramentoToolStripMenuItem.Click += new System.EventHandler(this.recondutoramentoToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreOPowerPlanToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.sobreToolStripMenuItem.Text = "&About";
            // 
            // sobreOPowerPlanToolStripMenuItem
            // 
            this.sobreOPowerPlanToolStripMenuItem.Name = "sobreOPowerPlanToolStripMenuItem";
            this.sobreOPowerPlanToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.sobreOPowerPlanToolStripMenuItem.Text = "&About Power Plan";
            this.sobreOPowerPlanToolStripMenuItem.Click += new System.EventHandler(this.sobreOPowerPlanToolStripMenuItem_Click);
            // 
            // CaixaAberturaArquivo
            // 
            this.CaixaAberturaArquivo.FileOk += new System.ComponentModel.CancelEventHandler(this.CaixaAberturaArquivo_FileOk);
            // 
            // staBarraStatus
            // 
            this.staBarraStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.staBarraStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelRede,
            this.toolStripStatusLabelCoordenadas});
            this.staBarraStatus.Location = new System.Drawing.Point(0, 440);
            this.staBarraStatus.Name = "staBarraStatus";
            this.staBarraStatus.Size = new System.Drawing.Size(1095, 26);
            this.staBarraStatus.TabIndex = 5;
            this.staBarraStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRede
            // 
            this.toolStripStatusLabelRede.Name = "toolStripStatusLabelRede";
            this.toolStripStatusLabelRede.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabelRede.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelCoordenadas
            // 
            this.toolStripStatusLabelCoordenadas.Name = "toolStripStatusLabelCoordenadas";
            this.toolStripStatusLabelCoordenadas.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.toolStripStatusLabelCoordenadas.Size = new System.Drawing.Size(201, 20);
            this.toolStripStatusLabelCoordenadas.Text = "toolStripStatusLabel2";
            this.toolStripStatusLabelCoordenadas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PowerPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 466);
            this.Controls.Add(this.staBarraStatus);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PowerPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power Plan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PowerPlan_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.staBarraStatus.ResumeLayout(false);
            this.staBarraStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirRedeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planejamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executarFluxoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem condutoresToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog CaixaAberturaArquivo;
        private System.Windows.Forms.TextBox ArquivoSelecionado;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreOPowerPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recondutoramentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmosDeOtimizaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirArquivoDeCoordenadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plotarDiagramaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otimizaçãoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip staBarraStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRede;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCoordenadas;
        private System.Windows.Forms.ToolStripMenuItem análiseDeResultadosToolStripMenuItem;
    }
}

