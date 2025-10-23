namespace Reelnode
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DataGridSeries = new System.Windows.Forms.DataGridView();
            this.PanelListar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelListar
            // 
            this.PanelListar.BackColor = System.Drawing.Color.Transparent;
            this.PanelListar.Controls.Add(this.panel1);
            this.PanelListar.Controls.Add(this.panel3);
            this.PanelListar.Controls.Add(this.DataGridSeries);
            this.PanelListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelListar.Location = new System.Drawing.Point(0, 0);
            this.PanelListar.Name = "PanelListar";
            this.PanelListar.Size = new System.Drawing.Size(1280, 720);
            this.PanelListar.TabIndex = 1;
            this.PanelListar.Tag = "Default";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(117, 551);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 2);
            this.panel1.TabIndex = 50;
            this.panel1.Tag = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.panel3.Location = new System.Drawing.Point(117, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1081, 2);
            this.panel3.TabIndex = 50;
            this.panel3.Tag = "";
            // 
            // DataGridSeries
            // 
            this.DataGridSeries.AllowUserToAddRows = false;
            this.DataGridSeries.AllowUserToDeleteRows = false;
            this.DataGridSeries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridSeries.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(43)))));
            this.DataGridSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridSeries.Location = new System.Drawing.Point(231, 150);
            this.DataGridSeries.Name = "DataGridSeries";
            this.DataGridSeries.ReadOnly = true;
            this.DataGridSeries.RowHeadersVisible = false;
            this.DataGridSeries.RowHeadersWidth = 51;
            this.DataGridSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridSeries.Size = new System.Drawing.Size(791, 316);
            this.DataGridSeries.TabIndex = 2;
            // 
            // ControlGestionSeriesListarSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PanelListar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlGestionSeriesListarSeries";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Load += new System.EventHandler(this.ControlGestionSeriesListarSeries_Load);
            this.PanelListar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSeries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelListar;
        private System.Windows.Forms.DataGridView DataGridSeries;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
    }
}
