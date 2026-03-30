namespace PowerPlan
{
    partial class PDFs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFs));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.Sair = new System.Windows.Forms.Button();
            this.Adicionar = new System.Windows.Forms.Button();
            this.Excluir = new System.Windows.Forms.Button();
            this.Limpar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listaPDFs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.listaPDFs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(299, 27);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(124, 30);
            this.txtID.TabIndex = 1;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(299, 71);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(345, 30);
            this.txtDescricao.TabIndex = 2;
            this.txtDescricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricao_KeyDown);
            // 
            // Sair
            // 
            this.Sair.Location = new System.Drawing.Point(575, 415);
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(132, 49);
            this.Sair.TabIndex = 9;
            this.Sair.Text = "Cl&ose";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // Adicionar
            // 
            this.Adicionar.Location = new System.Drawing.Point(255, 415);
            this.Adicionar.Name = "Adicionar";
            this.Adicionar.Size = new System.Drawing.Size(132, 49);
            this.Adicionar.TabIndex = 7;
            this.Adicionar.Text = "&Add / Edit";
            this.Adicionar.UseVisualStyleBackColor = true;
            this.Adicionar.Click += new System.EventHandler(this.Adicionar_Click);
            // 
            // Excluir
            // 
            this.Excluir.Location = new System.Drawing.Point(415, 415);
            this.Excluir.Name = "Excluir";
            this.Excluir.Size = new System.Drawing.Size(132, 49);
            this.Excluir.TabIndex = 8;
            this.Excluir.Text = "&Delete";
            this.Excluir.UseVisualStyleBackColor = true;
            this.Excluir.Click += new System.EventHandler(this.Excluir_Click);
            // 
            // Limpar
            // 
            this.Limpar.Location = new System.Drawing.Point(95, 415);
            this.Limpar.Name = "Limpar";
            this.Limpar.Size = new System.Drawing.Size(132, 49);
            this.Limpar.TabIndex = 6;
            this.Limpar.Text = "&Clear";
            this.Limpar.UseVisualStyleBackColor = true;
            this.Limpar.Click += new System.EventHandler(this.Limpar_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(488, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Registered PDFs:";
            // 
            // listaPDFs
            // 
            this.listaPDFs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listaPDFs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaPDFs.Location = new System.Drawing.Point(27, 155);
            this.listaPDFs.MultiSelect = false;
            this.listaPDFs.Name = "listaPDFs";
            this.listaPDFs.ReadOnly = true;
            this.listaPDFs.RowHeadersWidth = 51;
            this.listaPDFs.RowTemplate.Height = 24;
            this.listaPDFs.Size = new System.Drawing.Size(746, 229);
            this.listaPDFs.TabIndex = 5;
            this.listaPDFs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaPDFs_CellDoubleClick);
            // 
            // PDFs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.listaPDFs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Limpar);
            this.Controls.Add(this.Excluir);
            this.Controls.Add(this.Adicionar);
            this.Controls.Add(this.Sair);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PDFs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Probability Density Functions (PDFs)";
            this.Load += new System.EventHandler(this.PDFs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaPDFs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.Button Adicionar;
        private System.Windows.Forms.Button Excluir;
        private System.Windows.Forms.Button Limpar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView listaPDFs;
    }
}