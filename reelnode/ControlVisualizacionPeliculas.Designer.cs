namespace ProjectoNuevo
{
    partial class ControlVisualizacionPeliculas
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
            this.PanelVisualizarPeli = new System.Windows.Forms.Panel();
            this.PanelDescripcion = new System.Windows.Forms.Panel();
            this.LblDescripcionPeli = new System.Windows.Forms.Label();
            this.PanelTrailerPeli = new System.Windows.Forms.Panel();
            this.WebBrowserPelicula = new System.Windows.Forms.WebBrowser();
            this.BtnBuscarPelicula = new System.Windows.Forms.Button();
            this.LblPanelPelicula = new System.Windows.Forms.Label();
            this.PanelUsuario = new System.Windows.Forms.Panel();
            this.TxtNombrePelicula = new System.Windows.Forms.TextBox();
            this.BtnPuntuar = new System.Windows.Forms.Button();
            this.PanelPuntuacion = new System.Windows.Forms.Panel();
            this.LblPuntuacion = new System.Windows.Forms.Label();
            this.PanelImagenPeli = new System.Windows.Forms.Panel();
            this.PicPeliVisualizacion = new System.Windows.Forms.PictureBox();
            this.PanelVisualizarPeli.SuspendLayout();
            this.PanelDescripcion.SuspendLayout();
            this.PanelTrailerPeli.SuspendLayout();
            this.PanelUsuario.SuspendLayout();
            this.PanelPuntuacion.SuspendLayout();
            this.PanelImagenPeli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPeliVisualizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelVisualizarPeli
            // 
            this.PanelVisualizarPeli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(55)))), ((int)(((byte)(82)))));
            this.PanelVisualizarPeli.Controls.Add(this.PanelDescripcion);
            this.PanelVisualizarPeli.Controls.Add(this.PanelTrailerPeli);
            this.PanelVisualizarPeli.Controls.Add(this.BtnBuscarPelicula);
            this.PanelVisualizarPeli.Controls.Add(this.LblPanelPelicula);
            this.PanelVisualizarPeli.Controls.Add(this.PanelUsuario);
            this.PanelVisualizarPeli.Controls.Add(this.BtnPuntuar);
            this.PanelVisualizarPeli.Controls.Add(this.PanelPuntuacion);
            this.PanelVisualizarPeli.Controls.Add(this.PanelImagenPeli);
            this.PanelVisualizarPeli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelVisualizarPeli.Location = new System.Drawing.Point(0, 0);
            this.PanelVisualizarPeli.Name = "PanelVisualizarPeli";
            this.PanelVisualizarPeli.Size = new System.Drawing.Size(1260, 856);
            this.PanelVisualizarPeli.TabIndex = 0;
            // 
            // PanelDescripcion
            // 
            this.PanelDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelDescripcion.Controls.Add(this.LblDescripcionPeli);
            this.PanelDescripcion.Location = new System.Drawing.Point(371, 493);
            this.PanelDescripcion.Name = "PanelDescripcion";
            this.PanelDescripcion.Size = new System.Drawing.Size(794, 127);
            this.PanelDescripcion.TabIndex = 39;
            // 
            // LblDescripcionPeli
            // 
            this.LblDescripcionPeli.AutoSize = true;
            this.LblDescripcionPeli.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescripcionPeli.Location = new System.Drawing.Point(53, 38);
            this.LblDescripcionPeli.Name = "LblDescripcionPeli";
            this.LblDescripcionPeli.Size = new System.Drawing.Size(56, 23);
            this.LblDescripcionPeli.TabIndex = 0;
            this.LblDescripcionPeli.Text = "label1";
            // 
            // PanelTrailerPeli
            // 
            this.PanelTrailerPeli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelTrailerPeli.Controls.Add(this.WebBrowserPelicula);
            this.PanelTrailerPeli.Location = new System.Drawing.Point(371, 64);
            this.PanelTrailerPeli.Name = "PanelTrailerPeli";
            this.PanelTrailerPeli.Size = new System.Drawing.Size(794, 387);
            this.PanelTrailerPeli.TabIndex = 38;
            // 
            // WebBrowserPelicula
            // 
            this.WebBrowserPelicula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowserPelicula.Location = new System.Drawing.Point(0, 0);
            this.WebBrowserPelicula.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowserPelicula.Name = "WebBrowserPelicula";
            this.WebBrowserPelicula.Size = new System.Drawing.Size(794, 387);
            this.WebBrowserPelicula.TabIndex = 0;
            // 
            // BtnBuscarPelicula
            // 
            this.BtnBuscarPelicula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.BtnBuscarPelicula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscarPelicula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarPelicula.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarPelicula.ForeColor = System.Drawing.Color.Black;
            this.BtnBuscarPelicula.Location = new System.Drawing.Point(458, 656);
            this.BtnBuscarPelicula.Name = "BtnBuscarPelicula";
            this.BtnBuscarPelicula.Size = new System.Drawing.Size(151, 35);
            this.BtnBuscarPelicula.TabIndex = 37;
            this.BtnBuscarPelicula.Text = "Buscar";
            this.BtnBuscarPelicula.UseVisualStyleBackColor = false;
            this.BtnBuscarPelicula.Click += new System.EventHandler(this.BtnBuscarPelicula_Click);
            // 
            // LblPanelPelicula
            // 
            this.LblPanelPelicula.AutoSize = true;
            this.LblPanelPelicula.BackColor = System.Drawing.Color.Transparent;
            this.LblPanelPelicula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblPanelPelicula.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPanelPelicula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.LblPanelPelicula.Location = new System.Drawing.Point(64, 615);
            this.LblPanelPelicula.Name = "LblPanelPelicula";
            this.LblPanelPelicula.Size = new System.Drawing.Size(196, 24);
            this.LblPanelPelicula.TabIndex = 36;
            this.LblPanelPelicula.Text = "Nombre de la pelicula";
            // 
            // PanelUsuario
            // 
            this.PanelUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelUsuario.Controls.Add(this.TxtNombrePelicula);
            this.PanelUsuario.Location = new System.Drawing.Point(68, 654);
            this.PanelUsuario.Name = "PanelUsuario";
            this.PanelUsuario.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.PanelUsuario.Size = new System.Drawing.Size(273, 43);
            this.PanelUsuario.TabIndex = 35;
            // 
            // TxtNombrePelicula
            // 
            this.TxtNombrePelicula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.TxtNombrePelicula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNombrePelicula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtNombrePelicula.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombrePelicula.ForeColor = System.Drawing.Color.White;
            this.TxtNombrePelicula.Location = new System.Drawing.Point(7, 6);
            this.TxtNombrePelicula.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNombrePelicula.Name = "TxtNombrePelicula";
            this.TxtNombrePelicula.Size = new System.Drawing.Size(259, 27);
            this.TxtNombrePelicula.TabIndex = 12;
            // 
            // BtnPuntuar
            // 
            this.BtnPuntuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.BtnPuntuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPuntuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPuntuar.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPuntuar.ForeColor = System.Drawing.Color.Black;
            this.BtnPuntuar.Location = new System.Drawing.Point(925, 668);
            this.BtnPuntuar.Name = "BtnPuntuar";
            this.BtnPuntuar.Size = new System.Drawing.Size(151, 35);
            this.BtnPuntuar.TabIndex = 34;
            this.BtnPuntuar.Text = "Puntuar";
            this.BtnPuntuar.UseVisualStyleBackColor = false;
            // 
            // PanelPuntuacion
            // 
            this.PanelPuntuacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelPuntuacion.Controls.Add(this.LblPuntuacion);
            this.PanelPuntuacion.Location = new System.Drawing.Point(735, 654);
            this.PanelPuntuacion.Name = "PanelPuntuacion";
            this.PanelPuntuacion.Size = new System.Drawing.Size(129, 55);
            this.PanelPuntuacion.TabIndex = 1;
            // 
            // LblPuntuacion
            // 
            this.LblPuntuacion.AutoSize = true;
            this.LblPuntuacion.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuntuacion.Location = new System.Drawing.Point(36, 16);
            this.LblPuntuacion.Name = "LblPuntuacion";
            this.LblPuntuacion.Size = new System.Drawing.Size(0, 24);
            this.LblPuntuacion.TabIndex = 0;
            // 
            // PanelImagenPeli
            // 
            this.PanelImagenPeli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelImagenPeli.Controls.Add(this.PicPeliVisualizacion);
            this.PanelImagenPeli.Location = new System.Drawing.Point(68, 64);
            this.PanelImagenPeli.Name = "PanelImagenPeli";
            this.PanelImagenPeli.Size = new System.Drawing.Size(260, 387);
            this.PanelImagenPeli.TabIndex = 0;
            // 
            // PicPeliVisualizacion
            // 
            this.PicPeliVisualizacion.Location = new System.Drawing.Point(0, 0);
            this.PicPeliVisualizacion.Name = "PicPeliVisualizacion";
            this.PicPeliVisualizacion.Size = new System.Drawing.Size(257, 384);
            this.PicPeliVisualizacion.TabIndex = 0;
            this.PicPeliVisualizacion.TabStop = false;
            // 
            // ControlVisualizacionPeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelVisualizarPeli);
            this.Name = "ControlVisualizacionPeliculas";
            this.Size = new System.Drawing.Size(1260, 856);
            this.PanelVisualizarPeli.ResumeLayout(false);
            this.PanelVisualizarPeli.PerformLayout();
            this.PanelDescripcion.ResumeLayout(false);
            this.PanelDescripcion.PerformLayout();
            this.PanelTrailerPeli.ResumeLayout(false);
            this.PanelUsuario.ResumeLayout(false);
            this.PanelUsuario.PerformLayout();
            this.PanelPuntuacion.ResumeLayout(false);
            this.PanelPuntuacion.PerformLayout();
            this.PanelImagenPeli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPeliVisualizacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelVisualizarPeli;
        private System.Windows.Forms.Panel PanelImagenPeli;
        private System.Windows.Forms.PictureBox PicPeliVisualizacion;
        private System.Windows.Forms.Panel PanelPuntuacion;
        private System.Windows.Forms.Label LblPuntuacion;
        private System.Windows.Forms.Button BtnPuntuar;
        private System.Windows.Forms.Panel PanelUsuario;
        private System.Windows.Forms.TextBox TxtNombrePelicula;
        private System.Windows.Forms.Label LblPanelPelicula;
        private System.Windows.Forms.Button BtnBuscarPelicula;
        private System.Windows.Forms.Panel PanelTrailerPeli;
        private System.Windows.Forms.Panel PanelDescripcion;
        private System.Windows.Forms.Label LblDescripcionPeli;
        private System.Windows.Forms.WebBrowser WebBrowserPelicula;
    }
}
