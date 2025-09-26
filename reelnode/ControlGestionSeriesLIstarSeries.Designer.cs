namespace ProjectoNuevo
{
    partial class ControlGestionSeriesListarSeries
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelListar = new System.Windows.Forms.Panel();
            this.DataGridSeries = new System.Windows.Forms.DataGridView();
            this.PanelListar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelListar
            // 
            this.PanelListar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(55)))), ((int)(((byte)(82)))));
            this.PanelListar.Controls.Add(this.DataGridSeries);
            this.PanelListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelListar.Location = new System.Drawing.Point(0, 0);
            this.PanelListar.Margin = new System.Windows.Forms.Padding(4);
            this.PanelListar.Name = "PanelListar";
            this.PanelListar.Size = new System.Drawing.Size(1327, 833);
            this.PanelListar.TabIndex = 1;
            // 
            // DataGridSeries
            // 
            this.DataGridSeries.AllowUserToAddRows = false;
            this.DataGridSeries.AllowUserToDeleteRows = false;
            this.DataGridSeries.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(43)))));
            this.DataGridSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridSeries.Location = new System.Drawing.Point(140, 25);
            this.DataGridSeries.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridSeries.Name = "DataGridSeries";
            this.DataGridSeries.ReadOnly = true;
            this.DataGridSeries.RowHeadersVisible = false;
            this.DataGridSeries.RowHeadersWidth = 51;
            this.DataGridSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridSeries.Size = new System.Drawing.Size(911, 283);
            this.DataGridSeries.TabIndex = 2;
            // 
            // ControlGestionSeriesListarSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelListar);
            this.Name = "ControlGestionSeriesListarSeries";
            this.Size = new System.Drawing.Size(1327, 833);
            this.PanelListar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSeries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelListar;
        private System.Windows.Forms.DataGridView DataGridSeries;
    }
}
