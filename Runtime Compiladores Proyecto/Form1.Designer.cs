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
            label1 = new Label();
            expresionRegularLabel = new Label();
            expresionPostfijaLabel = new Label();
            analizadorLexicoLabel = new Label();
            expRegularLabel = new Label();
            expPostfijaLabel = new Label();
            expresionRegularResponse = new TextBox();
            expresionPostfijaResponse = new TextBox();
            conversionButton = new Button();
            afnButton = new Button();
            tablaAFN = new DataGridView();
            nEstados = new Label();
            numeroEstados = new Label();
            nEpsilon = new Label();
            label2 = new Label();
            numeroEstadosAFD = new Label();
            nEstadosAFD = new Label();
            tablaAFD = new DataGridView();
            afdButton = new Button();
            label3 = new Label();
            button2 = new Button();
            tbLexema = new TextBox();
            lexemares = new Label();
            ((System.ComponentModel.ISupportInitialize)tablaAFN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tablaAFD).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // expresionRegularLabel
            // 
            expresionRegularLabel.Location = new Point(0, 0);
            expresionRegularLabel.Name = "expresionRegularLabel";
            expresionRegularLabel.Size = new Size(100, 23);
            expresionRegularLabel.TabIndex = 0;
            // 
            // expresionPostfijaLabel
            // 
            expresionPostfijaLabel.Location = new Point(0, 0);
            expresionPostfijaLabel.Name = "expresionPostfijaLabel";
            expresionPostfijaLabel.Size = new Size(100, 23);
            expresionPostfijaLabel.TabIndex = 0;
            // 
            // analizadorLexicoLabel
            // 
            analizadorLexicoLabel.AutoSize = true;
            analizadorLexicoLabel.Location = new Point(60, 9);
            analizadorLexicoLabel.Name = "analizadorLexicoLabel";
            analizadorLexicoLabel.Size = new Size(100, 15);
            analizadorLexicoLabel.TabIndex = 0;
            analizadorLexicoLabel.Text = "Analizador Léxico";
            // 
            // expRegularLabel
            // 
            expRegularLabel.AutoSize = true;
            expRegularLabel.Location = new Point(11, 44);
            expRegularLabel.Name = "expRegularLabel";
            expRegularLabel.Size = new Size(101, 15);
            expRegularLabel.TabIndex = 1;
            expRegularLabel.Text = "Expresión Regular";
            // 
            // expPostfijaLabel
            // 
            expPostfijaLabel.AutoSize = true;
            expPostfijaLabel.Location = new Point(11, 160);
            expPostfijaLabel.Name = "expPostfijaLabel";
            expPostfijaLabel.Size = new Size(100, 15);
            expPostfijaLabel.TabIndex = 2;
            expPostfijaLabel.Text = "Expresión Postfija";
            // 
            // expresionRegularResponse
            // 
            expresionRegularResponse.Location = new Point(14, 67);
            expresionRegularResponse.Name = "expresionRegularResponse";
            expresionRegularResponse.Size = new Size(329, 23);
            expresionRegularResponse.TabIndex = 3;
            // 
            // expresionPostfijaResponse
            // 
            expresionPostfijaResponse.Location = new Point(11, 183);
            expresionPostfijaResponse.Name = "expresionPostfijaResponse";
            expresionPostfijaResponse.Size = new Size(332, 23);
            expresionPostfijaResponse.TabIndex = 4;
            // 
            // conversionButton
            // 
            conversionButton.Location = new Point(60, 109);
            conversionButton.Name = "conversionButton";
            conversionButton.Size = new Size(217, 29);
            conversionButton.TabIndex = 5;
            conversionButton.Text = "Expresión Regular a Postfija";
            conversionButton.UseVisualStyleBackColor = true;
            conversionButton.Click += conversionButton_Click;
            // 
            // afnButton
            // 
            afnButton.Location = new Point(60, 230);
            afnButton.Name = "afnButton";
            afnButton.Size = new Size(217, 29);
            afnButton.TabIndex = 6;
            afnButton.Text = "Expresión Postfija a AFN";
            afnButton.UseVisualStyleBackColor = true;
            afnButton.Click += afnButton_Click;
            // 
            // tablaAFN
            // 
            tablaAFN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablaAFN.EditMode = DataGridViewEditMode.EditProgrammatically;
            tablaAFN.Location = new Point(14, 381);
            tablaAFN.Name = "tablaAFN";
            tablaAFN.RowHeadersWidth = 51;
            tablaAFN.Size = new Size(561, 388);
            tablaAFN.TabIndex = 7;
            // 
            // nEstados
            // 
            nEstados.AutoSize = true;
            nEstados.Location = new Point(166, 284);
            nEstados.Name = "nEstados";
            nEstados.Size = new Size(36, 15);
            nEstados.TabIndex = 9;
            nEstados.Text = "NULL";
            // 
            // numeroEstados
            // 
            numeroEstados.AutoSize = true;
            numeroEstados.Location = new Point(14, 284);
            numeroEstados.Name = "numeroEstados";
            numeroEstados.Size = new Size(116, 15);
            numeroEstados.TabIndex = 10;
            numeroEstados.Text = "Número de estados: ";
            // 
            // nEpsilon
            // 
            nEpsilon.AutoSize = true;
            nEpsilon.Location = new Point(204, 341);
            nEpsilon.Name = "nEpsilon";
            nEpsilon.Size = new Size(36, 15);
            nEpsilon.TabIndex = 11;
            nEpsilon.Text = "NULL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 341);
            label2.Name = "label2";
            label2.Size = new Size(147, 15);
            label2.TabIndex = 12;
            label2.Text = "Número de transiciones ε: ";
            // 
            // numeroEstadosAFD
            // 
            numeroEstadosAFD.AutoSize = true;
            numeroEstadosAFD.Location = new Point(610, 341);
            numeroEstadosAFD.Name = "numeroEstadosAFD";
            numeroEstadosAFD.Size = new Size(116, 15);
            numeroEstadosAFD.TabIndex = 13;
            numeroEstadosAFD.Text = "Número de estados: ";
            numeroEstadosAFD.Click += label3_Click;
            // 
            // nEstadosAFD
            // 
            nEstadosAFD.AutoSize = true;
            nEstadosAFD.Location = new Point(762, 341);
            nEstadosAFD.Name = "nEstadosAFD";
            nEstadosAFD.Size = new Size(36, 15);
            nEstadosAFD.TabIndex = 14;
            nEstadosAFD.Text = "NULL";
            // 
            // tablaAFD
            // 
            tablaAFD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablaAFD.EditMode = DataGridViewEditMode.EditProgrammatically;
            tablaAFD.Location = new Point(610, 381);
            tablaAFD.Name = "tablaAFD";
            tablaAFD.RowHeadersWidth = 51;
            tablaAFD.Size = new Size(561, 388);
            tablaAFD.TabIndex = 15;
            // 
            // afdButton
            // 
            afdButton.Location = new Point(610, 284);
            afdButton.Name = "afdButton";
            afdButton.Size = new Size(217, 29);
            afdButton.TabIndex = 16;
            afdButton.Text = "AFN a AFD";
            afdButton.UseVisualStyleBackColor = true;
            afdButton.Click += afdButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(610, 44);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 17;
            label3.Text = "Lexema:";
            // 
            // button2
            // 
            button2.Location = new Point(982, 67);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 18;
            button2.Text = "Validar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tbLexema
            // 
            tbLexema.Location = new Point(610, 67);
            tbLexema.Name = "tbLexema";
            tbLexema.Size = new Size(366, 23);
            tbLexema.TabIndex = 19;
            // 
            // lexemares
            // 
            lexemares.AutoSize = true;
            lexemares.Location = new Point(610, 109);
            lexemares.Name = "lexemares";
            lexemares.Size = new Size(0, 15);
            lexemares.TabIndex = 20;
            // 
            // Form1
            // 
            ClientSize = new Size(1189, 814);
            Controls.Add(lexemares);
            Controls.Add(tbLexema);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(afdButton);
            Controls.Add(tablaAFD);
            Controls.Add(nEstadosAFD);
            Controls.Add(numeroEstadosAFD);
            Controls.Add(label2);
            Controls.Add(nEpsilon);
            Controls.Add(numeroEstados);
            Controls.Add(nEstados);
            Controls.Add(tablaAFN);
            Controls.Add(afnButton);
            Controls.Add(conversionButton);
            Controls.Add(expresionPostfijaResponse);
            Controls.Add(expresionRegularResponse);
            Controls.Add(expPostfijaLabel);
            Controls.Add(expRegularLabel);
            Controls.Add(analizadorLexicoLabel);
            Name = "Form1";
            Text = "Compilador";
            Load += Compilador_Load;
            ((System.ComponentModel.ISupportInitialize)tablaAFN).EndInit();
            ((System.ComponentModel.ISupportInitialize)tablaAFD).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}