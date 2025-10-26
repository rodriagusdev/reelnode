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
            this.BtnExportarJSON = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DataGridPeliculas = new System.Windows.Forms.DataGridView();
            this.PanelListar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPeliculas)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelListar
            // 
            this.PanelListar.BackColor = System.Drawing.Color.Transparent;
            this.PanelListar.Controls.Add(this.BtnExportarJSON);
            this.PanelListar.Controls.Add(this.panel1);
            this.PanelListar.Controls.Add(this.panel3);
            this.PanelListar.Controls.Add(this.DataGridPeliculas);
            this.PanelListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelListar.Location = new System.Drawing.Point(0, 0);
            this.PanelListar.Name = "PanelListar";
            this.PanelListar.Size = new System.Drawing.Size(1280, 720);
            this.PanelListar.TabIndex = 0;
            this.PanelListar.Tag = "Default";
            // 
            // BtnExportarJSON
            // 
            this.BtnExportarJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.BtnExportarJSON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportarJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportarJSON.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportarJSON.ForeColor = System.Drawing.Color.Black;
            this.BtnExportarJSON.Location = new System.Drawing.Point(232, 484);
            this.BtnExportarJSON.Name = "BtnExportarJSON";
            this.BtnExportarJSON.Size = new System.Drawing.Size(221, 35);
            this.BtnExportarJSON.TabIndex = 1;
            this.BtnExportarJSON.Text = "Exportar JSON";
            this.BtnExportarJSON.UseVisualStyleBackColor = false;
            this.BtnExportarJSON.Click += new System.EventHandler(this.BtnExportarJSON_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(117, 551);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 2);
            this.panel1.TabIndex = 52;
            this.panel1.Tag = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.panel3.Location = new System.Drawing.Point(117, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1081, 2);
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
            this.DataGridPeliculas.Location = new System.Drawing.Point(232, 125);
            this.DataGridPeliculas.Name = "DataGridPeliculas";
            this.DataGridPeliculas.ReadOnly = true;
            this.DataGridPeliculas.RowHeadersVisible = false;
            this.DataGridPeliculas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridPeliculas.Size = new System.Drawing.Size(837, 316);
            this.DataGridPeliculas.TabIndex = 2;
            // 
            // ControlGestionPeliculasListarPeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PanelListar);
            this.Name = "ControlGestionPeliculasListarPeliculas";
            this.Size = new System.Drawing.Size(1280, 720);
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
    }
}
