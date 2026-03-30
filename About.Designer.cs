namespace PowerPlan
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.label1 = new System.Windows.Forms.Label();
            this.texto_sobre = new System.Windows.Forms.Label();
            this.Sair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 84);
            this.label1.TabIndex = 0;
            this.label1.Text = "Power Plan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // texto_sobre
            // 
            this.texto_sobre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texto_sobre.Location = new System.Drawing.Point(26, 151);
            this.texto_sobre.Name = "texto_sobre";
            this.texto_sobre.Size = new System.Drawing.Size(673, 228);
            this.texto_sobre.TabIndex = 1;
            this.texto_sobre.Text = "Power Plan";
            this.texto_sobre.Click += new System.EventHandler(this.label2_Click);
            // 
            // Sair
            // 
            this.Sair.Location = new System.Drawing.Point(296, 399);
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(132, 49);
            this.Sair.TabIndex = 2;
            this.Sair.Text = "&Close";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 460);
            this.Controls.Add(this.Sair);
            this.Controls.Add(this.texto_sobre);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.Sobre_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label texto_sobre;
        private System.Windows.Forms.Button Sair;
    }
}