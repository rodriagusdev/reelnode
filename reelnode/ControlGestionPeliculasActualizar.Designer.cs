namespace Reelnode
{
    partial class ControlGestionPeliculasActualizar
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
            this.components = new System.ComponentModel.Container();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.BtnPrevisualizar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtURLImagen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.PanelDescripcion = new System.Windows.Forms.Panel();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.PanelImagen = new System.Windows.Forms.Panel();
            this.PicPelicula = new System.Windows.Forms.PictureBox();
            this.PanelDuracion = new System.Windows.Forms.Panel();
            this.TxtDuracion = new System.Windows.Forms.TextBox();
            this.PanelDirector = new System.Windows.Forms.Panel();
            this.TxtDirector = new System.Windows.Forms.TextBox();
            this.PanelFecha = new System.Windows.Forms.Panel();
            this.DtpFechaEstreno = new System.Windows.Forms.DateTimePicker();
            this.PanelUsuario = new System.Windows.Forms.Panel();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.DataGridPeliculas = new System.Windows.Forms.DataGridView();
            this.CtxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtxMenuSubModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.CtxMenuSubEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnBuscarPelicula = new System.Windows.Forms.Button();
            this.PanelBuscarPeliculaNombre = new System.Windows.Forms.Panel();
            this.TxtBuscarNombrePelicula = new System.Windows.Forms.TextBox();
            this.PanelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelDescripcion.SuspendLayout();
            this.PanelImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPelicula)).BeginInit();
            this.PanelDuracion.SuspendLayout();
            this.PanelDirector.SuspendLayout();
            this.PanelFecha.SuspendLayout();
            this.PanelUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPeliculas)).BeginInit();
            this.CtxMenu.SuspendLayout();
            this.PanelBuscarPeliculaNombre.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.BtnPrevisualizar);
            this.PanelMain.Controls.Add(this.label6);
            this.PanelMain.Controls.Add(this.label8);
            this.PanelMain.Controls.Add(this.panel1);
            this.PanelMain.Controls.Add(this.label5);
            this.PanelMain.Controls.Add(this.label4);
            this.PanelMain.Controls.Add(this.label3);
            this.PanelMain.Controls.Add(this.label2);
            this.PanelMain.Controls.Add(this.label1);
            this.PanelMain.Controls.Add(this.BtnActualizar);
            this.PanelMain.Controls.Add(this.PanelDescripcion);
            this.PanelMain.Controls.Add(this.PanelImagen);
            this.PanelMain.Controls.Add(this.PanelDuracion);
            this.PanelMain.Controls.Add(this.PanelDirector);
            this.PanelMain.Controls.Add(this.PanelFecha);
            this.PanelMain.Controls.Add(this.PanelUsuario);
            this.PanelMain.Controls.Add(this.DataGridPeliculas);
            this.PanelMain.Controls.Add(this.label7);
            this.PanelMain.Controls.Add(this.BtnBuscarPelicula);
            this.PanelMain.Controls.Add(this.PanelBuscarPeliculaNombre);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(1280, 720);
            this.PanelMain.TabIndex = 2;
            this.PanelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelMain_Paint);
            // 
            // BtnPrevisualizar
            // 
            this.BtnPrevisualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.BtnPrevisualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrevisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrevisualizar.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrevisualizar.ForeColor = System.Drawing.Color.Black;
            this.BtnPrevisualizar.Location = new System.Drawing.Point(441, 504);
            this.BtnPrevisualizar.Name = "BtnPrevisualizar";
            this.BtnPrevisualizar.Size = new System.Drawing.Size(205, 35);
            this.BtnPrevisualizar.TabIndex = 62;
            this.BtnPrevisualizar.Text = "Previsualizar";
            this.BtnPrevisualizar.UseVisualStyleBackColor = false;
            this.BtnPrevisualizar.Click += new System.EventHandler(this.BtnPrevisualizar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.label6.Location = new System.Drawing.Point(438, 413);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 61;
            this.label6.Text = "URL de la imagen";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.label8.Location = new System.Drawing.Point(438, 469);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 17);
            this.label8.TabIndex = 60;
            this.label8.Text = "e.g. \"https://sitio/content//imagen.jpg\"";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.panel1.Controls.Add(this.TxtURLImagen);
            this.panel1.Location = new System.Drawing.Point(441, 433);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(205, 35);
            this.panel1.TabIndex = 59;
            // 
            // TxtURLImagen
            // 
            this.TxtURLImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.TxtURLImagen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtURLImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtURLImagen.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtURLImagen.ForeColor = System.Drawing.Color.White;
            this.TxtURLImagen.Location = new System.Drawing.Point(5, 5);
            this.TxtURLImagen.Name = "TxtURLImagen";
            this.TxtURLImagen.Size = new System.Drawing.Size(195, 22);
            this.TxtURLImagen.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.label5.Location = new System.Drawing.Point(691, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 58;
            this.label5.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.label4.Location = new System.Drawing.Point(186, 484);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "Duración";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.label3.Location = new System.Drawing.Point(185, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "Director";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.label2.Location = new System.Drawing.Point(185, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "Fecha de estreno";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.label1.Location = new System.Drawing.Point(186, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Título";
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.BtnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnActualizar.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.ForeColor = System.Drawing.Color.Black;
            this.BtnActualizar.Location = new System.Drawing.Point(694, 504);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(362, 35);
            this.BtnActualizar.TabIndex = 54;
            this.BtnActualizar.Text = "Actualizar Pelicula";
            this.BtnActualizar.UseVisualStyleBackColor = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // PanelDescripcion
            // 
            this.PanelDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelDescripcion.Controls.Add(this.TxtDescripcion);
            this.PanelDescripcion.Location = new System.Drawing.Point(694, 287);
            this.PanelDescripcion.Name = "PanelDescripcion";
            this.PanelDescripcion.Padding = new System.Windows.Forms.Padding(5);
            this.PanelDescripcion.Size = new System.Drawing.Size(362, 181);
            this.PanelDescripcion.TabIndex = 49;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.TxtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDescripcion.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescripcion.ForeColor = System.Drawing.Color.White;
            this.TxtDescripcion.Location = new System.Drawing.Point(5, 5);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(352, 171);
            this.TxtDescripcion.TabIndex = 12;
            // 
            // PanelImagen
            // 
            this.PanelImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelImagen.Controls.Add(this.PicPelicula);
            this.PanelImagen.Location = new System.Drawing.Point(441, 287);
            this.PanelImagen.Name = "PanelImagen";
            this.PanelImagen.Padding = new System.Windows.Forms.Padding(5);
            this.PanelImagen.Size = new System.Drawing.Size(205, 107);
            this.PanelImagen.TabIndex = 53;
            // 
            // PicPelicula
            // 
            this.PicPelicula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PicPelicula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicPelicula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPelicula.Location = new System.Drawing.Point(5, 5);
            this.PicPelicula.Name = "PicPelicula";
            this.PicPelicula.Size = new System.Drawing.Size(195, 97);
            this.PicPelicula.TabIndex = 0;
            this.PicPelicula.TabStop = false;
            // 
            // PanelDuracion
            // 
            this.PanelDuracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelDuracion.Controls.Add(this.TxtDuracion);
            this.PanelDuracion.Location = new System.Drawing.Point(188, 504);
            this.PanelDuracion.Name = "PanelDuracion";
            this.PanelDuracion.Padding = new System.Windows.Forms.Padding(5);
            this.PanelDuracion.Size = new System.Drawing.Size(205, 35);
            this.PanelDuracion.TabIndex = 52;
            // 
            // TxtDuracion
            // 
            this.TxtDuracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.TxtDuracion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDuracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDuracion.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDuracion.ForeColor = System.Drawing.Color.White;
            this.TxtDuracion.Location = new System.Drawing.Point(5, 5);
            this.TxtDuracion.Name = "TxtDuracion";
            this.TxtDuracion.Size = new System.Drawing.Size(195, 22);
            this.TxtDuracion.TabIndex = 12;
            // 
            // PanelDirector
            // 
            this.PanelDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelDirector.Controls.Add(this.TxtDirector);
            this.PanelDirector.Location = new System.Drawing.Point(188, 433);
            this.PanelDirector.Name = "PanelDirector";
            this.PanelDirector.Padding = new System.Windows.Forms.Padding(5);
            this.PanelDirector.Size = new System.Drawing.Size(205, 35);
            this.PanelDirector.TabIndex = 50;
            // 
            // TxtDirector
            // 
            this.TxtDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.TxtDirector.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDirector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDirector.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDirector.ForeColor = System.Drawing.Color.White;
            this.TxtDirector.Location = new System.Drawing.Point(5, 5);
            this.TxtDirector.Name = "TxtDirector";
            this.TxtDirector.Size = new System.Drawing.Size(195, 22);
            this.TxtDirector.TabIndex = 12;
            // 
            // PanelFecha
            // 
            this.PanelFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelFecha.Controls.Add(this.DtpFechaEstreno);
            this.PanelFecha.Location = new System.Drawing.Point(188, 359);
            this.PanelFecha.Name = "PanelFecha";
            this.PanelFecha.Padding = new System.Windows.Forms.Padding(5);
            this.PanelFecha.Size = new System.Drawing.Size(205, 35);
            this.PanelFecha.TabIndex = 51;
            // 
            // DtpFechaEstreno
            // 
            this.DtpFechaEstreno.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFechaEstreno.Location = new System.Drawing.Point(5, 6);
            this.DtpFechaEstreno.Name = "DtpFechaEstreno";
            this.DtpFechaEstreno.Size = new System.Drawing.Size(192, 24);
            this.DtpFechaEstreno.TabIndex = 0;
            // 
            // PanelUsuario
            // 
            this.PanelUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelUsuario.Controls.Add(this.TxtNombre);
            this.PanelUsuario.Location = new System.Drawing.Point(189, 287);
            this.PanelUsuario.Name = "PanelUsuario";
            this.PanelUsuario.Padding = new System.Windows.Forms.Padding(5);
            this.PanelUsuario.Size = new System.Drawing.Size(205, 35);
            this.PanelUsuario.TabIndex = 48;
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.TxtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtNombre.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.ForeColor = System.Drawing.Color.White;
            this.TxtNombre.Location = new System.Drawing.Point(5, 5);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(195, 22);
            this.TxtNombre.TabIndex = 12;
            // 
            // DataGridPeliculas
            // 
            this.DataGridPeliculas.AllowUserToAddRows = false;
            this.DataGridPeliculas.AllowUserToDeleteRows = false;
            this.DataGridPeliculas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridPeliculas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.DataGridPeliculas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridPeliculas.ContextMenuStrip = this.CtxMenu;
            this.DataGridPeliculas.Location = new System.Drawing.Point(188, 152);
            this.DataGridPeliculas.Name = "DataGridPeliculas";
            this.DataGridPeliculas.ReadOnly = true;
            this.DataGridPeliculas.Size = new System.Drawing.Size(868, 106);
            this.DataGridPeliculas.TabIndex = 47;
            this.DataGridPeliculas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridPeliculas_CellContentClick);
            this.DataGridPeliculas.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridPeliculas_CellMouseDown);
            // 
            // CtxMenu
            // 
            this.CtxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtxMenuSubModificar,
            this.CtxMenuSubEliminar});
            this.CtxMenu.Name = "CtxMenu";
            this.CtxMenu.Size = new System.Drawing.Size(158, 48);
            // 
            // CtxMenuSubModificar
            // 
            this.CtxMenuSubModificar.Name = "CtxMenuSubModificar";
            this.CtxMenuSubModificar.Size = new System.Drawing.Size(157, 22);
            this.CtxMenuSubModificar.Text = "Modificar datos";
            this.CtxMenuSubModificar.Click += new System.EventHandler(this.CtxMenuSubModificar_Click);
            // 
            // CtxMenuSubEliminar
            // 
            this.CtxMenuSubEliminar.Name = "CtxMenuSubEliminar";
            this.CtxMenuSubEliminar.Size = new System.Drawing.Size(157, 22);
            this.CtxMenuSubEliminar.Text = "Eliminar";
            this.CtxMenuSubEliminar.Click += new System.EventHandler(this.CtxMenuSubEliminar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(239)))));
            this.label7.Location = new System.Drawing.Point(186, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 17);
            this.label7.TabIndex = 46;
            this.label7.Text = "Ingrese el nombre de la película";
            // 
            // BtnBuscarPelicula
            // 
            this.BtnBuscarPelicula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.BtnBuscarPelicula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscarPelicula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarPelicula.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarPelicula.ForeColor = System.Drawing.Color.Black;
            this.BtnBuscarPelicula.Location = new System.Drawing.Point(441, 107);
            this.BtnBuscarPelicula.Name = "BtnBuscarPelicula";
            this.BtnBuscarPelicula.Size = new System.Drawing.Size(205, 35);
            this.BtnBuscarPelicula.TabIndex = 45;
            this.BtnBuscarPelicula.Text = "Buscar";
            this.BtnBuscarPelicula.UseVisualStyleBackColor = false;
            this.BtnBuscarPelicula.Click += new System.EventHandler(this.BtnBuscarPelicula_Click);
            // 
            // PanelBuscarPeliculaNombre
            // 
            this.PanelBuscarPeliculaNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelBuscarPeliculaNombre.Controls.Add(this.TxtBuscarNombrePelicula);
            this.PanelBuscarPeliculaNombre.Location = new System.Drawing.Point(189, 107);
            this.PanelBuscarPeliculaNombre.Name = "PanelBuscarPeliculaNombre";
            this.PanelBuscarPeliculaNombre.Padding = new System.Windows.Forms.Padding(5);
            this.PanelBuscarPeliculaNombre.Size = new System.Drawing.Size(205, 35);
            this.PanelBuscarPeliculaNombre.TabIndex = 44;
            // 
            // TxtBuscarNombrePelicula
            // 
            this.TxtBuscarNombrePelicula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.TxtBuscarNombrePelicula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtBuscarNombrePelicula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBuscarNombrePelicula.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscarNombrePelicula.ForeColor = System.Drawing.Color.White;
            this.TxtBuscarNombrePelicula.Location = new System.Drawing.Point(5, 5);
            this.TxtBuscarNombrePelicula.Name = "TxtBuscarNombrePelicula";
            this.TxtBuscarNombrePelicula.Size = new System.Drawing.Size(195, 22);
            this.TxtBuscarNombrePelicula.TabIndex = 12;
            // 
            // ControlGestionPeliculasActualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(55)))), ((int)(((byte)(82)))));
            this.Controls.Add(this.PanelMain);
            this.Name = "ControlGestionPeliculasActualizar";
            this.Size = new System.Drawing.Size(1280, 720);
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelDescripcion.ResumeLayout(false);
            this.PanelDescripcion.PerformLayout();
            this.PanelImagen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPelicula)).EndInit();
            this.PanelDuracion.ResumeLayout(false);
            this.PanelDuracion.PerformLayout();
            this.PanelDirector.ResumeLayout(false);
            this.PanelDirector.PerformLayout();
            this.PanelFecha.ResumeLayout(false);
            this.PanelUsuario.ResumeLayout(false);
            this.PanelUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPeliculas)).EndInit();
            this.CtxMenu.ResumeLayout(false);
            this.PanelBuscarPeliculaNombre.ResumeLayout(false);
            this.PanelBuscarPeliculaNombre.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Panel PanelDescripcion;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Panel PanelImagen;
        private System.Windows.Forms.PictureBox PicPelicula;
        private System.Windows.Forms.Panel PanelDuracion;
        private System.Windows.Forms.TextBox TxtDuracion;
        private System.Windows.Forms.Panel PanelDirector;
        private System.Windows.Forms.TextBox TxtDirector;
        private System.Windows.Forms.Panel PanelFecha;
        private System.Windows.Forms.DateTimePicker DtpFechaEstreno;
        private System.Windows.Forms.Panel PanelUsuario;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.DataGridView DataGridPeliculas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnBuscarPelicula;
        private System.Windows.Forms.Panel PanelBuscarPeliculaNombre;
        private System.Windows.Forms.TextBox TxtBuscarNombrePelicula;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.ContextMenuStrip CtxMenu;
        private System.Windows.Forms.ToolStripMenuItem CtxMenuSubModificar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem CtxMenuSubEliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtURLImagen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnPrevisualizar;
    }
}
