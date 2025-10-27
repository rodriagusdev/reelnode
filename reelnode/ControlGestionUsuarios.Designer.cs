namespace Reelnode
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
            this.CtxMenuAsignarPermisos = new System.Windows.Forms.ToolStripMenuItem();
            this.CtxMenuVerPermisos = new System.Windows.Forms.ToolStripMenuItem();
            this.CtxMenuEliminarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelGrid = new System.Windows.Forms.Panel();
            this.DataGridUsuarios = new System.Windows.Forms.DataGridView();
            this.PanelCambiarRol = new System.Windows.Forms.Panel();
            this.RbtAdmin = new System.Windows.Forms.RadioButton();
            this.RbtUsuario = new System.Windows.Forms.RadioButton();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.PanelGestionUsuarios = new System.Windows.Forms.Panel();
            this.LblAdvertencia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblPermisosNombre = new System.Windows.Forms.Label();
            this.PanelMostrarPermisos = new System.Windows.Forms.Panel();
            this.LblPermisosUsuario = new System.Windows.Forms.Label();
            this.PanelPermisos = new System.Windows.Forms.Panel();
            this.BtnSeleccionarTodos = new System.Windows.Forms.Button();
            this.BtnConfirmarPermisos = new System.Windows.Forms.Button();
            this.ChkListPermisos = new System.Windows.Forms.CheckedListBox();
            this.CtxMain.SuspendLayout();
            this.PanelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUsuarios)).BeginInit();
            this.PanelCambiarRol.SuspendLayout();
            this.PanelGestionUsuarios.SuspendLayout();
            this.PanelMostrarPermisos.SuspendLayout();
            this.PanelPermisos.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtxMain
            // 
            this.CtxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtxMenuModificarRol,
            this.CtxMenuAsignarPermisos,
            this.CtxMenuVerPermisos,
            this.CtxMenuEliminarUsuario});
            this.CtxMain.Name = "CtxMain";
            this.CtxMain.Size = new System.Drawing.Size(224, 92);
            // 
            // CtxMenuModificarRol
            // 
            this.CtxMenuModificarRol.Name = "CtxMenuModificarRol";
            this.CtxMenuModificarRol.Size = new System.Drawing.Size(223, 22);
            this.CtxMenuModificarRol.Text = "Modificar rol de usuario";
            this.CtxMenuModificarRol.Click += new System.EventHandler(this.CtxMenuModificarRol_Click);
            // 
            // CtxMenuAsignarPermisos
            // 
            this.CtxMenuAsignarPermisos.Name = "CtxMenuAsignarPermisos";
            this.CtxMenuAsignarPermisos.Size = new System.Drawing.Size(223, 22);
            this.CtxMenuAsignarPermisos.Text = "Asignar permisos de usuario";
            this.CtxMenuAsignarPermisos.Click += new System.EventHandler(this.CtxMenuAsignarPermisos_Click);
            // 
            // CtxMenuVerPermisos
            // 
            this.CtxMenuVerPermisos.Name = "CtxMenuVerPermisos";
            this.CtxMenuVerPermisos.Size = new System.Drawing.Size(223, 22);
            this.CtxMenuVerPermisos.Text = "Ver permisos del usuario";
            this.CtxMenuVerPermisos.Click += new System.EventHandler(this.CtxMenuVerPermisos_Click);
            // 
            // CtxMenuEliminarUsuario
            // 
            this.CtxMenuEliminarUsuario.Name = "CtxMenuEliminarUsuario";
            this.CtxMenuEliminarUsuario.Size = new System.Drawing.Size(223, 22);
            this.CtxMenuEliminarUsuario.Text = "Eliminar usuario";
            this.CtxMenuEliminarUsuario.Click += new System.EventHandler(this.CtxMenuEliminarUsuario_Click);
            // 
            // PanelGrid
            // 
            this.PanelGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(47)))), ((int)(((byte)(71)))));
            this.PanelGrid.Controls.Add(this.DataGridUsuarios);
            this.PanelGrid.Location = new System.Drawing.Point(232, 75);
            this.PanelGrid.Name = "PanelGrid";
            this.PanelGrid.Size = new System.Drawing.Size(837, 195);
            this.PanelGrid.TabIndex = 8;
            // 
            // DataGridUsuarios
            // 
            this.DataGridUsuarios.AllowUserToAddRows = false;
            this.DataGridUsuarios.AllowUserToDeleteRows = false;
            this.DataGridUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(43)))));
            this.DataGridUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridUsuarios.ContextMenuStrip = this.CtxMain;
            this.DataGridUsuarios.Location = new System.Drawing.Point(13, 9);
            this.DataGridUsuarios.Name = "DataGridUsuarios";
            this.DataGridUsuarios.ReadOnly = true;
            this.DataGridUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridUsuarios.Size = new System.Drawing.Size(808, 174);
            this.DataGridUsuarios.TabIndex = 2;
            this.DataGridUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridUsuarios_CellClick);
            this.DataGridUsuarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridUsuarios_CellFormatting);
            this.DataGridUsuarios.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridUsuarios_CellMouseDown);
            // 
            // PanelCambiarRol
            // 
            this.PanelCambiarRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(47)))), ((int)(((byte)(71)))));
            this.PanelCambiarRol.Controls.Add(this.RbtAdmin);
            this.PanelCambiarRol.Controls.Add(this.RbtUsuario);
            this.PanelCambiarRol.Controls.Add(this.BtnConfirmar);
            this.PanelCambiarRol.Enabled = false;
            this.PanelCambiarRol.Location = new System.Drawing.Point(828, 327);
            this.PanelCambiarRol.Name = "PanelCambiarRol";
            this.PanelCambiarRol.Size = new System.Drawing.Size(241, 89);
            this.PanelCambiarRol.TabIndex = 9;
            // 
            // RbtAdmin
            // 
            this.RbtAdmin.AutoSize = true;
            this.RbtAdmin.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbtAdmin.ForeColor = System.Drawing.Color.White;
            this.RbtAdmin.Location = new System.Drawing.Point(162, 15);
            this.RbtAdmin.Name = "RbtAdmin";
            this.RbtAdmin.Size = new System.Drawing.Size(63, 21);
            this.RbtAdmin.TabIndex = 5;
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
            this.RbtUsuario.Location = new System.Drawing.Point(162, 59);
            this.RbtUsuario.Name = "RbtUsuario";
            this.RbtUsuario.Size = new System.Drawing.Size(68, 21);
            this.RbtUsuario.TabIndex = 6;
            this.RbtUsuario.TabStop = true;
            this.RbtUsuario.Text = "Usuario";
            this.RbtUsuario.UseVisualStyleBackColor = true;
            this.RbtUsuario.CheckedChanged += new System.EventHandler(this.RbtUsuario_CheckedChanged);
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirmar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirmar.Location = new System.Drawing.Point(13, 25);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(140, 46);
            this.BtnConfirmar.TabIndex = 7;
            this.BtnConfirmar.Text = "Confirmar nuevo rol";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportar.Location = new System.Drawing.Point(949, 424);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(120, 46);
            this.BtnExportar.TabIndex = 8;
            this.BtnExportar.Text = "Exportar a PDF";
            this.BtnExportar.UseVisualStyleBackColor = true;
            // 
            // PanelGestionUsuarios
            // 
            this.PanelGestionUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.PanelGestionUsuarios.Controls.Add(this.LblAdvertencia);
            this.PanelGestionUsuarios.Controls.Add(this.label1);
            this.PanelGestionUsuarios.Controls.Add(this.LblPermisosNombre);
            this.PanelGestionUsuarios.Controls.Add(this.PanelMostrarPermisos);
            this.PanelGestionUsuarios.Controls.Add(this.PanelPermisos);
            this.PanelGestionUsuarios.Controls.Add(this.BtnExportar);
            this.PanelGestionUsuarios.Controls.Add(this.PanelCambiarRol);
            this.PanelGestionUsuarios.Controls.Add(this.PanelGrid);
            this.PanelGestionUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelGestionUsuarios.Location = new System.Drawing.Point(0, 0);
            this.PanelGestionUsuarios.Name = "PanelGestionUsuarios";
            this.PanelGestionUsuarios.Size = new System.Drawing.Size(1280, 720);
            this.PanelGestionUsuarios.TabIndex = 0;
            this.PanelGestionUsuarios.Tag = "Default";
            // 
            // LblAdvertencia
            // 
            this.LblAdvertencia.AutoSize = true;
            this.LblAdvertencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAdvertencia.ForeColor = System.Drawing.Color.Red;
            this.LblAdvertencia.Location = new System.Drawing.Point(230, 303);
            this.LblAdvertencia.Name = "LblAdvertencia";
            this.LblAdvertencia.Size = new System.Drawing.Size(421, 15);
            this.LblAdvertencia.TabIndex = 14;
            this.LblAdvertencia.Tag = "";
            this.LblAdvertencia.Text = "Atención! permisos seleccionados sobreescribiran los existentes";
            this.LblAdvertencia.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(228, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 24);
            this.label1.TabIndex = 13;
            this.label1.Tag = "Titulo";
            this.label1.Text = "Usuarios registrados en el sistema";
            // 
            // LblPermisosNombre
            // 
            this.LblPermisosNombre.AutoSize = true;
            this.LblPermisosNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPermisosNombre.Location = new System.Drawing.Point(229, 501);
            this.LblPermisosNombre.Name = "LblPermisosNombre";
            this.LblPermisosNombre.Size = new System.Drawing.Size(0, 16);
            this.LblPermisosNombre.TabIndex = 12;
            this.LblPermisosNombre.Tag = "Titulo";
            // 
            // PanelMostrarPermisos
            // 
            this.PanelMostrarPermisos.Controls.Add(this.LblPermisosUsuario);
            this.PanelMostrarPermisos.Location = new System.Drawing.Point(232, 520);
            this.PanelMostrarPermisos.Name = "PanelMostrarPermisos";
            this.PanelMostrarPermisos.Size = new System.Drawing.Size(837, 41);
            this.PanelMostrarPermisos.TabIndex = 11;
            // 
            // LblPermisosUsuario
            // 
            this.LblPermisosUsuario.AutoSize = true;
            this.LblPermisosUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPermisosUsuario.Location = new System.Drawing.Point(19, 16);
            this.LblPermisosUsuario.Name = "LblPermisosUsuario";
            this.LblPermisosUsuario.Size = new System.Drawing.Size(0, 13);
            this.LblPermisosUsuario.TabIndex = 0;
            // 
            // PanelPermisos
            // 
            this.PanelPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(47)))), ((int)(((byte)(71)))));
            this.PanelPermisos.Controls.Add(this.BtnSeleccionarTodos);
            this.PanelPermisos.Controls.Add(this.BtnConfirmarPermisos);
            this.PanelPermisos.Controls.Add(this.ChkListPermisos);
            this.PanelPermisos.Enabled = false;
            this.PanelPermisos.Location = new System.Drawing.Point(232, 327);
            this.PanelPermisos.Name = "PanelPermisos";
            this.PanelPermisos.Size = new System.Drawing.Size(419, 143);
            this.PanelPermisos.TabIndex = 10;
            // 
            // BtnSeleccionarTodos
            // 
            this.BtnSeleccionarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSeleccionarTodos.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionarTodos.Location = new System.Drawing.Point(23, 87);
            this.BtnSeleccionarTodos.Name = "BtnSeleccionarTodos";
            this.BtnSeleccionarTodos.Size = new System.Drawing.Size(134, 44);
            this.BtnSeleccionarTodos.TabIndex = 2;
            this.BtnSeleccionarTodos.Text = "Seleccionar todos";
            this.BtnSeleccionarTodos.UseVisualStyleBackColor = true;
            this.BtnSeleccionarTodos.Click += new System.EventHandler(this.BtnSeleccionarTodos_Click);
            // 
            // BtnConfirmarPermisos
            // 
            this.BtnConfirmarPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirmarPermisos.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirmarPermisos.Location = new System.Drawing.Point(22, 12);
            this.BtnConfirmarPermisos.Name = "BtnConfirmarPermisos";
            this.BtnConfirmarPermisos.Size = new System.Drawing.Size(134, 44);
            this.BtnConfirmarPermisos.TabIndex = 4;
            this.BtnConfirmarPermisos.Text = "Confirmar permisos";
            this.BtnConfirmarPermisos.UseVisualStyleBackColor = true;
            this.BtnConfirmarPermisos.Click += new System.EventHandler(this.BtnConfirmarPermisos_Click);
            // 
            // ChkListPermisos
            // 
            this.ChkListPermisos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChkListPermisos.CheckOnClick = true;
            this.ChkListPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkListPermisos.FormattingEnabled = true;
            this.ChkListPermisos.Location = new System.Drawing.Point(223, 12);
            this.ChkListPermisos.Name = "ChkListPermisos";
            this.ChkListPermisos.Size = new System.Drawing.Size(167, 119);
            this.ChkListPermisos.TabIndex = 3;
            // 
            // ControlGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PanelGestionUsuarios);
            this.Name = "ControlGestionUsuarios";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Load += new System.EventHandler(this.ControlGestionUsuarios_Load);
            this.CtxMain.ResumeLayout(false);
            this.PanelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUsuarios)).EndInit();
            this.PanelCambiarRol.ResumeLayout(false);
            this.PanelCambiarRol.PerformLayout();
            this.PanelGestionUsuarios.ResumeLayout(false);
            this.PanelGestionUsuarios.PerformLayout();
            this.PanelMostrarPermisos.ResumeLayout(false);
            this.PanelMostrarPermisos.PerformLayout();
            this.PanelPermisos.ResumeLayout(false);
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
        private System.Windows.Forms.Panel PanelPermisos;
        private System.Windows.Forms.Button BtnConfirmarPermisos;
        private System.Windows.Forms.CheckedListBox ChkListPermisos;
        private System.Windows.Forms.Button BtnSeleccionarTodos;
        private System.Windows.Forms.ToolStripMenuItem CtxMenuAsignarPermisos;
        private System.Windows.Forms.ToolStripMenuItem CtxMenuVerPermisos;
        private System.Windows.Forms.Panel PanelMostrarPermisos;
        private System.Windows.Forms.Label LblPermisosUsuario;
        private System.Windows.Forms.Label LblPermisosNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblAdvertencia;
        private System.Windows.Forms.ToolStripMenuItem CtxMenuEliminarUsuario;
    }
}
