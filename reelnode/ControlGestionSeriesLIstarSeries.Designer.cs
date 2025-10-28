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
            this.BtnExportarJSON = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DataGridSeries = new System.Windows.Forms.DataGridView();
            this.BtnImportarSeriesJSON = new System.Windows.Forms.Button();
            this.PanelListar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelListar
            // 
            this.PanelListar.BackColor = System.Drawing.Color.Transparent;
            this.PanelListar.Controls.Add(this.BtnImportarSeriesJSON);
            this.PanelListar.Controls.Add(this.BtnExportarJSON);
            this.PanelListar.Controls.Add(this.panel1);
            this.PanelListar.Controls.Add(this.panel3);
            this.PanelListar.Controls.Add(this.DataGridSeries);
            this.PanelListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelListar.Location = new System.Drawing.Point(0, 0);
            this.PanelListar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelListar.Name = "PanelListar";
            this.PanelListar.Size = new System.Drawing.Size(1707, 886);
            this.PanelListar.TabIndex = 1;
            this.PanelListar.Tag = "Default";
            // 
            // BtnExportarJSON
            // 
            this.BtnExportarJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.BtnExportarJSON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportarJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportarJSON.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportarJSON.ForeColor = System.Drawing.Color.Black;
            this.BtnExportarJSON.Location = new System.Drawing.Point(309, 628);
            this.BtnExportarJSON.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnExportarJSON.Name = "BtnExportarJSON";
            this.BtnExportarJSON.Size = new System.Drawing.Size(295, 43);
            this.BtnExportarJSON.TabIndex = 1;
            this.BtnExportarJSON.Text = "Exportar JSON";
            this.BtnExportarJSON.UseVisualStyleBackColor = false;
            this.BtnExportarJSON.Click += new System.EventHandler(this.BtnExportarJSON_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(156, 678);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1441, 2);
            this.panel1.TabIndex = 50;
            this.panel1.Tag = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.panel3.Location = new System.Drawing.Point(156, 85);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1441, 2);
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
            this.DataGridSeries.Location = new System.Drawing.Point(309, 185);
            this.DataGridSeries.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridSeries.Name = "DataGridSeries";
            this.DataGridSeries.ReadOnly = true;
            this.DataGridSeries.RowHeadersVisible = false;
            this.DataGridSeries.RowHeadersWidth = 51;
            this.DataGridSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridSeries.Size = new System.Drawing.Size(1116, 389);
            this.DataGridSeries.TabIndex = 2;
            // 
            // BtnImportarSeriesJSON
            // 
            this.BtnImportarSeriesJSON.Location = new System.Drawing.Point(1042, 632);
            this.BtnImportarSeriesJSON.Name = "BtnImportarSeriesJSON";
            this.BtnImportarSeriesJSON.Size = new System.Drawing.Size(162, 23);
            this.BtnImportarSeriesJSON.TabIndex = 51;
            this.BtnImportarSeriesJSON.Text = "Importar JSON";
            this.BtnImportarSeriesJSON.UseVisualStyleBackColor = true;
            this.BtnImportarSeriesJSON.Click += new System.EventHandler(this.BtnImportarSeriesJSON_Click);
            // 
            // ControlGestionSeriesListarSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PanelListar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ControlGestionSeriesListarSeries";
            this.Size = new System.Drawing.Size(1707, 886);
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
        private System.Windows.Forms.Button BtnExportarJSON;
        private System.Windows.Forms.Button BtnImportarSeriesJSON;
    }
}
