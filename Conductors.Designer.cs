namespace PowerPlan
{
    partial class Conductors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Conductors));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.Sair = new System.Windows.Forms.Button();
            this.Adicionar = new System.Windows.Forms.Button();
            this.Excluir = new System.Windows.Forms.Button();
            this.Limpar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCusto = new System.Windows.Forms.TextBox();
            this.listaCondutores = new System.Windows.Forms.DataGridView();
            this.txtCapacidade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoOpenDSS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Exportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listaCondutores)).BeginInit();
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
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cost [$/km]:";
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
            this.Sair.Location = new System.Drawing.Point(639, 534);
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(132, 49);
            this.Sair.TabIndex = 11;
            this.Sair.Text = "Cl&ose";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // Adicionar
            // 
            this.Adicionar.Location = new System.Drawing.Point(180, 534);
            this.Adicionar.Name = "Adicionar";
            this.Adicionar.Size = new System.Drawing.Size(132, 49);
            this.Adicionar.TabIndex = 8;
            this.Adicionar.Text = "&Add / Edit";
            this.Adicionar.UseVisualStyleBackColor = true;
            this.Adicionar.Click += new System.EventHandler(this.Adicionar_Click);
            // 
            // Excluir
            // 
            this.Excluir.Location = new System.Drawing.Point(333, 534);
            this.Excluir.Name = "Excluir";
            this.Excluir.Size = new System.Drawing.Size(132, 49);
            this.Excluir.TabIndex = 9;
            this.Excluir.Text = "&Delete";
            this.Excluir.UseVisualStyleBackColor = true;
            this.Excluir.Click += new System.EventHandler(this.Excluir_Click);
            // 
            // Limpar
            // 
            this.Limpar.Location = new System.Drawing.Point(27, 534);
            this.Limpar.Name = "Limpar";
            this.Limpar.Size = new System.Drawing.Size(132, 49);
            this.Limpar.TabIndex = 7;
            this.Limpar.Text = "&Clear";
            this.Limpar.UseVisualStyleBackColor = true;
            this.Limpar.Click += new System.EventHandler(this.Limpar_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(488, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Registered Conductors:";
            // 
            // txtCusto
            // 
            this.txtCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusto.Location = new System.Drawing.Point(299, 118);
            this.txtCusto.Name = "txtCusto";
            this.txtCusto.Size = new System.Drawing.Size(345, 30);
            this.txtCusto.TabIndex = 3;
            this.txtCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCusto.Enter += new System.EventHandler(this.txtCusto_Enter);
            this.txtCusto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCusto_KeyDown);
            this.txtCusto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCusto_KeyPress);
            this.txtCusto.Leave += new System.EventHandler(this.txtCusto_Leave);
            // 
            // listaCondutores
            // 
            this.listaCondutores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listaCondutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaCondutores.Location = new System.Drawing.Point(27, 284);
            this.listaCondutores.MultiSelect = false;
            this.listaCondutores.Name = "listaCondutores";
            this.listaCondutores.ReadOnly = true;
            this.listaCondutores.RowHeadersWidth = 51;
            this.listaCondutores.RowTemplate.Height = 24;
            this.listaCondutores.Size = new System.Drawing.Size(746, 229);
            this.listaCondutores.TabIndex = 6;
            this.listaCondutores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaCondutores_CellDoubleClick);
            // 
            // txtCapacidade
            // 
            this.txtCapacidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacidade.Location = new System.Drawing.Point(299, 164);
            this.txtCapacidade.Name = "txtCapacidade";
            this.txtCapacidade.Size = new System.Drawing.Size(345, 30);
            this.txtCapacidade.TabIndex = 4;
            this.txtCapacidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCapacidade.Enter += new System.EventHandler(this.txtCapacidade_Enter);
            this.txtCapacidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCapacidade_KeyDown);
            this.txtCapacidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCapacidade_KeyPress);
            this.txtCapacidade.Leave += new System.EventHandler(this.txtCapacidade_Leave);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Capacity [A]:";
            // 
            // txtCodigoOpenDSS
            // 
            this.txtCodigoOpenDSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoOpenDSS.Location = new System.Drawing.Point(299, 213);
            this.txtCodigoOpenDSS.Name = "txtCodigoOpenDSS";
            this.txtCodigoOpenDSS.Size = new System.Drawing.Size(345, 30);
            this.txtCodigoOpenDSS.TabIndex = 5;
            this.txtCodigoOpenDSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoOpenDSS.Enter += new System.EventHandler(this.txtCodigoOpenDSS_Enter);
            this.txtCodigoOpenDSS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoOpenDSS_KeyDown);
            this.txtCodigoOpenDSS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoOpenDSS_KeyPress);
            this.txtCodigoOpenDSS.Leave += new System.EventHandler(this.txtCodigoOpenDSS_Leave);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "OpenDSS Code [-]:";
            // 
            // Exportar
            // 
            this.Exportar.Location = new System.Drawing.Point(486, 534);
            this.Exportar.Name = "Exportar";
            this.Exportar.Size = new System.Drawing.Size(132, 49);
            this.Exportar.TabIndex = 10;
            this.Exportar.Text = "E&xport";
            this.Exportar.UseVisualStyleBackColor = true;
            this.Exportar.Click += new System.EventHandler(this.Exportar_Click);
            // 
            // Condutores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 606);
            this.Controls.Add(this.Exportar);
            this.Controls.Add(this.txtCodigoOpenDSS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCapacidade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listaCondutores);
            this.Controls.Add(this.txtCusto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Limpar);
            this.Controls.Add(this.Excluir);
            this.Controls.Add(this.Adicionar);
            this.Controls.Add(this.Sair);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Condutores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conductors";
            this.Load += new System.EventHandler(this.Condutores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaCondutores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.Button Adicionar;
        private System.Windows.Forms.Button Excluir;
        private System.Windows.Forms.Button Limpar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCusto;
        private System.Windows.Forms.DataGridView listaCondutores;
        private System.Windows.Forms.TextBox txtCapacidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoOpenDSS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Exportar;
    }
}