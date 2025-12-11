namespace algoritmos
{
    partial class frmPuntoMedio
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.grbGafico = new System.Windows.Forms.GroupBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grbEntradas = new System.Windows.Forms.GroupBox();
            this.txtYf = new System.Windows.Forms.TextBox();
            this.txtXf = new System.Windows.Forms.TextBox();
            this.txtYo = new System.Windows.Forms.TextBox();
            this.txtXo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblXo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grbGafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.grbEntradas.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCalcular);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnResetear);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.groupBox1.Location = new System.Drawing.Point(20, 463);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(204, 210);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(45, 38);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(100, 34);
            this.btnCalcular.TabIndex = 1;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(45, 156);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 34);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnResetear
            // 
            this.btnResetear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetear.Location = new System.Drawing.Point(45, 100);
            this.btnResetear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(100, 34);
            this.btnResetear.TabIndex = 5;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            // 
            // grbGafico
            // 
            this.grbGafico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbGafico.Controls.Add(this.picCanvas);
            this.grbGafico.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGafico.Location = new System.Drawing.Point(242, 23);
            this.grbGafico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbGafico.Name = "grbGafico";
            this.grbGafico.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbGafico.Size = new System.Drawing.Size(997, 686);
            this.grbGafico.TabIndex = 17;
            this.grbGafico.TabStop = false;
            this.grbGafico.Text = "Grafica";
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.picCanvas.Location = new System.Drawing.Point(19, 27);
            this.picCanvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(960, 640);
            this.picCanvas.TabIndex = 3;
            this.picCanvas.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.Location = new System.Drawing.Point(16, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 78);
            this.label5.TabIndex = 16;
            this.label5.Text = "Algoritmo \r\nPunto Medio";
            // 
            // grbEntradas
            // 
            this.grbEntradas.Controls.Add(this.txtYf);
            this.grbEntradas.Controls.Add(this.txtXf);
            this.grbEntradas.Controls.Add(this.txtYo);
            this.grbEntradas.Controls.Add(this.txtXo);
            this.grbEntradas.Controls.Add(this.label4);
            this.grbEntradas.Controls.Add(this.label3);
            this.grbEntradas.Controls.Add(this.label2);
            this.grbEntradas.Controls.Add(this.lblXo);
            this.grbEntradas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbEntradas.Location = new System.Drawing.Point(20, 121);
            this.grbEntradas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbEntradas.Name = "grbEntradas";
            this.grbEntradas.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbEntradas.Size = new System.Drawing.Size(204, 321);
            this.grbEntradas.TabIndex = 15;
            this.grbEntradas.TabStop = false;
            this.grbEntradas.Text = "Puntos de entrada";
            // 
            // txtYf
            // 
            this.txtYf.Location = new System.Drawing.Point(56, 276);
            this.txtYf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtYf.Name = "txtYf";
            this.txtYf.Size = new System.Drawing.Size(130, 30);
            this.txtYf.TabIndex = 7;
            // 
            // txtXf
            // 
            this.txtXf.Location = new System.Drawing.Point(56, 202);
            this.txtXf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtXf.Name = "txtXf";
            this.txtXf.Size = new System.Drawing.Size(130, 30);
            this.txtXf.TabIndex = 6;
            // 
            // txtYo
            // 
            this.txtYo.Location = new System.Drawing.Point(56, 130);
            this.txtYo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtYo.Name = "txtYo";
            this.txtYo.Size = new System.Drawing.Size(130, 30);
            this.txtYo.TabIndex = 5;
            // 
            // txtXo
            // 
            this.txtXo.Location = new System.Drawing.Point(56, 63);
            this.txtXo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtXo.Name = "txtXo";
            this.txtXo.Size = new System.Drawing.Size(130, 30);
            this.txtXo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ingrese Yf:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ingrese Xf:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingrese Yo:";
            // 
            // lblXo
            // 
            this.lblXo.AutoSize = true;
            this.lblXo.Location = new System.Drawing.Point(15, 39);
            this.lblXo.Name = "lblXo";
            this.lblXo.Size = new System.Drawing.Size(102, 22);
            this.lblXo.TabIndex = 0;
            this.lblXo.Text = "Ingrese Xo:";
            // 
            // frmPuntoMedio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1343, 766);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbGafico);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grbEntradas);
            this.Name = "frmPuntoMedio";
            this.Text = "puntoMedio";
            this.groupBox1.ResumeLayout(false);
            this.grbGafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.grbEntradas.ResumeLayout(false);
            this.grbEntradas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.GroupBox grbGafico;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbEntradas;
        private System.Windows.Forms.TextBox txtYf;
        private System.Windows.Forms.TextBox txtXf;
        private System.Windows.Forms.TextBox txtYo;
        private System.Windows.Forms.TextBox txtXo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblXo;
    }
}