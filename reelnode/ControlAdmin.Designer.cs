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
            this.ToolStpMenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuPeliculas = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpSubMenuCargarPeliculas = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpSubMenuListarPeliculas = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuActualizarPelicula = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarSerieToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listarSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarSerieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelAdmin = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStpMenuUsuarios,
            this.ToolStpMenuPeliculas,
            this.ToolStpMenuSeries});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStpMenuUsuarios
            // 
            this.ToolStpMenuUsuarios.Font = new System.Drawing.Font("Consolas", 9F);
            this.ToolStpMenuUsuarios.Name = "ToolStpMenuUsuarios";
            this.ToolStpMenuUsuarios.Size = new System.Drawing.Size(145, 20);
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
            this.ToolStpMenuPeliculas.Size = new System.Drawing.Size(152, 20);
            this.ToolStpMenuPeliculas.Text = "Gestionar Peliculas";
            // 
            // ToolStpSubMenuCargarPeliculas
            // 
            this.ToolStpSubMenuCargarPeliculas.Name = "ToolStpSubMenuCargarPeliculas";
            this.ToolStpSubMenuCargarPeliculas.Size = new System.Drawing.Size(207, 22);
            this.ToolStpSubMenuCargarPeliculas.Text = "Cargar Pelicula";
            this.ToolStpSubMenuCargarPeliculas.Click += new System.EventHandler(this.ToolStpSubMenuCargarPeliculas_Click);
            // 
            // ToolStpSubMenuListarPeliculas
            // 
            this.ToolStpSubMenuListarPeliculas.Name = "ToolStpSubMenuListarPeliculas";
            this.ToolStpSubMenuListarPeliculas.Size = new System.Drawing.Size(207, 22);
            this.ToolStpSubMenuListarPeliculas.Text = "Listar Peliculas";
            this.ToolStpSubMenuListarPeliculas.Click += new System.EventHandler(this.ToolStpSubMenuListarPeliculas_Click);
            // 
            // ToolStpMenuActualizarPelicula
            // 
            this.ToolStpMenuActualizarPelicula.Name = "ToolStpMenuActualizarPelicula";
            this.ToolStpMenuActualizarPelicula.Size = new System.Drawing.Size(207, 22);
            this.ToolStpMenuActualizarPelicula.Text = "Actualizar Pelicula";
            this.ToolStpMenuActualizarPelicula.Click += new System.EventHandler(this.ToolStpMenuActualizarPelicula_Click);
            // 
            // ToolStpMenuSeries
            // 
            this.ToolStpMenuSeries.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarSerieToolStripMenuItem1,
            this.listarSeriesToolStripMenuItem,
            this.actualizarSerieToolStripMenuItem});
            this.ToolStpMenuSeries.Font = new System.Drawing.Font("Consolas", 9F);
            this.ToolStpMenuSeries.Name = "ToolStpMenuSeries";
            this.ToolStpMenuSeries.Size = new System.Drawing.Size(131, 20);
            this.ToolStpMenuSeries.Text = "Gestionar Series";
            // 
            // cargarSerieToolStripMenuItem1
            // 
            this.cargarSerieToolStripMenuItem1.Name = "cargarSerieToolStripMenuItem1";
            this.cargarSerieToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.cargarSerieToolStripMenuItem1.Text = "Cargar Serie";
            this.cargarSerieToolStripMenuItem1.Click += new System.EventHandler(this.cargarSerieToolStripMenuItem1_Click);
            // 
            // listarSeriesToolStripMenuItem
            // 
            this.listarSeriesToolStripMenuItem.Name = "listarSeriesToolStripMenuItem";
            this.listarSeriesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.listarSeriesToolStripMenuItem.Text = "Listar Series";
            this.listarSeriesToolStripMenuItem.Click += new System.EventHandler(this.listarSeriesToolStripMenuItem_Click);
            // 
            // actualizarSerieToolStripMenuItem
            // 
            this.actualizarSerieToolStripMenuItem.Name = "actualizarSerieToolStripMenuItem";
            this.actualizarSerieToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.actualizarSerieToolStripMenuItem.Text = "Actualizar Serie";
            this.actualizarSerieToolStripMenuItem.Click += new System.EventHandler(this.actualizarSerieToolStripMenuItem_Click);
            // 
            // PanelAdmin
            // 
            this.PanelAdmin.AutoSize = true;
            this.PanelAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(55)))), ((int)(((byte)(82)))));
            this.PanelAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelAdmin.Location = new System.Drawing.Point(0, 24);
            this.PanelAdmin.Name = "PanelAdmin";
            this.PanelAdmin.Size = new System.Drawing.Size(863, 537);
            this.PanelAdmin.TabIndex = 3;
            this.PanelAdmin.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelAdmin_Paint);
            // 
            // ControlAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelAdmin);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ControlAdmin";
            this.Size = new System.Drawing.Size(863, 561);
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
        private System.Windows.Forms.ToolStripMenuItem cargarSerieToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listarSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarSerieToolStripMenuItem;
    }
}
