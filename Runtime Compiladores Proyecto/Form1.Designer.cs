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
            this.conversionButton.Location = new System.Drawing.Point(126, 109);
            this.conversionButton.Name = "conversionButton";
            this.conversionButton.Size = new System.Drawing.Size(217, 29);
            this.conversionButton.TabIndex = 5;
            this.conversionButton.Text = "Expresión Regular a Postfija";
            this.conversionButton.UseVisualStyleBackColor = true;
            this.conversionButton.Click += new System.EventHandler(this.conversionButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1096, 477);
            this.Controls.Add(this.conversionButton);
            this.Controls.Add(this.expresionPostfijaResponse);
            this.Controls.Add(this.expresionRegularResponse);
            this.Controls.Add(this.expPostfijaLabel);
            this.Controls.Add(this.expRegularLabel);
            this.Controls.Add(this.analizadorLexicoLabel);
            this.Name = "Form1";
            this.Text = "Compilador";
            this.Load += new System.EventHandler(this.Compilador_Load);
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
    }
}