namespace ProjectoNuevo
{
    partial class ControlGestionPeliculasListarPeliculas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelListar = new System.Windows.Forms.Panel();
            this.DataGridPeliculas = new System.Windows.Forms.DataGridView();
            this.PanelListar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPeliculas)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelListar
            // 
            this.PanelListar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(55)))), ((int)(((byte)(82)))));
            this.PanelListar.Controls.Add(this.DataGridPeliculas);
            this.PanelListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelListar.Location = new System.Drawing.Point(0, 0);
            this.PanelListar.Name = "PanelListar";
            this.PanelListar.Size = new System.Drawing.Size(879, 437);
            this.PanelListar.TabIndex = 0;
            this.PanelListar.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelListar_Paint);
            // 
            // DataGridPeliculas
            // 
            this.DataGridPeliculas.AllowUserToAddRows = false;
            this.DataGridPeliculas.AllowUserToDeleteRows = false;
            this.DataGridPeliculas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(43)))));
            this.DataGridPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridPeliculas.Location = new System.Drawing.Point(105, 20);
            this.DataGridPeliculas.Name = "DataGridPeliculas";
            this.DataGridPeliculas.ReadOnly = true;
            this.DataGridPeliculas.RowHeadersVisible = false;
            this.DataGridPeliculas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridPeliculas.Size = new System.Drawing.Size(683, 230);
            this.DataGridPeliculas.TabIndex = 2;
            // 
            // ControlGestionPeliculasListarPeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelListar);
            this.Name = "ControlGestionPeliculasListarPeliculas";
            this.Size = new System.Drawing.Size(879, 437);
            this.Load += new System.EventHandler(this.ControlGestionPeliculasListarPeliculas_Load);
            this.PanelListar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPeliculas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelListar;
        private System.Windows.Forms.DataGridView DataGridPeliculas;
    }
}
