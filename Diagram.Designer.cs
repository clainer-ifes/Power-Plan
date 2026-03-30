namespace PowerPlan
{
    partial class Diagram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diagram));
            this.Sair = new System.Windows.Forms.Button();
            this.pictureDiagrama = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDiagrama)).BeginInit();
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
            // pictureDiagrama
            // 
            this.pictureDiagrama.BackColor = System.Drawing.Color.White;
            this.pictureDiagrama.Location = new System.Drawing.Point(12, 21);
            this.pictureDiagrama.Name = "pictureDiagrama";
            this.pictureDiagrama.Size = new System.Drawing.Size(1169, 477);
            this.pictureDiagrama.TabIndex = 3;
            this.pictureDiagrama.TabStop = false;
            // 
            // Diagrama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 575);
            this.Controls.Add(this.pictureDiagrama);
            this.Controls.Add(this.Sair);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Diagrama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diagram";
            this.Load += new System.EventHandler(this.Diagrama_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Diagrama_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureDiagrama)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Sair;
        public System.Windows.Forms.PictureBox pictureDiagrama;
    }
}