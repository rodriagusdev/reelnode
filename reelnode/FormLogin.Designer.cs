namespace ProjectoNuevo
{
    partial class FormLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnIngresar = new System.Windows.Forms.Button();
            this.PanelUsuario = new System.Windows.Forms.Panel();
            this.LblPanelUsuario = new System.Windows.Forms.Label();
            this.PanelUsuarioLinea = new System.Windows.Forms.Panel();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblRegistrar = new System.Windows.Forms.Label();
            this.PanelPassword = new System.Windows.Forms.Panel();
            this.LblPanelPassword = new System.Windows.Forms.Label();
            this.PanelPasswordLinea = new System.Windows.Forms.Panel();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.PanelUsuario.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.BtnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIngresar.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIngresar.ForeColor = System.Drawing.Color.White;
            this.BtnIngresar.Location = new System.Drawing.Point(55, 322);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new System.Drawing.Size(307, 52);
            this.BtnIngresar.TabIndex = 13;
            this.BtnIngresar.Text = "I  N  G  R  E  S  A  R";
            this.BtnIngresar.UseVisualStyleBackColor = false;
            this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click_1);
            // 
            // PanelUsuario
            // 
            this.PanelUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.PanelUsuario.Controls.Add(this.LblPanelUsuario);
            this.PanelUsuario.Controls.Add(this.PanelUsuarioLinea);
            this.PanelUsuario.Controls.Add(this.TxtUsuario);
            this.PanelUsuario.Location = new System.Drawing.Point(55, 165);
            this.PanelUsuario.Name = "PanelUsuario";
            this.PanelUsuario.Padding = new System.Windows.Forms.Padding(5);
            this.PanelUsuario.Size = new System.Drawing.Size(306, 35);
            this.PanelUsuario.TabIndex = 18;
            // 
            // LblPanelUsuario
            // 
            this.LblPanelUsuario.AutoSize = true;
            this.LblPanelUsuario.BackColor = System.Drawing.Color.Transparent;
            this.LblPanelUsuario.Enabled = false;
            this.LblPanelUsuario.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPanelUsuario.ForeColor = System.Drawing.Color.White;
            this.LblPanelUsuario.Location = new System.Drawing.Point(8, 5);
            this.LblPanelUsuario.Name = "LblPanelUsuario";
            this.LblPanelUsuario.Size = new System.Drawing.Size(50, 17);
            this.LblPanelUsuario.TabIndex = 21;
            this.LblPanelUsuario.Text = "Usuario";
            // 
            // PanelUsuarioLinea
            // 
            this.PanelUsuarioLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(184)))), ((int)(((byte)(182)))));
            this.PanelUsuarioLinea.Location = new System.Drawing.Point(8, 25);
            this.PanelUsuarioLinea.Name = "PanelUsuarioLinea";
            this.PanelUsuarioLinea.Size = new System.Drawing.Size(291, 2);
            this.PanelUsuarioLinea.TabIndex = 20;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtUsuario.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.ForeColor = System.Drawing.Color.White;
            this.TxtUsuario.Location = new System.Drawing.Point(5, 5);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(296, 22);
            this.TxtUsuario.TabIndex = 12;
            this.TxtUsuario.TextChanged += new System.EventHandler(this.TxtUsuario_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.LblRegistrar);
            this.panel1.Controls.Add(this.PanelPassword);
            this.panel1.Controls.Add(this.PanelUsuario);
            this.panel1.Controls.Add(this.BtnIngresar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 447);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.White;
            this.BtnSalir.Location = new System.Drawing.Point(126, 380);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(154, 38);
            this.BtnSalir.TabIndex = 25;
            this.BtnSalir.Text = "S   A   L   I   R";
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click_1);
            // 
            // LblRegistrar
            // 
            this.LblRegistrar.AutoSize = true;
            this.LblRegistrar.BackColor = System.Drawing.Color.Transparent;
            this.LblRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblRegistrar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegistrar.ForeColor = System.Drawing.Color.Turquoise;
            this.LblRegistrar.Location = new System.Drawing.Point(98, 275);
            this.LblRegistrar.Name = "LblRegistrar";
            this.LblRegistrar.Size = new System.Drawing.Size(206, 18);
            this.LblRegistrar.TabIndex = 24;
            this.LblRegistrar.Text = "¿Usuario nuevo? Registrarse aquí";
            this.LblRegistrar.Click += new System.EventHandler(this.LblRegistrar_Click);
            // 
            // PanelPassword
            // 
            this.PanelPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.PanelPassword.Controls.Add(this.LblPanelPassword);
            this.PanelPassword.Controls.Add(this.PanelPasswordLinea);
            this.PanelPassword.Controls.Add(this.TxtPassword);
            this.PanelPassword.Location = new System.Drawing.Point(56, 227);
            this.PanelPassword.Name = "PanelPassword";
            this.PanelPassword.Padding = new System.Windows.Forms.Padding(5);
            this.PanelPassword.Size = new System.Drawing.Size(306, 35);
            this.PanelPassword.TabIndex = 22;
            // 
            // LblPanelPassword
            // 
            this.LblPanelPassword.AutoSize = true;
            this.LblPanelPassword.BackColor = System.Drawing.Color.Transparent;
            this.LblPanelPassword.Enabled = false;
            this.LblPanelPassword.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPanelPassword.ForeColor = System.Drawing.Color.White;
            this.LblPanelPassword.Location = new System.Drawing.Point(8, 5);
            this.LblPanelPassword.Name = "LblPanelPassword";
            this.LblPanelPassword.Size = new System.Drawing.Size(70, 17);
            this.LblPanelPassword.TabIndex = 21;
            this.LblPanelPassword.Text = "Contraseña";
            // 
            // PanelPasswordLinea
            // 
            this.PanelPasswordLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(184)))), ((int)(((byte)(182)))));
            this.PanelPasswordLinea.Location = new System.Drawing.Point(8, 25);
            this.PanelPasswordLinea.Name = "PanelPasswordLinea";
            this.PanelPasswordLinea.Size = new System.Drawing.Size(291, 2);
            this.PanelPasswordLinea.TabIndex = 20;
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPassword.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.ForeColor = System.Drawing.Color.White;
            this.TxtPassword.Location = new System.Drawing.Point(5, 5);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(296, 22);
            this.TxtPassword.TabIndex = 12;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::ProjectoNuevo.Properties.Resources.logo1;
            this.pictureBox1.InitialImage = global::ProjectoNuevo.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(15, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(377, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(184)))), ((int)(((byte)(182)))));
            this.ClientSize = new System.Drawing.Size(448, 487);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.PanelUsuario.ResumeLayout(false);
            this.PanelUsuario.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelPassword.ResumeLayout(false);
            this.PanelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnIngresar;
        private System.Windows.Forms.Panel PanelUsuario;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelUsuarioLinea;
        private System.Windows.Forms.Label LblPanelUsuario;
        private System.Windows.Forms.Panel PanelPassword;
        private System.Windows.Forms.Label LblPanelPassword;
        private System.Windows.Forms.Panel PanelPasswordLinea;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label LblRegistrar;
        private System.Windows.Forms.Button BtnSalir;
    }
}