namespace PowerPlan
{
    partial class Histogram
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Histogram));
            this.Sair = new System.Windows.Forms.Button();
            this.area_grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.area_grafico)).BeginInit();
            this.SuspendLayout();
            // 
            // Sair
            // 
            this.Sair.Location = new System.Drawing.Point(568, 504);
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(132, 49);
            this.Sair.TabIndex = 2;
            this.Sair.Text = "&Close";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // area_grafico
            // 
            chartArea1.Name = "ChartArea1";
            this.area_grafico.ChartAreas.Add(chartArea1);
            this.area_grafico.Location = new System.Drawing.Point(20, 14);
            this.area_grafico.Name = "area_grafico";
            this.area_grafico.Size = new System.Drawing.Size(1149, 474);
            this.area_grafico.TabIndex = 3;
            this.area_grafico.Text = "chart1";
            // 
            // Histograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 575);
            this.Controls.Add(this.area_grafico);
            this.Controls.Add(this.Sair);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Histograma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histogram";
            this.Load += new System.EventHandler(this.Histograma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.area_grafico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.DataVisualization.Charting.Chart area_grafico;
    }
}