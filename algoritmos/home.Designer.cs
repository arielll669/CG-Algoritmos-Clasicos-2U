namespace algoritmos
{
    partial class home
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.algoritmosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoMedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenoCircunferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floodFillRecursivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boundaryFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floodFillRecursivoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.recorteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorteDeLíneasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sutherlandHodgmanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algoritmosToolStripMenuItem,
            this.rellenoCircunferenciaToolStripMenuItem,
            this.recorteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // algoritmosToolStripMenuItem
            // 
            this.algoritmosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDAToolStripMenuItem,
            this.bresenhanToolStripMenuItem,
            this.puntoMedioToolStripMenuItem});
            this.algoritmosToolStripMenuItem.Name = "algoritmosToolStripMenuItem";
            this.algoritmosToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.algoritmosToolStripMenuItem.Text = "Algoritmos";
            // 
            // dDAToolStripMenuItem
            // 
            this.dDAToolStripMenuItem.Name = "dDAToolStripMenuItem";
            this.dDAToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.dDAToolStripMenuItem.Text = "DDA";
            this.dDAToolStripMenuItem.Click += new System.EventHandler(this.dDAToolStripMenuItem_Click);
            // 
            // bresenhanToolStripMenuItem
            // 
            this.bresenhanToolStripMenuItem.Name = "bresenhanToolStripMenuItem";
            this.bresenhanToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.bresenhanToolStripMenuItem.Text = "Bresenhan";
            this.bresenhanToolStripMenuItem.Click += new System.EventHandler(this.bresenhanToolStripMenuItem_Click);
            // 
            // puntoMedioToolStripMenuItem
            // 
            this.puntoMedioToolStripMenuItem.Name = "puntoMedioToolStripMenuItem";
            this.puntoMedioToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.puntoMedioToolStripMenuItem.Text = "Punto medio";
            this.puntoMedioToolStripMenuItem.Click += new System.EventHandler(this.puntoMedioToolStripMenuItem_Click);
            // 
            // rellenoCircunferenciaToolStripMenuItem
            // 
            this.rellenoCircunferenciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.floodFillRecursivoToolStripMenuItem,
            this.boundaryFillToolStripMenuItem,
            this.floodFillRecursivoToolStripMenuItem1});
            this.rellenoCircunferenciaToolStripMenuItem.Name = "rellenoCircunferenciaToolStripMenuItem";
            this.rellenoCircunferenciaToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.rellenoCircunferenciaToolStripMenuItem.Text = "Relleno Circunferencia";
            // 
            // floodFillRecursivoToolStripMenuItem
            // 
            this.floodFillRecursivoToolStripMenuItem.Name = "floodFillRecursivoToolStripMenuItem";
            this.floodFillRecursivoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.floodFillRecursivoToolStripMenuItem.Text = "Flood Fill Recursivo";
            this.floodFillRecursivoToolStripMenuItem.Click += new System.EventHandler(this.floodFillRecursivoToolStripMenuItem_Click);
            // 
            // boundaryFillToolStripMenuItem
            // 
            this.boundaryFillToolStripMenuItem.Name = "boundaryFillToolStripMenuItem";
            this.boundaryFillToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.boundaryFillToolStripMenuItem.Text = "Boundary Fill";
            this.boundaryFillToolStripMenuItem.Click += new System.EventHandler(this.boundaryFillToolStripMenuItem_Click);
            // 
            // floodFillRecursivoToolStripMenuItem1
            // 
            this.floodFillRecursivoToolStripMenuItem1.Name = "floodFillRecursivoToolStripMenuItem1";
            this.floodFillRecursivoToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.floodFillRecursivoToolStripMenuItem1.Text = "Flood Fill Recursivo";
            this.floodFillRecursivoToolStripMenuItem1.Click += new System.EventHandler(this.floodFillRecursivoToolStripMenuItem1_Click);
            // 
            // recorteToolStripMenuItem
            // 
            this.recorteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recorteDeLíneasToolStripMenuItem1,
            this.sutherlandHodgmanToolStripMenuItem1});
            this.recorteToolStripMenuItem.Name = "recorteToolStripMenuItem";
            this.recorteToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.recorteToolStripMenuItem.Text = "Recorte";
            // 
            // recorteDeLíneasToolStripMenuItem1
            // 
            this.recorteDeLíneasToolStripMenuItem1.Name = "recorteDeLíneasToolStripMenuItem1";
            this.recorteDeLíneasToolStripMenuItem1.Size = new System.Drawing.Size(234, 26);
            this.recorteDeLíneasToolStripMenuItem1.Text = "Recorte de líneas";
            this.recorteDeLíneasToolStripMenuItem1.Click += new System.EventHandler(this.recorteDeLíneasToolStripMenuItem1_Click);
            // 
            // sutherlandHodgmanToolStripMenuItem1
            // 
            this.sutherlandHodgmanToolStripMenuItem1.Name = "sutherlandHodgmanToolStripMenuItem1";
            this.sutherlandHodgmanToolStripMenuItem1.Size = new System.Drawing.Size(234, 26);
            this.sutherlandHodgmanToolStripMenuItem1.Text = "Sutherland Hodgman";
            this.sutherlandHodgmanToolStripMenuItem1.Click += new System.EventHandler(this.sutherlandHodgmanToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Taller";
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "home";
            this.Text = "Home";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem algoritmosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoMedioToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem rellenoCircunferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floodFillRecursivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boundaryFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floodFillRecursivoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem recorteDeLíneasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sutherlandHodgmanToolStripMenuItem1;
    }
}

