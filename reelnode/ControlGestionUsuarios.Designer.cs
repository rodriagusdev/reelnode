namespace ProjectoNuevo
{
    partial class ControlGestionUsuarios
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
            this.components = new System.ComponentModel.Container();
            this.CtxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtxMenuModificarRol = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelGrid = new System.Windows.Forms.Panel();
            this.DataGridUsuarios = new System.Windows.Forms.DataGridView();
            this.PanelCambiarRol = new System.Windows.Forms.Panel();
            this.RbtAdmin = new System.Windows.Forms.RadioButton();
            this.RbtUsuario = new System.Windows.Forms.RadioButton();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.PanelGestionUsuarios = new System.Windows.Forms.Panel();
            this.CtxMain.SuspendLayout();
            this.PanelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUsuarios)).BeginInit();
            this.PanelCambiarRol.SuspendLayout();
            this.PanelGestionUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtxMain
            // 
            this.CtxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtxMenuModificarRol});
            this.CtxMain.Name = "CtxMain";
            this.CtxMain.Size = new System.Drawing.Size(126, 26);
            // 
            // CtxMenuModificarRol
            // 
            this.CtxMenuModificarRol.Name = "CtxMenuModificarRol";
            this.CtxMenuModificarRol.Size = new System.Drawing.Size(125, 22);
            this.CtxMenuModificarRol.Text = "Modificar";
            this.CtxMenuModificarRol.Click += new System.EventHandler(this.CtxMenuModificarRol_Click);
            // 
            // PanelGrid
            // 
            this.PanelGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(47)))), ((int)(((byte)(71)))));
            this.PanelGrid.Controls.Add(this.DataGridUsuarios);
            this.PanelGrid.Location = new System.Drawing.Point(76, 22);
            this.PanelGrid.Name = "PanelGrid";
            this.PanelGrid.Size = new System.Drawing.Size(707, 156);
            this.PanelGrid.TabIndex = 8;
            // 
            // DataGridUsuarios
            // 
            this.DataGridUsuarios.AllowUserToAddRows = false;
            this.DataGridUsuarios.AllowUserToDeleteRows = false;
            this.DataGridUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(43)))));
            this.DataGridUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridUsuarios.ContextMenuStrip = this.CtxMain;
            this.DataGridUsuarios.Location = new System.Drawing.Point(13, 9);
            this.DataGridUsuarios.Name = "DataGridUsuarios";
            this.DataGridUsuarios.ReadOnly = true;
            this.DataGridUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridUsuarios.Size = new System.Drawing.Size(683, 136);
            this.DataGridUsuarios.TabIndex = 2;
            this.DataGridUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridUsuarios_CellContentClick);
            this.DataGridUsuarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridUsuarios_CellFormatting);
            // 
            // PanelCambiarRol
            // 
            this.PanelCambiarRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(47)))), ((int)(((byte)(71)))));
            this.PanelCambiarRol.Controls.Add(this.RbtAdmin);
            this.PanelCambiarRol.Controls.Add(this.RbtUsuario);
            this.PanelCambiarRol.Controls.Add(this.BtnConfirmar);
            this.PanelCambiarRol.Location = new System.Drawing.Point(497, 212);
            this.PanelCambiarRol.Name = "PanelCambiarRol";
            this.PanelCambiarRol.Size = new System.Drawing.Size(286, 100);
            this.PanelCambiarRol.TabIndex = 9;
            this.PanelCambiarRol.Visible = false;
            // 
            // RbtAdmin
            // 
            this.RbtAdmin.AutoSize = true;
            this.RbtAdmin.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbtAdmin.ForeColor = System.Drawing.Color.White;
            this.RbtAdmin.Location = new System.Drawing.Point(207, 26);
            this.RbtAdmin.Name = "RbtAdmin";
            this.RbtAdmin.Size = new System.Drawing.Size(63, 21);
            this.RbtAdmin.TabIndex = 6;
            this.RbtAdmin.TabStop = true;
            this.RbtAdmin.Text = "Admin";
            this.RbtAdmin.UseVisualStyleBackColor = true;
            this.RbtAdmin.CheckedChanged += new System.EventHandler(this.RbtAdmin_CheckedChanged);
            // 
            // RbtUsuario
            // 
            this.RbtUsuario.AutoSize = true;
            this.RbtUsuario.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbtUsuario.ForeColor = System.Drawing.Color.White;
            this.RbtUsuario.Location = new System.Drawing.Point(207, 53);
            this.RbtUsuario.Name = "RbtUsuario";
            this.RbtUsuario.Size = new System.Drawing.Size(68, 21);
            this.RbtUsuario.TabIndex = 5;
            this.RbtUsuario.TabStop = true;
            this.RbtUsuario.Text = "Usuario";
            this.RbtUsuario.UseVisualStyleBackColor = true;
            this.RbtUsuario.CheckedChanged += new System.EventHandler(this.RbtUsuario_CheckedChanged);
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirmar.Location = new System.Drawing.Point(19, 28);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(140, 46);
            this.BtnConfirmar.TabIndex = 3;
            this.BtnConfirmar.Text = "Confirmar nuevo rol";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportar.Location = new System.Drawing.Point(76, 274);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(120, 38);
            this.BtnExportar.TabIndex = 10;
            this.BtnExportar.Text = "Exportar a PDF";
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // PanelGestionUsuarios
            // 
            this.PanelGestionUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(55)))), ((int)(((byte)(82)))));
            this.PanelGestionUsuarios.Controls.Add(this.BtnExportar);
            this.PanelGestionUsuarios.Controls.Add(this.PanelCambiarRol);
            this.PanelGestionUsuarios.Controls.Add(this.PanelGrid);
            this.PanelGestionUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelGestionUsuarios.Location = new System.Drawing.Point(0, 0);
            this.PanelGestionUsuarios.Name = "PanelGestionUsuarios";
            this.PanelGestionUsuarios.Size = new System.Drawing.Size(882, 562);
            this.PanelGestionUsuarios.TabIndex = 0;
            // 
            // ControlGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelGestionUsuarios);
            this.Name = "ControlGestionUsuarios";
            this.Size = new System.Drawing.Size(882, 562);
            this.Load += new System.EventHandler(this.ControlGestionUsuarios_Load);
            this.CtxMain.ResumeLayout(false);
            this.PanelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUsuarios)).EndInit();
            this.PanelCambiarRol.ResumeLayout(false);
            this.PanelCambiarRol.PerformLayout();
            this.PanelGestionUsuarios.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip CtxMain;
        private System.Windows.Forms.ToolStripMenuItem CtxMenuModificarRol;
        private System.Windows.Forms.Panel PanelGrid;
        private System.Windows.Forms.DataGridView DataGridUsuarios;
        private System.Windows.Forms.Panel PanelCambiarRol;
        private System.Windows.Forms.RadioButton RbtAdmin;
        private System.Windows.Forms.RadioButton RbtUsuario;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.Panel PanelGestionUsuarios;
    }
}
