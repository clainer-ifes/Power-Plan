namespace PowerPlan
{
    partial class Reconductoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reconductoring));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.Sair = new System.Windows.Forms.Button();
            this.Adicionar = new System.Windows.Forms.Button();
            this.Excluir = new System.Windows.Forms.Button();
            this.Limpar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCusto = new System.Windows.Forms.TextBox();
            this.listaRecondutoramentos = new System.Windows.Forms.DataGridView();
            this.comboCondutorOrigem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboCondutorDestino = new System.Windows.Forms.ComboBox();
            this.Exportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listaRecondutoramentos)).BeginInit();
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
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 163);
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
            // Sair
            // 
            this.Sair.Location = new System.Drawing.Point(639, 493);
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(132, 49);
            this.Sair.TabIndex = 10;
            this.Sair.Text = "Cl&ose";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // Adicionar
            // 
            this.Adicionar.Location = new System.Drawing.Point(180, 493);
            this.Adicionar.Name = "Adicionar";
            this.Adicionar.Size = new System.Drawing.Size(132, 49);
            this.Adicionar.TabIndex = 7;
            this.Adicionar.Text = "&Add / Edit";
            this.Adicionar.UseVisualStyleBackColor = true;
            this.Adicionar.Click += new System.EventHandler(this.Adicionar_Click);
            // 
            // Excluir
            // 
            this.Excluir.Location = new System.Drawing.Point(333, 493);
            this.Excluir.Name = "Excluir";
            this.Excluir.Size = new System.Drawing.Size(132, 49);
            this.Excluir.TabIndex = 8;
            this.Excluir.Text = "&Delete";
            this.Excluir.UseVisualStyleBackColor = true;
            this.Excluir.Click += new System.EventHandler(this.Excluir_Click);
            // 
            // Limpar
            // 
            this.Limpar.Location = new System.Drawing.Point(27, 493);
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
            this.label4.Location = new System.Drawing.Point(22, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(488, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Registered Reconductoring Records:";
            // 
            // txtCusto
            // 
            this.txtCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusto.Location = new System.Drawing.Point(299, 163);
            this.txtCusto.Name = "txtCusto";
            this.txtCusto.Size = new System.Drawing.Size(351, 30);
            this.txtCusto.TabIndex = 4;
            this.txtCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCusto.Enter += new System.EventHandler(this.txtCusto_Enter);
            this.txtCusto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCusto_KeyDown);
            this.txtCusto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCusto_KeyPress);
            this.txtCusto.Leave += new System.EventHandler(this.txtCusto_Leave);
            // 
            // listaRecondutoramentos
            // 
            this.listaRecondutoramentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listaRecondutoramentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaRecondutoramentos.Location = new System.Drawing.Point(27, 243);
            this.listaRecondutoramentos.MultiSelect = false;
            this.listaRecondutoramentos.Name = "listaRecondutoramentos";
            this.listaRecondutoramentos.ReadOnly = true;
            this.listaRecondutoramentos.RowHeadersWidth = 51;
            this.listaRecondutoramentos.RowTemplate.Height = 24;
            this.listaRecondutoramentos.Size = new System.Drawing.Size(746, 229);
            this.listaRecondutoramentos.TabIndex = 5;
            this.listaRecondutoramentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaRecondutoramentos_CellDoubleClick_1);
            // 
            // comboCondutorOrigem
            // 
            this.comboCondutorOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCondutorOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCondutorOrigem.FormattingEnabled = true;
            this.comboCondutorOrigem.Location = new System.Drawing.Point(299, 64);
            this.comboCondutorOrigem.Name = "comboCondutorOrigem";
            this.comboCondutorOrigem.Size = new System.Drawing.Size(351, 33);
            this.comboCondutorOrigem.TabIndex = 2;
            this.comboCondutorOrigem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboCondutorOrigem_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Existing Conductor:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Proposed Conductor:";
            // 
            // comboCondutorDestino
            // 
            this.comboCondutorDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCondutorDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCondutorDestino.FormattingEnabled = true;
            this.comboCondutorDestino.Location = new System.Drawing.Point(299, 110);
            this.comboCondutorDestino.Name = "comboCondutorDestino";
            this.comboCondutorDestino.Size = new System.Drawing.Size(351, 33);
            this.comboCondutorDestino.TabIndex = 3;
            this.comboCondutorDestino.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboCondutorDestino_KeyDown);
            // 
            // Exportar
            // 
            this.Exportar.Location = new System.Drawing.Point(486, 493);
            this.Exportar.Name = "Exportar";
            this.Exportar.Size = new System.Drawing.Size(132, 49);
            this.Exportar.TabIndex = 9;
            this.Exportar.Text = "E&xport";
            this.Exportar.UseVisualStyleBackColor = true;
            this.Exportar.Click += new System.EventHandler(this.Exportar_Click);
            // 
            // Recondutoramento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Controls.Add(this.Exportar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboCondutorDestino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboCondutorOrigem);
            this.Controls.Add(this.listaRecondutoramentos);
            this.Controls.Add(this.txtCusto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Limpar);
            this.Controls.Add(this.Excluir);
            this.Controls.Add(this.Adicionar);
            this.Controls.Add(this.Sair);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Recondutoramento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reconductoring";
            this.Load += new System.EventHandler(this.Recondutoramento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaRecondutoramentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.Button Adicionar;
        private System.Windows.Forms.Button Excluir;
        private System.Windows.Forms.Button Limpar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCusto;
        private System.Windows.Forms.DataGridView listaRecondutoramentos;
        private System.Windows.Forms.ComboBox comboCondutorOrigem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboCondutorDestino;
        private System.Windows.Forms.Button Exportar;
    }
}