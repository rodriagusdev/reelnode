namespace Reelnode
{
    partial class ControlAdmin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStpMenuDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuPeliculas = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpSubMenuCargarPeliculas = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpSubMenuListarPeliculas = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuActualizarPelicula = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuCargarSerie = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuListarSerie = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuActualizarSerie = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelAdmin = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStpMenuDashboard,
            this.ToolStpMenuUsuarios,
            this.ToolStpMenuPeliculas,
            this.ToolStpMenuSeries});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6);
            this.menuStrip1.Size = new System.Drawing.Size(1280, 31);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStpMenuDashboard
            // 
            this.ToolStpMenuDashboard.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStpMenuDashboard.Name = "ToolStpMenuDashboard";
            this.ToolStpMenuDashboard.Size = new System.Drawing.Size(82, 19);
            this.ToolStpMenuDashboard.Text = "Dashboard";
            this.ToolStpMenuDashboard.Click += new System.EventHandler(this.ToolStpMenuDashboard_Click);
            // 
            // ToolStpMenuUsuarios
            // 
            this.ToolStpMenuUsuarios.Font = new System.Drawing.Font("Consolas", 9F);
            this.ToolStpMenuUsuarios.Name = "ToolStpMenuUsuarios";
            this.ToolStpMenuUsuarios.Size = new System.Drawing.Size(145, 19);
            this.ToolStpMenuUsuarios.Text = "Gestionar Usuarios";
            this.ToolStpMenuUsuarios.Click += new System.EventHandler(this.ToolStpMenuUsuarios_Click);
            // 
            // ToolStpMenuPeliculas
            // 
            this.ToolStpMenuPeliculas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStpSubMenuCargarPeliculas,
            this.ToolStpSubMenuListarPeliculas,
            this.ToolStpMenuActualizarPelicula});
            this.ToolStpMenuPeliculas.Font = new System.Drawing.Font("Consolas", 9F);
            this.ToolStpMenuPeliculas.Name = "ToolStpMenuPeliculas";
            this.ToolStpMenuPeliculas.Size = new System.Drawing.Size(152, 19);
            this.ToolStpMenuPeliculas.Text = "Gestionar Peliculas";
            // 
            // ToolStpSubMenuCargarPeliculas
            // 
            this.ToolStpSubMenuCargarPeliculas.Name = "ToolStpSubMenuCargarPeliculas";
            this.ToolStpSubMenuCargarPeliculas.Size = new System.Drawing.Size(284, 22);
            this.ToolStpSubMenuCargarPeliculas.Text = "Cargar pelicula";
            this.ToolStpSubMenuCargarPeliculas.Click += new System.EventHandler(this.ToolStpSubMenuCargarPeliculas_Click);
            // 
            // ToolStpSubMenuListarPeliculas
            // 
            this.ToolStpSubMenuListarPeliculas.Name = "ToolStpSubMenuListarPeliculas";
            this.ToolStpSubMenuListarPeliculas.Size = new System.Drawing.Size(284, 22);
            this.ToolStpSubMenuListarPeliculas.Text = "Listar peliculas";
            this.ToolStpSubMenuListarPeliculas.Click += new System.EventHandler(this.ToolStpSubMenuListarPeliculas_Click);
            // 
            // ToolStpMenuActualizarPelicula
            // 
            this.ToolStpMenuActualizarPelicula.Name = "ToolStpMenuActualizarPelicula";
            this.ToolStpMenuActualizarPelicula.Size = new System.Drawing.Size(284, 22);
            this.ToolStpMenuActualizarPelicula.Text = "Actualizar o eliminar pelicula";
            this.ToolStpMenuActualizarPelicula.Click += new System.EventHandler(this.ToolStpMenuActualizarPelicula_Click);
            // 
            // ToolStpMenuSeries
            // 
            this.ToolStpMenuSeries.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStpMenuCargarSerie,
            this.ToolStpMenuListarSerie,
            this.ToolStpMenuActualizarSerie});
            this.ToolStpMenuSeries.Font = new System.Drawing.Font("Consolas", 9F);
            this.ToolStpMenuSeries.Name = "ToolStpMenuSeries";
            this.ToolStpMenuSeries.Size = new System.Drawing.Size(131, 19);
            this.ToolStpMenuSeries.Text = "Gestionar Series";
            // 
            // ToolStpMenuCargarSerie
            // 
            this.ToolStpMenuCargarSerie.Name = "ToolStpMenuCargarSerie";
            this.ToolStpMenuCargarSerie.Size = new System.Drawing.Size(263, 22);
            this.ToolStpMenuCargarSerie.Text = "Cargar serie";
            this.ToolStpMenuCargarSerie.Click += new System.EventHandler(this.ToolStpMenuCargarSerie_Click);
            // 
            // ToolStpMenuListarSerie
            // 
            this.ToolStpMenuListarSerie.Name = "ToolStpMenuListarSerie";
            this.ToolStpMenuListarSerie.Size = new System.Drawing.Size(263, 22);
            this.ToolStpMenuListarSerie.Text = "Listar series";
            this.ToolStpMenuListarSerie.Click += new System.EventHandler(this.ToolStpMenuListarSerie_Click);
            // 
            // ToolStpMenuActualizarSerie
            // 
            this.ToolStpMenuActualizarSerie.Name = "ToolStpMenuActualizarSerie";
            this.ToolStpMenuActualizarSerie.Size = new System.Drawing.Size(263, 22);
            this.ToolStpMenuActualizarSerie.Text = "Actualizar o eliminar serie";
            this.ToolStpMenuActualizarSerie.Click += new System.EventHandler(this.ToolStpMenuActualizarSerie_Click);
            // 
            // PanelAdmin
            // 
            this.PanelAdmin.AutoSize = true;
            this.PanelAdmin.BackColor = System.Drawing.Color.Transparent;
            this.PanelAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelAdmin.Location = new System.Drawing.Point(0, 31);
            this.PanelAdmin.Name = "PanelAdmin";
            this.PanelAdmin.Size = new System.Drawing.Size(1280, 689);
            this.PanelAdmin.TabIndex = 3;
            // 
            // ControlAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PanelAdmin);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ControlAdmin";
            this.Size = new System.Drawing.Size(1280, 720);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuPeliculas;
        private System.Windows.Forms.ToolStripMenuItem ToolStpSubMenuCargarPeliculas;
        private System.Windows.Forms.ToolStripMenuItem ToolStpSubMenuListarPeliculas;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuActualizarPelicula;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuSeries;
        private System.Windows.Forms.Panel PanelAdmin;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuCargarSerie;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuListarSerie;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuActualizarSerie;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuDashboard;
    }
}
