namespace Reelnode
{
    partial class FormRegistrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrar));
            this.PanelMain = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.PanelEmail = new System.Windows.Forms.Panel();
            this.LblPanelEmail = new System.Windows.Forms.Label();
            this.PanelEmailLinea = new System.Windows.Forms.Panel();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.PanelPassword = new System.Windows.Forms.Panel();
            this.LblPanelPassword = new System.Windows.Forms.Label();
            this.PanelPasswordLinea = new System.Windows.Forms.Panel();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.PanelUsuario = new System.Windows.Forms.Panel();
            this.LblPanelUsuario = new System.Windows.Forms.Label();
            this.PanelUsuarioLinea = new System.Windows.Forms.Panel();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.BtnIngresar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.PanelMain.SuspendLayout();
            this.PanelEmail.SuspendLayout();
            this.PanelPassword.SuspendLayout();
            this.PanelUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.PanelMain.Controls.Add(this.BtnSalir);
            this.PanelMain.Controls.Add(this.PanelEmail);
            this.PanelMain.Controls.Add(this.PanelPassword);
            this.PanelMain.Controls.Add(this.PanelUsuario);
            this.PanelMain.Controls.Add(this.BtnIngresar);
            this.PanelMain.Controls.Add(this.pictureBox1);
            this.PanelMain.Location = new System.Drawing.Point(12, 12);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(424, 463);
            this.PanelMain.TabIndex = 11;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.White;
            this.BtnSalir.Location = new System.Drawing.Point(58, 378);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(307, 36);
            this.BtnSalir.TabIndex = 5;
            this.BtnSalir.Text = "V   O   L   V   E   R";
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // PanelEmail
            // 
            this.PanelEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.PanelEmail.Controls.Add(this.LblPanelEmail);
            this.PanelEmail.Controls.Add(this.PanelEmailLinea);
            this.PanelEmail.Controls.Add(this.TxtEmail);
            this.PanelEmail.Location = new System.Drawing.Point(59, 206);
            this.PanelEmail.Name = "PanelEmail";
            this.PanelEmail.Padding = new System.Windows.Forms.Padding(5);
            this.PanelEmail.Size = new System.Drawing.Size(306, 35);
            this.PanelEmail.TabIndex = 23;
            // 
            // LblPanelEmail
            // 
            this.LblPanelEmail.AutoSize = true;
            this.LblPanelEmail.BackColor = System.Drawing.Color.Transparent;
            this.LblPanelEmail.Enabled = false;
            this.LblPanelEmail.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPanelEmail.ForeColor = System.Drawing.Color.White;
            this.LblPanelEmail.Location = new System.Drawing.Point(8, 5);
            this.LblPanelEmail.Name = "LblPanelEmail";
            this.LblPanelEmail.Size = new System.Drawing.Size(38, 17);
            this.LblPanelEmail.TabIndex = 21;
            this.LblPanelEmail.Text = "Email";
            // 
            // PanelEmailLinea
            // 
            this.PanelEmailLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(184)))), ((int)(((byte)(182)))));
            this.PanelEmailLinea.Location = new System.Drawing.Point(8, 25);
            this.PanelEmailLinea.Name = "PanelEmailLinea";
            this.PanelEmailLinea.Size = new System.Drawing.Size(291, 2);
            this.PanelEmailLinea.TabIndex = 20;
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEmail.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.ForeColor = System.Drawing.Color.Cyan;
            this.TxtEmail.Location = new System.Drawing.Point(5, 5);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(296, 22);
            this.TxtEmail.TabIndex = 2;
            this.TxtEmail.TextChanged += new System.EventHandler(this.TxtEmail_TextChanged);
            // 
            // PanelPassword
            // 
            this.PanelPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.PanelPassword.Controls.Add(this.LblPanelPassword);
            this.PanelPassword.Controls.Add(this.PanelPasswordLinea);
            this.PanelPassword.Controls.Add(this.TxtPassword);
            this.PanelPassword.Location = new System.Drawing.Point(59, 258);
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
            this.TxtPassword.ForeColor = System.Drawing.Color.Cyan;
            this.TxtPassword.Location = new System.Drawing.Point(5, 5);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(296, 22);
            this.TxtPassword.TabIndex = 3;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            // 
            // PanelUsuario
            // 
            this.PanelUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.PanelUsuario.Controls.Add(this.LblPanelUsuario);
            this.PanelUsuario.Controls.Add(this.PanelUsuarioLinea);
            this.PanelUsuario.Controls.Add(this.TxtUsuario);
            this.PanelUsuario.Location = new System.Drawing.Point(59, 156);
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
            this.TxtUsuario.ForeColor = System.Drawing.Color.Cyan;
            this.TxtUsuario.Location = new System.Drawing.Point(5, 5);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(296, 22);
            this.TxtUsuario.TabIndex = 1;
            this.TxtUsuario.TextChanged += new System.EventHandler(this.TxtUsuario_TextChanged);
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.BtnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIngresar.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIngresar.ForeColor = System.Drawing.Color.White;
            this.BtnIngresar.Location = new System.Drawing.Point(58, 322);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new System.Drawing.Size(307, 36);
            this.BtnIngresar.TabIndex = 4;
            this.BtnIngresar.Text = "R   E   G   I   S   T   R   A  R";
            this.BtnIngresar.UseVisualStyleBackColor = false;
            this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(23, 10);
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
            // FormRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(45)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(448, 487);
            this.Controls.Add(this.PanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRegistrar";
            this.PanelMain.ResumeLayout(false);
            this.PanelEmail.ResumeLayout(false);
            this.PanelEmail.PerformLayout();
            this.PanelPassword.ResumeLayout(false);
            this.PanelPassword.PerformLayout();
            this.PanelUsuario.ResumeLayout(false);
            this.PanelUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Panel PanelPassword;
        private System.Windows.Forms.Label LblPanelPassword;
        private System.Windows.Forms.Panel PanelPasswordLinea;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Panel PanelUsuario;
        private System.Windows.Forms.Label LblPanelUsuario;
        private System.Windows.Forms.Panel PanelUsuarioLinea;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Button BtnIngresar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PanelEmail;
        private System.Windows.Forms.Label LblPanelEmail;
        private System.Windows.Forms.Panel PanelEmailLinea;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button BtnSalir;
    }
}