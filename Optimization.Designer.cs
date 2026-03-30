namespace PowerPlan
{
    partial class Optimization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Optimization));
            this.label3 = new System.Windows.Forms.Label();
            this.Sair = new System.Windows.Forms.Button();
            this.ExecutarOtimizacao = new System.Windows.Forms.Button();
            this.Limpar = new System.Windows.Forms.Button();
            this.txtFatorCrescimentoAno1 = new System.Windows.Forms.TextBox();
            this.comboPDF = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboAlgoritmo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFatorCrescimentoAno2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFatorCrescimentoAno3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFatorCrescimentoAno4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFatorCrescimentoAno5 = new System.Windows.Forms.TextBox();
            this.chkCondutoresPermitidos = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkTodosCondutores = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDesvioPadraoRelativo = new System.Windows.Forms.TextBox();
            this.checkCargasAleatorias = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkCargas = new System.Windows.Forms.CheckedListBox();
            this.comboPontosPDF = new System.Windows.Forms.ComboBox();
            this.comboLimiteInferiorPDF = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboLimiteSuperiorPDF = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboQuantidadeCargasAleatorias = new System.Windows.Forms.ComboBox();
            this.comboGrandezaSaida = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboClassesHistograma = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCarregamentoLimite = new System.Windows.Forms.TextBox();
            this.comboUnidadeComprimento = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboJanelaAnalise = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.comboTipoAleatorio = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCenariosSimulados = new System.Windows.Forms.TextBox();
            this.txtIntervaloConfianca = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Growth rate [%/year]:";
            // 
            // Sair
            // 
            this.Sair.Location = new System.Drawing.Point(783, 664);
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(132, 49);
            this.Sair.TabIndex = 25;
            this.Sair.Text = "&Close";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // ExecutarOtimizacao
            // 
            this.ExecutarOtimizacao.Location = new System.Drawing.Point(626, 664);
            this.ExecutarOtimizacao.Name = "ExecutarOtimizacao";
            this.ExecutarOtimizacao.Size = new System.Drawing.Size(132, 49);
            this.ExecutarOtimizacao.TabIndex = 24;
            this.ExecutarOtimizacao.Text = "&Run";
            this.ExecutarOtimizacao.UseVisualStyleBackColor = true;
            this.ExecutarOtimizacao.Click += new System.EventHandler(this.ExecutarOtimizacao_Click);
            // 
            // Limpar
            // 
            this.Limpar.Location = new System.Drawing.Point(466, 664);
            this.Limpar.Name = "Limpar";
            this.Limpar.Size = new System.Drawing.Size(132, 49);
            this.Limpar.TabIndex = 23;
            this.Limpar.Text = "Cl&ear / Restore";
            this.Limpar.UseVisualStyleBackColor = true;
            this.Limpar.Click += new System.EventHandler(this.Limpar_Click);
            // 
            // txtFatorCrescimentoAno1
            // 
            this.txtFatorCrescimentoAno1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatorCrescimentoAno1.Location = new System.Drawing.Point(432, 141);
            this.txtFatorCrescimentoAno1.Name = "txtFatorCrescimentoAno1";
            this.txtFatorCrescimentoAno1.Size = new System.Drawing.Size(233, 30);
            this.txtFatorCrescimentoAno1.TabIndex = 4;
            this.txtFatorCrescimentoAno1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFatorCrescimentoAno1.Enter += new System.EventHandler(this.txtFatorCrescimentoAno1_Enter);
            this.txtFatorCrescimentoAno1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFatorCrescimentoAno1_KeyDown);
            this.txtFatorCrescimentoAno1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFatorCrescimentoAno1_KeyPress);
            this.txtFatorCrescimentoAno1.Leave += new System.EventHandler(this.txtFatorCrescimentoAno1_Leave);
            // 
            // comboPDF
            // 
            this.comboPDF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPDF.FormattingEnabled = true;
            this.comboPDF.Location = new System.Drawing.Point(341, 24);
            this.comboPDF.Name = "comboPDF";
            this.comboPDF.Size = new System.Drawing.Size(324, 33);
            this.comboPDF.TabIndex = 1;
            this.comboPDF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboPDF_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "PDF:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Optimization algorithm:";
            // 
            // comboAlgoritmo
            // 
            this.comboAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAlgoritmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAlgoritmo.FormattingEnabled = true;
            this.comboAlgoritmo.Location = new System.Drawing.Point(341, 102);
            this.comboAlgoritmo.Name = "comboAlgoritmo";
            this.comboAlgoritmo.Size = new System.Drawing.Size(324, 33);
            this.comboAlgoritmo.TabIndex = 3;
            this.comboAlgoritmo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboAlgoritmo_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(336, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Year #1";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(336, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Year #2";
            // 
            // txtFatorCrescimentoAno2
            // 
            this.txtFatorCrescimentoAno2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatorCrescimentoAno2.Location = new System.Drawing.Point(432, 177);
            this.txtFatorCrescimentoAno2.Name = "txtFatorCrescimentoAno2";
            this.txtFatorCrescimentoAno2.Size = new System.Drawing.Size(233, 30);
            this.txtFatorCrescimentoAno2.TabIndex = 5;
            this.txtFatorCrescimentoAno2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFatorCrescimentoAno2.Enter += new System.EventHandler(this.txtFatorCrescimentoAno2_Enter);
            this.txtFatorCrescimentoAno2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFatorCrescimentoAno2_KeyDown);
            this.txtFatorCrescimentoAno2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFatorCrescimentoAno2_KeyPress);
            this.txtFatorCrescimentoAno2.Leave += new System.EventHandler(this.txtFatorCrescimentoAno2_Leave);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(336, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "Year #3";
            // 
            // txtFatorCrescimentoAno3
            // 
            this.txtFatorCrescimentoAno3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatorCrescimentoAno3.Location = new System.Drawing.Point(432, 213);
            this.txtFatorCrescimentoAno3.Name = "txtFatorCrescimentoAno3";
            this.txtFatorCrescimentoAno3.Size = new System.Drawing.Size(233, 30);
            this.txtFatorCrescimentoAno3.TabIndex = 6;
            this.txtFatorCrescimentoAno3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFatorCrescimentoAno3.Enter += new System.EventHandler(this.txtFatorCrescimentoAno3_Enter);
            this.txtFatorCrescimentoAno3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFatorCrescimentoAno3_KeyDown);
            this.txtFatorCrescimentoAno3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFatorCrescimentoAno3_KeyPress);
            this.txtFatorCrescimentoAno3.Leave += new System.EventHandler(this.txtFatorCrescimentoAno3_Leave);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(336, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "Year #4";
            // 
            // txtFatorCrescimentoAno4
            // 
            this.txtFatorCrescimentoAno4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatorCrescimentoAno4.Location = new System.Drawing.Point(432, 249);
            this.txtFatorCrescimentoAno4.Name = "txtFatorCrescimentoAno4";
            this.txtFatorCrescimentoAno4.Size = new System.Drawing.Size(233, 30);
            this.txtFatorCrescimentoAno4.TabIndex = 7;
            this.txtFatorCrescimentoAno4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFatorCrescimentoAno4.Enter += new System.EventHandler(this.txtFatorCrescimentoAno4_Enter);
            this.txtFatorCrescimentoAno4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFatorCrescimentoAno4_KeyDown);
            this.txtFatorCrescimentoAno4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFatorCrescimentoAno4_KeyPress);
            this.txtFatorCrescimentoAno4.Leave += new System.EventHandler(this.txtFatorCrescimentoAno4_Leave);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(336, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 25);
            this.label8.TabIndex = 24;
            this.label8.Text = "Year #5";
            // 
            // txtFatorCrescimentoAno5
            // 
            this.txtFatorCrescimentoAno5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatorCrescimentoAno5.Location = new System.Drawing.Point(432, 285);
            this.txtFatorCrescimentoAno5.Name = "txtFatorCrescimentoAno5";
            this.txtFatorCrescimentoAno5.Size = new System.Drawing.Size(233, 30);
            this.txtFatorCrescimentoAno5.TabIndex = 8;
            this.txtFatorCrescimentoAno5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFatorCrescimentoAno5.Enter += new System.EventHandler(this.txtFatorCrescimentoAno5_Enter);
            this.txtFatorCrescimentoAno5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFatorCrescimentoAno5_KeyDown);
            this.txtFatorCrescimentoAno5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFatorCrescimentoAno5_KeyPress);
            this.txtFatorCrescimentoAno5.Leave += new System.EventHandler(this.txtFatorCrescimentoAno5_Leave);
            // 
            // chkCondutoresPermitidos
            // 
            this.chkCondutoresPermitidos.CheckOnClick = true;
            this.chkCondutoresPermitidos.FormattingEnabled = true;
            this.chkCondutoresPermitidos.Location = new System.Drawing.Point(944, 63);
            this.chkCondutoresPermitidos.Name = "chkCondutoresPermitidos";
            this.chkCondutoresPermitidos.Size = new System.Drawing.Size(324, 157);
            this.chkCondutoresPermitidos.TabIndex = 16;
            this.chkCondutoresPermitidos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkCondutoresPermitidos_KeyDown);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(671, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(244, 79);
            this.label9.TabIndex = 26;
            this.label9.Text = "Allowed conductors for reconductoring:";
            // 
            // checkTodosCondutores
            // 
            this.checkTodosCondutores.AutoSize = true;
            this.checkTodosCondutores.Location = new System.Drawing.Point(944, 30);
            this.checkTodosCondutores.Name = "checkTodosCondutores";
            this.checkTodosCondutores.Size = new System.Drawing.Size(113, 20);
            this.checkTodosCondutores.TabIndex = 15;
            this.checkTodosCondutores.Text = "All conductors";
            this.checkTodosCondutores.UseVisualStyleBackColor = true;
            this.checkTodosCondutores.CheckedChanged += new System.EventHandler(this.checkTodosCondutores_CheckedChanged);
            this.checkTodosCondutores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkTodosCondutores_KeyDown);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 347);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(278, 25);
            this.label10.TabIndex = 28;
            this.label10.Text = "PDF sample points:";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 455);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(287, 25);
            this.label11.TabIndex = 30;
            this.label11.Text = "Relative standard deviation [%]:";
            // 
            // txtDesvioPadraoRelativo
            // 
            this.txtDesvioPadraoRelativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesvioPadraoRelativo.Location = new System.Drawing.Point(341, 452);
            this.txtDesvioPadraoRelativo.Name = "txtDesvioPadraoRelativo";
            this.txtDesvioPadraoRelativo.Size = new System.Drawing.Size(324, 30);
            this.txtDesvioPadraoRelativo.TabIndex = 10;
            this.txtDesvioPadraoRelativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesvioPadraoRelativo.Enter += new System.EventHandler(this.txtDesvioPadraoRelativo_Enter);
            this.txtDesvioPadraoRelativo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesvioPadraoRelativo_KeyDown);
            this.txtDesvioPadraoRelativo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesvioPadraoRelativo_KeyPress);
            this.txtDesvioPadraoRelativo.Leave += new System.EventHandler(this.txtDesvioPadraoRelativo_Leave);
            // 
            // checkCargasAleatorias
            // 
            this.checkCargasAleatorias.AutoSize = true;
            this.checkCargasAleatorias.Location = new System.Drawing.Point(944, 311);
            this.checkCargasAleatorias.Name = "checkCargasAleatorias";
            this.checkCargasAleatorias.Size = new System.Drawing.Size(206, 20);
            this.checkCargasAleatorias.TabIndex = 19;
            this.checkCargasAleatorias.Text = "Automatic selection / Quantity:";
            this.checkCargasAleatorias.UseVisualStyleBackColor = true;
            this.checkCargasAleatorias.CheckedChanged += new System.EventHandler(this.checkCargasAleatorias_CheckedChanged);
            this.checkCargasAleatorias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkCargasAleatorias_KeyDown);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(671, 304);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(244, 79);
            this.label12.TabIndex = 33;
            this.label12.Text = "Selected loads:";
            // 
            // chkCargas
            // 
            this.chkCargas.CheckOnClick = true;
            this.chkCargas.FormattingEnabled = true;
            this.chkCargas.Location = new System.Drawing.Point(949, 380);
            this.chkCargas.Name = "chkCargas";
            this.chkCargas.Size = new System.Drawing.Size(324, 259);
            this.chkCargas.TabIndex = 22;
            this.chkCargas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkCargas_ItemCheck);
            this.chkCargas.SelectedIndexChanged += new System.EventHandler(this.chkCargas_SelectedIndexChanged);
            this.chkCargas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkCargas_KeyDown);
            // 
            // comboPontosPDF
            // 
            this.comboPontosPDF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPontosPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPontosPDF.FormattingEnabled = true;
            this.comboPontosPDF.Location = new System.Drawing.Point(341, 341);
            this.comboPontosPDF.Name = "comboPontosPDF";
            this.comboPontosPDF.Size = new System.Drawing.Size(324, 33);
            this.comboPontosPDF.TabIndex = 9;
            this.comboPontosPDF.SelectedIndexChanged += new System.EventHandler(this.comboPontosPDF_SelectedIndexChanged);
            this.comboPontosPDF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboPontosPDF_KeyDown);
            // 
            // comboLimiteInferiorPDF
            // 
            this.comboLimiteInferiorPDF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLimiteInferiorPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLimiteInferiorPDF.FormattingEnabled = true;
            this.comboLimiteInferiorPDF.Location = new System.Drawing.Point(341, 488);
            this.comboLimiteInferiorPDF.Name = "comboLimiteInferiorPDF";
            this.comboLimiteInferiorPDF.Size = new System.Drawing.Size(324, 33);
            this.comboLimiteInferiorPDF.TabIndex = 11;
            this.comboLimiteInferiorPDF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboLimiteInferiorPDF_KeyDown);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(23, 494);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(336, 25);
            this.label13.TabIndex = 35;
            this.label13.Text = "PDF lower analysis limit:";
            // 
            // comboLimiteSuperiorPDF
            // 
            this.comboLimiteSuperiorPDF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLimiteSuperiorPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLimiteSuperiorPDF.FormattingEnabled = true;
            this.comboLimiteSuperiorPDF.Location = new System.Drawing.Point(341, 527);
            this.comboLimiteSuperiorPDF.Name = "comboLimiteSuperiorPDF";
            this.comboLimiteSuperiorPDF.Size = new System.Drawing.Size(324, 33);
            this.comboLimiteSuperiorPDF.TabIndex = 12;
            this.comboLimiteSuperiorPDF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboLimiteSuperiorPDF_KeyDown);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(23, 533);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(336, 25);
            this.label14.TabIndex = 37;
            this.label14.Text = "PDF upper analysis limit:";
            // 
            // comboQuantidadeCargasAleatorias
            // 
            this.comboQuantidadeCargasAleatorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQuantidadeCargasAleatorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboQuantidadeCargasAleatorias.FormattingEnabled = true;
            this.comboQuantidadeCargasAleatorias.ItemHeight = 25;
            this.comboQuantidadeCargasAleatorias.Location = new System.Drawing.Point(1201, 302);
            this.comboQuantidadeCargasAleatorias.Name = "comboQuantidadeCargasAleatorias";
            this.comboQuantidadeCargasAleatorias.Size = new System.Drawing.Size(67, 33);
            this.comboQuantidadeCargasAleatorias.TabIndex = 20;
            this.comboQuantidadeCargasAleatorias.SelectedIndexChanged += new System.EventHandler(this.comboQuantidadeCargasAleatorias_SelectedIndexChanged);
            this.comboQuantidadeCargasAleatorias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboQuantidadeCargasAleatorias_KeyDown);
            // 
            // comboGrandezaSaida
            // 
            this.comboGrandezaSaida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrandezaSaida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboGrandezaSaida.FormattingEnabled = true;
            this.comboGrandezaSaida.Location = new System.Drawing.Point(341, 566);
            this.comboGrandezaSaida.Name = "comboGrandezaSaida";
            this.comboGrandezaSaida.Size = new System.Drawing.Size(324, 33);
            this.comboGrandezaSaida.TabIndex = 13;
            this.comboGrandezaSaida.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboGrandezaSaida_KeyDown);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(23, 572);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(336, 25);
            this.label15.TabIndex = 39;
            this.label15.Text = "Output variable:";
            // 
            // comboClassesHistograma
            // 
            this.comboClassesHistograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClassesHistograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboClassesHistograma.FormattingEnabled = true;
            this.comboClassesHistograma.Location = new System.Drawing.Point(341, 605);
            this.comboClassesHistograma.Name = "comboClassesHistograma";
            this.comboClassesHistograma.Size = new System.Drawing.Size(324, 33);
            this.comboClassesHistograma.TabIndex = 14;
            this.comboClassesHistograma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboClassesHistograma_KeyDown);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(23, 611);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(336, 25);
            this.label16.TabIndex = 41;
            this.label16.Text = "Histogram bins:";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(671, 263);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(256, 25);
            this.label17.TabIndex = 43;
            this.label17.Text = "Loading limit [%]:";
            // 
            // txtCarregamentoLimite
            // 
            this.txtCarregamentoLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarregamentoLimite.Location = new System.Drawing.Point(944, 260);
            this.txtCarregamentoLimite.Name = "txtCarregamentoLimite";
            this.txtCarregamentoLimite.Size = new System.Drawing.Size(324, 30);
            this.txtCarregamentoLimite.TabIndex = 18;
            this.txtCarregamentoLimite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCarregamentoLimite.Enter += new System.EventHandler(this.txtCarregamentoLimite_Enter);
            this.txtCarregamentoLimite.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCarregamentoLimite_KeyDown);
            this.txtCarregamentoLimite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCarregamentoLimite_KeyPress);
            this.txtCarregamentoLimite.Leave += new System.EventHandler(this.txtCarregamentoLimite_Leave);
            // 
            // comboUnidadeComprimento
            // 
            this.comboUnidadeComprimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUnidadeComprimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUnidadeComprimento.FormattingEnabled = true;
            this.comboUnidadeComprimento.Location = new System.Drawing.Point(944, 223);
            this.comboUnidadeComprimento.Name = "comboUnidadeComprimento";
            this.comboUnidadeComprimento.Size = new System.Drawing.Size(324, 33);
            this.comboUnidadeComprimento.TabIndex = 17;
            this.comboUnidadeComprimento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboUnidadeComprimento_KeyDown);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(671, 223);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(267, 25);
            this.label18.TabIndex = 45;
            this.label18.Text = "Length unit:";
            // 
            // comboJanelaAnalise
            // 
            this.comboJanelaAnalise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboJanelaAnalise.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboJanelaAnalise.FormattingEnabled = true;
            this.comboJanelaAnalise.Location = new System.Drawing.Point(341, 63);
            this.comboJanelaAnalise.Name = "comboJanelaAnalise";
            this.comboJanelaAnalise.Size = new System.Drawing.Size(324, 33);
            this.comboJanelaAnalise.TabIndex = 2;
            this.comboJanelaAnalise.SelectionChangeCommitted += new System.EventHandler(this.comboJanelaAnalise_SelectionChangeCommitted);
            this.comboJanelaAnalise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboJanelaAnalise_KeyDown);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(23, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(244, 25);
            this.label19.TabIndex = 47;
            this.label19.Text = "Time window:";
            // 
            // comboTipoAleatorio
            // 
            this.comboTipoAleatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoAleatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTipoAleatorio.FormattingEnabled = true;
            this.comboTipoAleatorio.Location = new System.Drawing.Point(949, 341);
            this.comboTipoAleatorio.Name = "comboTipoAleatorio";
            this.comboTipoAleatorio.Size = new System.Drawing.Size(324, 33);
            this.comboTipoAleatorio.TabIndex = 21;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(23, 383);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(278, 25);
            this.label20.TabIndex = 48;
            this.label20.Text = "Simulated scenarios [-]:";
            // 
            // txtCenariosSimulados
            // 
            this.txtCenariosSimulados.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCenariosSimulados.Enabled = false;
            this.txtCenariosSimulados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCenariosSimulados.Location = new System.Drawing.Point(341, 380);
            this.txtCenariosSimulados.Name = "txtCenariosSimulados";
            this.txtCenariosSimulados.Size = new System.Drawing.Size(324, 30);
            this.txtCenariosSimulados.TabIndex = 49;
            this.txtCenariosSimulados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIntervaloConfianca
            // 
            this.txtIntervaloConfianca.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIntervaloConfianca.Enabled = false;
            this.txtIntervaloConfianca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntervaloConfianca.Location = new System.Drawing.Point(341, 416);
            this.txtIntervaloConfianca.Name = "txtIntervaloConfianca";
            this.txtIntervaloConfianca.Size = new System.Drawing.Size(324, 30);
            this.txtIntervaloConfianca.TabIndex = 51;
            this.txtIntervaloConfianca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(23, 419);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(278, 25);
            this.label21.TabIndex = 50;
            this.label21.Text = "Confidence interval:";
            // 
            // Otimizacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 721);
            this.Controls.Add(this.txtIntervaloConfianca);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtCenariosSimulados);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comboTipoAleatorio);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.comboJanelaAnalise);
            this.Controls.Add(this.comboUnidadeComprimento);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtCarregamentoLimite);
            this.Controls.Add(this.comboClassesHistograma);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.comboGrandezaSaida);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboQuantidadeCargasAleatorias);
            this.Controls.Add(this.comboLimiteSuperiorPDF);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboLimiteInferiorPDF);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboPontosPDF);
            this.Controls.Add(this.checkCargasAleatorias);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkCargas);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDesvioPadraoRelativo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkTodosCondutores);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkCondutoresPermitidos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFatorCrescimentoAno5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFatorCrescimentoAno4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFatorCrescimentoAno3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFatorCrescimentoAno2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboAlgoritmo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboPDF);
            this.Controls.Add(this.txtFatorCrescimentoAno1);
            this.Controls.Add(this.Limpar);
            this.Controls.Add(this.ExecutarOtimizacao);
            this.Controls.Add(this.Sair);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Otimizacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Optimization";
            this.Load += new System.EventHandler(this.Otimizacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.Button ExecutarOtimizacao;
        private System.Windows.Forms.Button Limpar;
        private System.Windows.Forms.TextBox txtFatorCrescimentoAno1;
        private System.Windows.Forms.ComboBox comboPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboAlgoritmo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFatorCrescimentoAno2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFatorCrescimentoAno3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFatorCrescimentoAno4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFatorCrescimentoAno5;
        private System.Windows.Forms.CheckedListBox chkCondutoresPermitidos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkTodosCondutores;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDesvioPadraoRelativo;
        private System.Windows.Forms.CheckBox checkCargasAleatorias;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckedListBox chkCargas;
        private System.Windows.Forms.ComboBox comboPontosPDF;
        private System.Windows.Forms.ComboBox comboLimiteInferiorPDF;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboLimiteSuperiorPDF;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboQuantidadeCargasAleatorias;
        private System.Windows.Forms.ComboBox comboGrandezaSaida;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboClassesHistograma;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCarregamentoLimite;
        private System.Windows.Forms.ComboBox comboUnidadeComprimento;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboJanelaAnalise;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboTipoAleatorio;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtCenariosSimulados;
        private System.Windows.Forms.TextBox txtIntervaloConfianca;
        private System.Windows.Forms.Label label21;
    }
}