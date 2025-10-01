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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LblDuracion = new System.Windows.Forms.Label();
            this.LblDirector = new System.Windows.Forms.Label();
            this.PanelTrailerPeli = new System.Windows.Forms.Panel();
            this.BtnPuntuar = new System.Windows.Forms.Button();
            this.PanelImagenPeli = new System.Windows.Forms.Panel();
            this.PicPeli = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblDescripcionPeli = new System.Windows.Forms.Label();
            this.PanelDescripcion = new System.Windows.Forms.Panel();
            this.PanelVisualizarPeli.SuspendLayout();
            this.PanelImagenPeli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPeli)).BeginInit();
            this.PanelDescripcion.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelVisualizarPeli
            // 
            this.PanelVisualizarPeli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(55)))), ((int)(((byte)(82)))));
            this.PanelVisualizarPeli.Controls.Add(this.panel2);
            this.PanelVisualizarPeli.Controls.Add(this.LblTitulo);
            this.PanelVisualizarPeli.Controls.Add(this.panel1);
            this.PanelVisualizarPeli.Controls.Add(this.label2);
            this.PanelVisualizarPeli.Controls.Add(this.label1);
            this.PanelVisualizarPeli.Controls.Add(this.button1);
            this.PanelVisualizarPeli.Controls.Add(this.LblDuracion);
            this.PanelVisualizarPeli.Controls.Add(this.LblDirector);
            this.PanelVisualizarPeli.Controls.Add(this.PanelDescripcion);
            this.PanelVisualizarPeli.Controls.Add(this.PanelTrailerPeli);
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
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.label2.Location = new System.Drawing.Point(520, 453);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 28);
            this.label2.TabIndex = 44;
            this.label2.Tag = "Titulo";
            this.label2.Text = "Sinopsis";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.label1.Location = new System.Drawing.Point(90, 563);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 28);
            this.label1.TabIndex = 43;
            this.label1.Tag = "Titulo";
            this.label1.Text = "Director";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(970, 579);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 35);
            this.button1.TabIndex = 42;
            this.button1.Text = "Agregar comentario";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // LblDuracion
            // 
            this.LblDuracion.BackColor = System.Drawing.Color.Transparent;
            this.LblDuracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblDuracion.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDuracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.LblDuracion.Location = new System.Drawing.Point(91, 539);
            this.LblDuracion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblDuracion.Name = "LblDuracion";
            this.LblDuracion.Size = new System.Drawing.Size(107, 24);
            this.LblDuracion.TabIndex = 41;
            this.LblDuracion.Text = "LblDuracion";
            // 
            // LblDirector
            // 
            this.LblDirector.BackColor = System.Drawing.Color.Transparent;
            this.LblDirector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblDirector.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDirector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.LblDirector.Location = new System.Drawing.Point(91, 591);
            this.LblDirector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblDirector.Name = "LblDirector";
            this.LblDirector.Size = new System.Drawing.Size(108, 24);
            this.LblDirector.TabIndex = 40;
            this.LblDirector.Text = "LblDirector";
            // 
            // PanelTrailerPeli
            // 
            this.PanelTrailerPeli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelTrailerPeli.Location = new System.Drawing.Point(524, 57);
            this.PanelTrailerPeli.Margin = new System.Windows.Forms.Padding(2);
            this.PanelTrailerPeli.Name = "PanelTrailerPeli";
            this.PanelTrailerPeli.Size = new System.Drawing.Size(649, 384);
            this.PanelTrailerPeli.TabIndex = 38;
            // 
            // BtnPuntuar
            // 
            this.BtnPuntuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.BtnPuntuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPuntuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPuntuar.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPuntuar.ForeColor = System.Drawing.Color.Black;
            this.BtnPuntuar.Location = new System.Drawing.Point(524, 579);
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
            this.PanelImagenPeli.Location = new System.Drawing.Point(94, 57);
            this.PanelImagenPeli.Margin = new System.Windows.Forms.Padding(2);
            this.PanelImagenPeli.Name = "PanelImagenPeli";
            this.PanelImagenPeli.Size = new System.Drawing.Size(393, 439);
            this.PanelImagenPeli.TabIndex = 0;
            // 
            // PicPeli
            // 
            this.PicPeli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPeli.Location = new System.Drawing.Point(0, 0);
            this.PicPeli.Margin = new System.Windows.Forms.Padding(2);
            this.PicPeli.Name = "PicPeli";
            this.PicPeli.Size = new System.Drawing.Size(393, 439);
            this.PicPeli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicPeli.TabIndex = 0;
            this.PicPeli.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(94, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 2);
            this.panel1.TabIndex = 45;
            this.panel1.Tag = "Default";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.panel2.Location = new System.Drawing.Point(94, 658);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 2);
            this.panel2.TabIndex = 46;
            this.panel2.Tag = "Default";
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblTitulo.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.LblTitulo.Location = new System.Drawing.Point(88, 507);
            this.LblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(158, 31);
            this.LblTitulo.TabIndex = 36;
            this.LblTitulo.Tag = "Titulo";
            this.LblTitulo.Text = "LblTitulo";
            // 
            // LblDescripcionPeli
            // 
            this.LblDescripcionPeli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDescripcionPeli.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescripcionPeli.Location = new System.Drawing.Point(0, 0);
            this.LblDescripcionPeli.Margin = new System.Windows.Forms.Padding(0);
            this.LblDescripcionPeli.Name = "LblDescripcionPeli";
            this.LblDescripcionPeli.Size = new System.Drawing.Size(651, 80);
            this.LblDescripcionPeli.TabIndex = 0;
            this.LblDescripcionPeli.Tag = "Default";
            this.LblDescripcionPeli.Text = "label1";
            this.LblDescripcionPeli.Click += new System.EventHandler(this.LblDescripcionPeli_Click);
            // 
            // PanelDescripcion
            // 
            this.PanelDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.PanelDescripcion.Controls.Add(this.LblDescripcionPeli);
            this.PanelDescripcion.Location = new System.Drawing.Point(524, 481);
            this.PanelDescripcion.Margin = new System.Windows.Forms.Padding(0);
            this.PanelDescripcion.Name = "PanelDescripcion";
            this.PanelDescripcion.Size = new System.Drawing.Size(651, 80);
            this.PanelDescripcion.TabIndex = 39;
            this.PanelDescripcion.Tag = "Default";
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
            this.PanelVisualizarPeli.PerformLayout();
            this.PanelImagenPeli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPeli)).EndInit();
            this.PanelDescripcion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelVisualizarPeli;
        private System.Windows.Forms.Panel PanelImagenPeli;
        private System.Windows.Forms.PictureBox PicPeli;
        private System.Windows.Forms.Button BtnPuntuar;
        private System.Windows.Forms.Panel PanelTrailerPeli;
        private System.Windows.Forms.Label LblDuracion;
        private System.Windows.Forms.Label LblDirector;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel PanelDescripcion;
        private System.Windows.Forms.Label LblDescripcionPeli;
    }
}
