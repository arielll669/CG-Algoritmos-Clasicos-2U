namespace algoritmos
{
    partial class frmPoligonoRelleno
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstPixeles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBoundaryFill = new System.Windows.Forms.Button();
            this.btnFloodFill = new System.Windows.Forms.Button();
            this.btnFloodFillIterativo = new System.Windows.Forms.Button();
            this.panelPoligono = new System.Windows.Forms.Panel();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.lblCantidadPixeles = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstPixeles);
            this.groupBox3.Location = new System.Drawing.Point(12, 411);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 282);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista de píxeles";
            // 
            // lstPixeles
            // 
            this.lstPixeles.FormattingEnabled = true;
            this.lstPixeles.ItemHeight = 16;
            this.lstPixeles.Location = new System.Drawing.Point(6, 32);
            this.lstPixeles.Name = "lstPixeles";
            this.lstPixeles.Size = new System.Drawing.Size(336, 244);
            this.lstPixeles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 82);
            this.label1.TabIndex = 8;
            this.label1.Text = "Algoritmo de recorte de líneas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Location = new System.Drawing.Point(12, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Funciones";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(120, 41);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(111, 43);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBoundaryFill);
            this.groupBox1.Controls.Add(this.btnFloodFill);
            this.groupBox1.Controls.Add(this.btnFloodFillIterativo);
            this.groupBox1.Location = new System.Drawing.Point(12, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 110);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Métodos de relleno";
            // 
            // btnBoundaryFill
            // 
            this.btnBoundaryFill.Location = new System.Drawing.Point(130, 40);
            this.btnBoundaryFill.Name = "btnBoundaryFill";
            this.btnBoundaryFill.Size = new System.Drawing.Size(90, 41);
            this.btnBoundaryFill.TabIndex = 2;
            this.btnBoundaryFill.Text = "Boundary Fill";
            this.btnBoundaryFill.UseVisualStyleBackColor = true;
            this.btnBoundaryFill.Click += new System.EventHandler(this.btnBoundaryFill_Click);
            // 
            // btnFloodFill
            // 
            this.btnFloodFill.Location = new System.Drawing.Point(24, 40);
            this.btnFloodFill.Name = "btnFloodFill";
            this.btnFloodFill.Size = new System.Drawing.Size(84, 41);
            this.btnFloodFill.TabIndex = 1;
            this.btnFloodFill.Text = "Flood Fill Recursivo";
            this.btnFloodFill.UseVisualStyleBackColor = true;
            this.btnFloodFill.Click += new System.EventHandler(this.btnFloodFillRecursivo_Click);
            // 
            // btnFloodFillIterativo
            // 
            this.btnFloodFillIterativo.Location = new System.Drawing.Point(241, 40);
            this.btnFloodFillIterativo.Name = "btnFloodFillIterativo";
            this.btnFloodFillIterativo.Size = new System.Drawing.Size(87, 41);
            this.btnFloodFillIterativo.TabIndex = 0;
            this.btnFloodFillIterativo.Text = "Flood Fill Iterativo";
            this.btnFloodFillIterativo.UseVisualStyleBackColor = true;
            this.btnFloodFillIterativo.Click += new System.EventHandler(this.btnFloodFillIterativo_Click);
            // 
            // panelPoligono
            // 
            this.panelPoligono.Location = new System.Drawing.Point(397, 22);
            this.panelPoligono.Name = "panelPoligono";
            this.panelPoligono.Size = new System.Drawing.Size(946, 725);
            this.panelPoligono.TabIndex = 5;
            this.panelPoligono.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPoligono_MouseClick);
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.AutoSize = true;
            this.lblInstrucciones.Location = new System.Drawing.Point(15, 717);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(44, 16);
            this.lblInstrucciones.TabIndex = 10;
            this.lblInstrucciones.Text = "label2";
            // 
            // lblCantidadPixeles
            // 
            this.lblCantidadPixeles.AutoSize = true;
            this.lblCantidadPixeles.Location = new System.Drawing.Point(15, 745);
            this.lblCantidadPixeles.Name = "lblCantidadPixeles";
            this.lblCantidadPixeles.Size = new System.Drawing.Size(44, 16);
            this.lblCantidadPixeles.TabIndex = 11;
            this.lblCantidadPixeles.Text = "label3";
            // 
            // frmPoligonoRelleno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1368, 947);
            this.Controls.Add(this.lblCantidadPixeles);
            this.Controls.Add(this.lblInstrucciones);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelPoligono);
            this.Name = "frmPoligonoRelleno";
            this.Text = "frmPoligonoRelleno";
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstPixeles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBoundaryFill;
        private System.Windows.Forms.Button btnFloodFill;
        private System.Windows.Forms.Button btnFloodFillIterativo;
        private System.Windows.Forms.Panel panelPoligono;
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.Label lblCantidadPixeles;
    }
}