namespace Reelnode
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DataGridPeliculas = new System.Windows.Forms.DataGridView();
            this.BtnExportarJSON = new System.Windows.Forms.Button();
            this.saveFileDialogExportarJSON = new System.Windows.Forms.SaveFileDialog();
            this.PanelListar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPeliculas)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelListar
            // 
            this.PanelListar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(55)))), ((int)(((byte)(82)))));
            this.PanelListar.Controls.Add(this.BtnExportarJSON);
            this.PanelListar.Controls.Add(this.panel1);
            this.PanelListar.Controls.Add(this.panel3);
            this.PanelListar.Controls.Add(this.DataGridPeliculas);
            this.PanelListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelListar.Location = new System.Drawing.Point(0, 0);
            this.PanelListar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelListar.Name = "PanelListar";
            this.PanelListar.Size = new System.Drawing.Size(1707, 886);
            this.PanelListar.TabIndex = 0;
            this.PanelListar.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelListar_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(156, 678);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1441, 2);
            this.panel1.TabIndex = 52;
            this.panel1.Tag = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.panel3.Location = new System.Drawing.Point(156, 85);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1441, 2);
            this.panel3.TabIndex = 51;
            this.panel3.Tag = "";
            // 
            // DataGridPeliculas
            // 
            this.DataGridPeliculas.AllowUserToAddRows = false;
            this.DataGridPeliculas.AllowUserToDeleteRows = false;
            this.DataGridPeliculas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridPeliculas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.DataGridPeliculas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridPeliculas.Location = new System.Drawing.Point(308, 185);
            this.DataGridPeliculas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridPeliculas.Name = "DataGridPeliculas";
            this.DataGridPeliculas.ReadOnly = true;
            this.DataGridPeliculas.RowHeadersVisible = false;
            this.DataGridPeliculas.RowHeadersWidth = 51;
            this.DataGridPeliculas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridPeliculas.Size = new System.Drawing.Size(1055, 389);
            this.DataGridPeliculas.TabIndex = 2;
            // 
            // BtnExportarJSON
            // 
            this.BtnExportarJSON.Location = new System.Drawing.Point(360, 608);
            this.BtnExportarJSON.Name = "BtnExportarJSON";
            this.BtnExportarJSON.Size = new System.Drawing.Size(138, 23);
            this.BtnExportarJSON.TabIndex = 53;
            this.BtnExportarJSON.Text = "Exportar JSON";
            this.BtnExportarJSON.UseVisualStyleBackColor = true;
            this.BtnExportarJSON.Click += new System.EventHandler(this.BtnExportarJSON_Click);
            // 
            // ControlGestionPeliculasListarPeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelListar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ControlGestionPeliculasListarPeliculas";
            this.Size = new System.Drawing.Size(1707, 886);
            this.Load += new System.EventHandler(this.ControlGestionPeliculasListarPeliculas_Load);
            this.PanelListar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPeliculas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelListar;
        private System.Windows.Forms.DataGridView DataGridPeliculas;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnExportarJSON;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExportarJSON;
    }
}
