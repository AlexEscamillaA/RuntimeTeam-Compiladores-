namespace Runtime_Compiladores_Proyecto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.expresionRegularLabel = new System.Windows.Forms.Label();
            this.expresionPostfijaLabel = new System.Windows.Forms.Label();
            this.analizadorLexicoLabel = new System.Windows.Forms.Label();
            this.expRegularLabel = new System.Windows.Forms.Label();
            this.expPostfijaLabel = new System.Windows.Forms.Label();
            this.expresionRegularResponse = new System.Windows.Forms.TextBox();
            this.expresionPostfijaResponse = new System.Windows.Forms.TextBox();
            this.conversionButton = new System.Windows.Forms.Button();
            this.afnButton = new System.Windows.Forms.Button();
            this.tablaAFN = new System.Windows.Forms.DataGridView();
            this.nEstados = new System.Windows.Forms.Label();
            this.numeroEstados = new System.Windows.Forms.Label();
            this.nEpsilon = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numeroEstadosAFD = new System.Windows.Forms.Label();
            this.nEstadosAFD = new System.Windows.Forms.Label();
            this.tablaAFD = new System.Windows.Forms.DataGridView();
            this.afdButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tbLexema = new System.Windows.Forms.TextBox();
            this.lexemares = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.identificadorBox = new System.Windows.Forms.TextBox();
            this.numeroBox = new System.Windows.Forms.TextBox();
            this.programaBox = new System.Windows.Forms.TextBox();
            this.tablaTokens = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clasificarBoton = new System.Windows.Forms.Button();
            this.construirTablaM = new System.Windows.Forms.Button();
            this.tablaAnalisis = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAFN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAFD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAnalisis)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // expresionRegularLabel
            // 
            this.expresionRegularLabel.Location = new System.Drawing.Point(0, 0);
            this.expresionRegularLabel.Name = "expresionRegularLabel";
            this.expresionRegularLabel.Size = new System.Drawing.Size(100, 23);
            this.expresionRegularLabel.TabIndex = 0;
            // 
            // expresionPostfijaLabel
            // 
            this.expresionPostfijaLabel.Location = new System.Drawing.Point(0, 0);
            this.expresionPostfijaLabel.Name = "expresionPostfijaLabel";
            this.expresionPostfijaLabel.Size = new System.Drawing.Size(100, 23);
            this.expresionPostfijaLabel.TabIndex = 0;
            // 
            // analizadorLexicoLabel
            // 
            this.analizadorLexicoLabel.AutoSize = true;
            this.analizadorLexicoLabel.Location = new System.Drawing.Point(60, 9);
            this.analizadorLexicoLabel.Name = "analizadorLexicoLabel";
            this.analizadorLexicoLabel.Size = new System.Drawing.Size(127, 20);
            this.analizadorLexicoLabel.TabIndex = 0;
            this.analizadorLexicoLabel.Text = "Analizador Léxico";
            // 
            // expRegularLabel
            // 
            this.expRegularLabel.AutoSize = true;
            this.expRegularLabel.Location = new System.Drawing.Point(11, 44);
            this.expRegularLabel.Name = "expRegularLabel";
            this.expRegularLabel.Size = new System.Drawing.Size(128, 20);
            this.expRegularLabel.TabIndex = 1;
            this.expRegularLabel.Text = "Expresión Regular";
            // 
            // expPostfijaLabel
            // 
            this.expPostfijaLabel.AutoSize = true;
            this.expPostfijaLabel.Location = new System.Drawing.Point(11, 160);
            this.expPostfijaLabel.Name = "expPostfijaLabel";
            this.expPostfijaLabel.Size = new System.Drawing.Size(125, 20);
            this.expPostfijaLabel.TabIndex = 2;
            this.expPostfijaLabel.Text = "Expresión Postfija";
            // 
            // expresionRegularResponse
            // 
            this.expresionRegularResponse.Location = new System.Drawing.Point(14, 67);
            this.expresionRegularResponse.Name = "expresionRegularResponse";
            this.expresionRegularResponse.Size = new System.Drawing.Size(329, 27);
            this.expresionRegularResponse.TabIndex = 3;
            // 
            // expresionPostfijaResponse
            // 
            this.expresionPostfijaResponse.Location = new System.Drawing.Point(11, 183);
            this.expresionPostfijaResponse.Name = "expresionPostfijaResponse";
            this.expresionPostfijaResponse.Size = new System.Drawing.Size(332, 27);
            this.expresionPostfijaResponse.TabIndex = 4;
            // 
            // conversionButton
            // 
            this.conversionButton.Location = new System.Drawing.Point(60, 109);
            this.conversionButton.Name = "conversionButton";
            this.conversionButton.Size = new System.Drawing.Size(217, 29);
            this.conversionButton.TabIndex = 5;
            this.conversionButton.Text = "Expresión Regular a Postfija";
            this.conversionButton.UseVisualStyleBackColor = true;
            this.conversionButton.Click += new System.EventHandler(this.conversionButton_Click_1);
            // 
            // afnButton
            // 
            this.afnButton.Location = new System.Drawing.Point(60, 230);
            this.afnButton.Name = "afnButton";
            this.afnButton.Size = new System.Drawing.Size(217, 29);
            this.afnButton.TabIndex = 6;
            this.afnButton.Text = "Expresión Postfija a AFN";
            this.afnButton.UseVisualStyleBackColor = true;
            this.afnButton.Click += new System.EventHandler(this.afnButton_Click_1);
            // 
            // tablaAFN
            // 
            this.tablaAFN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaAFN.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tablaAFN.Location = new System.Drawing.Point(14, 381);
            this.tablaAFN.Name = "tablaAFN";
            this.tablaAFN.RowHeadersWidth = 51;
            this.tablaAFN.Size = new System.Drawing.Size(561, 388);
            this.tablaAFN.TabIndex = 7;
            // 
            // nEstados
            // 
            this.nEstados.AutoSize = true;
            this.nEstados.Location = new System.Drawing.Point(166, 284);
            this.nEstados.Name = "nEstados";
            this.nEstados.Size = new System.Drawing.Size(44, 20);
            this.nEstados.TabIndex = 9;
            this.nEstados.Text = "NULL";
            // 
            // numeroEstados
            // 
            this.numeroEstados.AutoSize = true;
            this.numeroEstados.Location = new System.Drawing.Point(14, 284);
            this.numeroEstados.Name = "numeroEstados";
            this.numeroEstados.Size = new System.Drawing.Size(146, 20);
            this.numeroEstados.TabIndex = 10;
            this.numeroEstados.Text = "Número de estados: ";
            // 
            // nEpsilon
            // 
            this.nEpsilon.AutoSize = true;
            this.nEpsilon.Location = new System.Drawing.Point(204, 341);
            this.nEpsilon.Name = "nEpsilon";
            this.nEpsilon.Size = new System.Drawing.Size(44, 20);
            this.nEpsilon.TabIndex = 11;
            this.nEpsilon.Text = "NULL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Número de transiciones ε: ";
            // 
            // numeroEstadosAFD
            // 
            this.numeroEstadosAFD.AutoSize = true;
            this.numeroEstadosAFD.Location = new System.Drawing.Point(610, 341);
            this.numeroEstadosAFD.Name = "numeroEstadosAFD";
            this.numeroEstadosAFD.Size = new System.Drawing.Size(146, 20);
            this.numeroEstadosAFD.TabIndex = 13;
            this.numeroEstadosAFD.Text = "Número de estados: ";
            // 
            // nEstadosAFD
            // 
            this.nEstadosAFD.AutoSize = true;
            this.nEstadosAFD.Location = new System.Drawing.Point(762, 341);
            this.nEstadosAFD.Name = "nEstadosAFD";
            this.nEstadosAFD.Size = new System.Drawing.Size(44, 20);
            this.nEstadosAFD.TabIndex = 14;
            this.nEstadosAFD.Text = "NULL";
            // 
            // tablaAFD
            // 
            this.tablaAFD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaAFD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tablaAFD.Location = new System.Drawing.Point(610, 381);
            this.tablaAFD.Name = "tablaAFD";
            this.tablaAFD.RowHeadersWidth = 51;
            this.tablaAFD.Size = new System.Drawing.Size(561, 388);
            this.tablaAFD.TabIndex = 15;
            // 
            // afdButton
            // 
            this.afdButton.Location = new System.Drawing.Point(610, 284);
            this.afdButton.Name = "afdButton";
            this.afdButton.Size = new System.Drawing.Size(217, 29);
            this.afdButton.TabIndex = 16;
            this.afdButton.Text = "AFN a AFD";
            this.afdButton.UseVisualStyleBackColor = true;
            this.afdButton.Click += new System.EventHandler(this.afdButton_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(610, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Lexema:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(982, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 18;
            this.button2.Text = "Validar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tbLexema
            // 
            this.tbLexema.Location = new System.Drawing.Point(610, 67);
            this.tbLexema.Name = "tbLexema";
            this.tbLexema.Size = new System.Drawing.Size(366, 27);
            this.tbLexema.TabIndex = 19;
            // 
            // lexemares
            // 
            this.lexemares.AutoSize = true;
            this.lexemares.Location = new System.Drawing.Point(610, 109);
            this.lexemares.Name = "lexemares";
            this.lexemares.Size = new System.Drawing.Size(0, 20);
            this.lexemares.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1207, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Identificador:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1207, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Número:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1207, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Programa en TINY:";
            // 
            // identificadorBox
            // 
            this.identificadorBox.Location = new System.Drawing.Point(1310, 37);
            this.identificadorBox.Name = "identificadorBox";
            this.identificadorBox.Size = new System.Drawing.Size(325, 27);
            this.identificadorBox.TabIndex = 24;
            // 
            // numeroBox
            // 
            this.numeroBox.Location = new System.Drawing.Point(1310, 83);
            this.numeroBox.Name = "numeroBox";
            this.numeroBox.Size = new System.Drawing.Size(325, 27);
            this.numeroBox.TabIndex = 25;
            // 
            // programaBox
            // 
            this.programaBox.Location = new System.Drawing.Point(1207, 160);
            this.programaBox.Multiline = true;
            this.programaBox.Name = "programaBox";
            this.programaBox.Size = new System.Drawing.Size(428, 201);
            this.programaBox.TabIndex = 26;
            // 
            // tablaTokens
            // 
            this.tablaTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6});
            this.tablaTokens.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tablaTokens.Location = new System.Drawing.Point(1207, 381);
            this.tablaTokens.Name = "tablaTokens";
            this.tablaTokens.RowHeadersWidth = 51;
            this.tablaTokens.Size = new System.Drawing.Size(428, 388);
            this.tablaTokens.TabIndex = 27;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Nombre";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Lexema";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // clasificarBoton
            // 
            this.clasificarBoton.Location = new System.Drawing.Point(1418, 124);
            this.clasificarBoton.Name = "clasificarBoton";
            this.clasificarBoton.Size = new System.Drawing.Size(217, 29);
            this.clasificarBoton.TabIndex = 28;
            this.clasificarBoton.Text = "Clasificar tokens";
            this.clasificarBoton.UseVisualStyleBackColor = true;
            this.clasificarBoton.Click += new System.EventHandler(this.clasificarBoton_Click);
            // 
            // construirTablaM
            // 
            this.construirTablaM.Location = new System.Drawing.Point(1685, 86);
            this.construirTablaM.Name = "construirTablaM";
            this.construirTablaM.Size = new System.Drawing.Size(428, 29);
            this.construirTablaM.TabIndex = 29;
            this.construirTablaM.Text = "Construir Tabla de Análisis Sintáctico M";
            this.construirTablaM.UseVisualStyleBackColor = true;
            this.construirTablaM.Click += new System.EventHandler(this.construirTablaM_Click);
            // 
            // tablaAnalisis
            // 
            this.tablaAnalisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaAnalisis.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tablaAnalisis.Location = new System.Drawing.Point(1685, 160);
            this.tablaAnalisis.Name = "tablaAnalisis";
            this.tablaAnalisis.RowHeadersWidth = 51;
            this.tablaAnalisis.Size = new System.Drawing.Size(428, 491);
            this.tablaAnalisis.TabIndex = 30;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(2202, 814);
            this.Controls.Add(this.tablaAnalisis);
            this.Controls.Add(this.construirTablaM);
            this.Controls.Add(this.clasificarBoton);
            this.Controls.Add(this.tablaTokens);
            this.Controls.Add(this.programaBox);
            this.Controls.Add(this.numeroBox);
            this.Controls.Add(this.identificadorBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lexemares);
            this.Controls.Add(this.tbLexema);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.afdButton);
            this.Controls.Add(this.tablaAFD);
            this.Controls.Add(this.nEstadosAFD);
            this.Controls.Add(this.numeroEstadosAFD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nEpsilon);
            this.Controls.Add(this.numeroEstados);
            this.Controls.Add(this.nEstados);
            this.Controls.Add(this.tablaAFN);
            this.Controls.Add(this.afnButton);
            this.Controls.Add(this.conversionButton);
            this.Controls.Add(this.expresionPostfijaResponse);
            this.Controls.Add(this.expresionRegularResponse);
            this.Controls.Add(this.expPostfijaLabel);
            this.Controls.Add(this.expRegularLabel);
            this.Controls.Add(this.analizadorLexicoLabel);
            this.Name = "Form1";
            this.Text = "Compilador";
            ((System.ComponentModel.ISupportInitialize)(this.tablaAFN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAFD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAnalisis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label expresionRegularLabel;
        private Label expresionPostfijaLabel;
        private TextBox expresionRegular;
        private TextBox expresionPostfija;
        private Button boton_calcular_posfija;
        private Label analizadorLexicoLabel;
        private Label expRegularLabel;
        private Label expPostfijaLabel;
        private TextBox expresionRegularResponse;
        private TextBox expresionPostfijaResponse;
        private Button conversionButton;
        private Button afnButton;
        private DataGridView tablaAFN;
        private Label nEstados;
        private Label numeroEstados;
        private Label nEpsilon;
        private Label label2;
        private Label numeroEstadosAFD;
        private Label nEstadosAFD;
        private DataGridView tablaAFD;
        private Button afdButton;
        private Label label3;
        private Button button2;
        private TextBox tbLexema;
        private Label lexemares;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox identificadorBox;
        private TextBox numeroBox;
        private TextBox programaBox;
        private DataGridView tablaTokens;
        private Button clasificarBoton;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private Button construirTablaM;
        private DataGridView tablaAnalisis;
    }
}