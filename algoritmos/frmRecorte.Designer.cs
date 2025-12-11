namespace algoritmos
{
    partial class frmRecorte
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
            this.panelRecorte = new System.Windows.Forms.Panel();
            this.cboFiguraRecorte = new System.Windows.Forms.ComboBox();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lstVerticesRecortados = new System.Windows.Forms.ListBox();
            this.lstIntersecciones = new System.Windows.Forms.ListBox();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.lblCantidadVertices = new System.Windows.Forms.Label();
            this.lblCantidadIntersecciones = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelRecorte
            // 
            this.panelRecorte.Location = new System.Drawing.Point(428, 29);
            this.panelRecorte.Name = "panelRecorte";
            this.panelRecorte.Size = new System.Drawing.Size(865, 599);
            this.panelRecorte.TabIndex = 0;
            // 
            // cboFiguraRecorte
            // 
            this.cboFiguraRecorte.FormattingEnabled = true;
            this.cboFiguraRecorte.Location = new System.Drawing.Point(28, 148);
            this.cboFiguraRecorte.Name = "cboFiguraRecorte";
            this.cboFiguraRecorte.Size = new System.Drawing.Size(351, 24);
            this.cboFiguraRecorte.TabIndex = 1;
            this.cboFiguraRecorte.SelectedIndexChanged += new System.EventHandler(this.cboFiguraRecorte_SelectedIndexChanged);
            // 
            // btnRecortar
            // 
            this.btnRecortar.Location = new System.Drawing.Point(177, 178);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(101, 50);
            this.btnRecortar.TabIndex = 2;
            this.btnRecortar.Text = "Recortar";
            this.btnRecortar.UseVisualStyleBackColor = true;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(284, 178);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(95, 50);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lstVerticesRecortados
            // 
            this.lstVerticesRecortados.FormattingEnabled = true;
            this.lstVerticesRecortados.ItemHeight = 16;
            this.lstVerticesRecortados.Location = new System.Drawing.Point(28, 303);
            this.lstVerticesRecortados.Name = "lstVerticesRecortados";
            this.lstVerticesRecortados.Size = new System.Drawing.Size(173, 180);
            this.lstVerticesRecortados.TabIndex = 4;
            // 
            // lstIntersecciones
            // 
            this.lstIntersecciones.FormattingEnabled = true;
            this.lstIntersecciones.ItemHeight = 16;
            this.lstIntersecciones.Location = new System.Drawing.Point(217, 303);
            this.lstIntersecciones.Name = "lstIntersecciones";
            this.lstIntersecciones.Size = new System.Drawing.Size(176, 180);
            this.lstIntersecciones.TabIndex = 5;
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrucciones.Location = new System.Drawing.Point(25, 111);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(100, 23);
            this.lblInstrucciones.TabIndex = 6;
            this.lblInstrucciones.Text = "label1";
            // 
            // lblCantidadVertices
            // 
            this.lblCantidadVertices.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadVertices.Location = new System.Drawing.Point(25, 277);
            this.lblCantidadVertices.Name = "lblCantidadVertices";
            this.lblCantidadVertices.Size = new System.Drawing.Size(100, 23);
            this.lblCantidadVertices.TabIndex = 7;
            this.lblCantidadVertices.Text = "label2";
            // 
            // lblCantidadIntersecciones
            // 
            this.lblCantidadIntersecciones.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadIntersecciones.Location = new System.Drawing.Point(214, 277);
            this.lblCantidadIntersecciones.Name = "lblCantidadIntersecciones";
            this.lblCantidadIntersecciones.Size = new System.Drawing.Size(100, 23);
            this.lblCantidadIntersecciones.TabIndex = 8;
            this.lblCantidadIntersecciones.Text = "label3";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 69);
            this.label1.TabIndex = 9;
            this.label1.Text = "Algoritmo de SutherlandHodgman";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRecorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1305, 657);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCantidadIntersecciones);
            this.Controls.Add(this.lblCantidadVertices);
            this.Controls.Add(this.lblInstrucciones);
            this.Controls.Add(this.lstIntersecciones);
            this.Controls.Add(this.lstVerticesRecortados);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRecortar);
            this.Controls.Add(this.cboFiguraRecorte);
            this.Controls.Add(this.panelRecorte);
            this.Name = "frmRecorte";
            this.Text = "Recorte";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRecorte;
        private System.Windows.Forms.ComboBox cboFiguraRecorte;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ListBox lstVerticesRecortados;
        private System.Windows.Forms.ListBox lstIntersecciones;
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.Label lblCantidadVertices;
        private System.Windows.Forms.Label lblCantidadIntersecciones;
        private System.Windows.Forms.Label label1;
    }
}