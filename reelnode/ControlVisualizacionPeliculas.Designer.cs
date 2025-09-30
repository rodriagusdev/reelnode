namespace Reelnode
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnPuntuar = new System.Windows.Forms.Button();
            this.PanelImagenPeli = new System.Windows.Forms.Panel();
            this.PicPeli = new System.Windows.Forms.PictureBox();
            this.LblDirector = new System.Windows.Forms.Label();
            this.LblDuracion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.PanelVisualizarPeli.SuspendLayout();
            this.PanelDescripcion.SuspendLayout();
            this.PanelTrailerPeli.SuspendLayout();
            this.PanelImagenPeli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPeli)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelVisualizarPeli
            // 
            this.PanelVisualizarPeli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(55)))), ((int)(((byte)(82)))));
            this.PanelVisualizarPeli.Controls.Add(this.button1);
            this.PanelVisualizarPeli.Controls.Add(this.LblDuracion);
            this.PanelVisualizarPeli.Controls.Add(this.LblDirector);
            this.PanelVisualizarPeli.Controls.Add(this.PanelDescripcion);
            this.PanelVisualizarPeli.Controls.Add(this.PanelTrailerPeli);
            this.PanelVisualizarPeli.Controls.Add(this.LblTitulo);
            this.PanelVisualizarPeli.Controls.Add(this.BtnPuntuar);
            this.PanelVisualizarPeli.Controls.Add(this.PanelImagenPeli);
            this.PanelVisualizarPeli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelVisualizarPeli.Location = new System.Drawing.Point(0, 0);
            this.PanelVisualizarPeli.Margin = new System.Windows.Forms.Padding(2);
            this.PanelVisualizarPeli.Name = "PanelVisualizarPeli";
            this.PanelVisualizarPeli.Size = new System.Drawing.Size(1280, 720);
            this.PanelVisualizarPeli.TabIndex = 0;
            this.PanelVisualizarPeli.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelVisualizarPeli_Paint);
            // 
            // PanelDescripcion
            // 
            this.PanelDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.PanelDescripcion.Controls.Add(this.LblDescripcionPeli);
            this.PanelDescripcion.Location = new System.Drawing.Point(401, 387);
            this.PanelDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.PanelDescripcion.Name = "PanelDescripcion";
            this.PanelDescripcion.Size = new System.Drawing.Size(596, 103);
            this.PanelDescripcion.TabIndex = 39;
            this.PanelDescripcion.Tag = "Default";
            // 
            // LblDescripcionPeli
            // 
            this.LblDescripcionPeli.AutoSize = true;
            this.LblDescripcionPeli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDescripcionPeli.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescripcionPeli.Location = new System.Drawing.Point(0, 0);
            this.LblDescripcionPeli.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblDescripcionPeli.Name = "LblDescripcionPeli";
            this.LblDescripcionPeli.Size = new System.Drawing.Size(45, 19);
            this.LblDescripcionPeli.TabIndex = 0;
            this.LblDescripcionPeli.Text = "label1";
            // 
            // PanelTrailerPeli
            // 
            this.PanelTrailerPeli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelTrailerPeli.Controls.Add(this.WebBrowserPelicula);
            this.PanelTrailerPeli.Location = new System.Drawing.Point(401, 59);
            this.PanelTrailerPeli.Margin = new System.Windows.Forms.Padding(2);
            this.PanelTrailerPeli.Name = "PanelTrailerPeli";
            this.PanelTrailerPeli.Size = new System.Drawing.Size(596, 314);
            this.PanelTrailerPeli.TabIndex = 38;
            // 
            // WebBrowserPelicula
            // 
            this.WebBrowserPelicula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowserPelicula.Location = new System.Drawing.Point(0, 0);
            this.WebBrowserPelicula.Margin = new System.Windows.Forms.Padding(2);
            this.WebBrowserPelicula.MinimumSize = new System.Drawing.Size(15, 16);
            this.WebBrowserPelicula.Name = "WebBrowserPelicula";
            this.WebBrowserPelicula.Size = new System.Drawing.Size(596, 314);
            this.WebBrowserPelicula.TabIndex = 0;
            this.WebBrowserPelicula.Url = new System.Uri("https://www.youtube.com/watch?v=UPgUIORqja4", System.UriKind.Absolute);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblTitulo.Font = new System.Drawing.Font("Cascadia Code", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.LblTitulo.Location = new System.Drawing.Point(90, 40);
            this.LblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(296, 71);
            this.LblTitulo.TabIndex = 36;
            this.LblTitulo.Text = "Nombre de la pelicula";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnPuntuar
            // 
            this.BtnPuntuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.BtnPuntuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPuntuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPuntuar.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPuntuar.ForeColor = System.Drawing.Color.Black;
            this.BtnPuntuar.Location = new System.Drawing.Point(401, 517);
            this.BtnPuntuar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnPuntuar.Name = "BtnPuntuar";
            this.BtnPuntuar.Size = new System.Drawing.Size(205, 35);
            this.BtnPuntuar.TabIndex = 34;
            this.BtnPuntuar.Text = "Puntuar";
            this.BtnPuntuar.UseVisualStyleBackColor = false;
            // 
            // PanelImagenPeli
            // 
            this.PanelImagenPeli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelImagenPeli.Controls.Add(this.PicPeli);
            this.PanelImagenPeli.Location = new System.Drawing.Point(107, 113);
            this.PanelImagenPeli.Margin = new System.Windows.Forms.Padding(2);
            this.PanelImagenPeli.Name = "PanelImagenPeli";
            this.PanelImagenPeli.Size = new System.Drawing.Size(266, 260);
            this.PanelImagenPeli.TabIndex = 0;
            // 
            // PicPeli
            // 
            this.PicPeli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPeli.Location = new System.Drawing.Point(0, 0);
            this.PicPeli.Margin = new System.Windows.Forms.Padding(2);
            this.PicPeli.Name = "PicPeli";
            this.PicPeli.Size = new System.Drawing.Size(266, 260);
            this.PicPeli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicPeli.TabIndex = 0;
            this.PicPeli.TabStop = false;
            // 
            // LblDirector
            // 
            this.LblDirector.BackColor = System.Drawing.Color.Transparent;
            this.LblDirector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblDirector.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDirector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.LblDirector.Location = new System.Drawing.Point(104, 375);
            this.LblDirector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblDirector.Name = "LblDirector";
            this.LblDirector.Size = new System.Drawing.Size(197, 24);
            this.LblDirector.TabIndex = 40;
            this.LblDirector.Text = "Director de la pelicula";
            // 
            // LblDuracion
            // 
            this.LblDuracion.BackColor = System.Drawing.Color.Transparent;
            this.LblDuracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblDuracion.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDuracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.LblDuracion.Location = new System.Drawing.Point(104, 399);
            this.LblDuracion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblDuracion.Name = "LblDuracion";
            this.LblDuracion.Size = new System.Drawing.Size(197, 24);
            this.LblDuracion.TabIndex = 41;
            this.LblDuracion.Text = "Duracion de la pelicula";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(792, 517);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 35);
            this.button1.TabIndex = 42;
            this.button1.Text = "Agregar comentario";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ControlVisualizacionPeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.PanelVisualizarPeli);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlVisualizacionPeliculas";
            this.Size = new System.Drawing.Size(1280, 720);
            this.VisibleChanged += new System.EventHandler(this.ControlVisualizacionPeliculas_VisibleChanged);
            this.PanelVisualizarPeli.ResumeLayout(false);
            this.PanelDescripcion.ResumeLayout(false);
            this.PanelDescripcion.PerformLayout();
            this.PanelTrailerPeli.ResumeLayout(false);
            this.PanelImagenPeli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPeli)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelVisualizarPeli;
        private System.Windows.Forms.Panel PanelImagenPeli;
        private System.Windows.Forms.PictureBox PicPeli;
        private System.Windows.Forms.Button BtnPuntuar;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel PanelTrailerPeli;
        private System.Windows.Forms.Panel PanelDescripcion;
        private System.Windows.Forms.WebBrowser WebBrowserPelicula;
        private System.Windows.Forms.Label LblDescripcionPeli;
        private System.Windows.Forms.Label LblDuracion;
        private System.Windows.Forms.Label LblDirector;
        private System.Windows.Forms.Button button1;
    }
}
