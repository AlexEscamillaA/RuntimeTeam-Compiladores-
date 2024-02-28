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
            ((System.ComponentModel.ISupportInitialize)(this.tablaAFN)).BeginInit();
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
            this.conversionButton.Location = new System.Drawing.Point(60, 111);
            this.conversionButton.Name = "conversionButton";
            this.conversionButton.Size = new System.Drawing.Size(217, 29);
            this.conversionButton.TabIndex = 5;
            this.conversionButton.Text = "Expresión Regular a Postfija";
            this.conversionButton.UseVisualStyleBackColor = true;
            this.conversionButton.Click += new System.EventHandler(this.conversionButton_Click);
            // 
            // afnButton
            // 
            this.afnButton.Location = new System.Drawing.Point(60, 231);
            this.afnButton.Name = "afnButton";
            this.afnButton.Size = new System.Drawing.Size(217, 29);
            this.afnButton.TabIndex = 6;
            this.afnButton.Text = "Expresión Postfija a AFN";
            this.afnButton.UseVisualStyleBackColor = true;
            this.afnButton.Click += new System.EventHandler(this.afnButton_Click);
            // 
            // tablaAFN
            // 
            this.tablaAFN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaAFN.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tablaAFN.Location = new System.Drawing.Point(386, 12);
            this.tablaAFN.Name = "tablaAFN";
            this.tablaAFN.RowHeadersWidth = 51;
            this.tablaAFN.Size = new System.Drawing.Size(561, 388);
            this.tablaAFN.TabIndex = 7;
            // 
            // nEstados
            // 
            this.nEstados.AutoSize = true;
            this.nEstados.Location = new System.Drawing.Point(178, 284);
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
            this.nEpsilon.Location = new System.Drawing.Point(213, 341);
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
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(987, 525);
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
            this.Load += new System.EventHandler(this.Compilador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaAFN)).EndInit();
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
    }
}