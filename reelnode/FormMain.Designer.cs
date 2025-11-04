namespace Reelnode
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStpMenuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuCuenta = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelBack = new System.Windows.Forms.Panel();
            this.Panel = new System.Windows.Forms.Panel();
            this.LblSeries = new System.Windows.Forms.Label();
            this.LblPeliculas = new System.Windows.Forms.Label();
            this.FlowPanelSeries = new System.Windows.Forms.FlowLayoutPanel();
            this.FlowPanelPeliculas = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnTema = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.PanelBack.SuspendLayout();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStpMenuHome,
            this.ToolStpMenuAdmin,
            this.ToolStpMenuCuenta,
            this.ToolStpMenuSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6);
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1280, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStpMenuHome
            // 
            this.ToolStpMenuHome.Font = new System.Drawing.Font("Consolas", 12F);
            this.ToolStpMenuHome.Name = "ToolStpMenuHome";
            this.ToolStpMenuHome.Size = new System.Drawing.Size(57, 23);
            this.ToolStpMenuHome.Text = "Home";
            this.ToolStpMenuHome.Click += new System.EventHandler(this.ToolStpMenuHome_Click);
            // 
            // ToolStpMenuAdmin
            // 
            this.ToolStpMenuAdmin.Font = new System.Drawing.Font("Consolas", 12F);
            this.ToolStpMenuAdmin.Name = "ToolStpMenuAdmin";
            this.ToolStpMenuAdmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ToolStpMenuAdmin.Size = new System.Drawing.Size(120, 23);
            this.ToolStpMenuAdmin.Text = "Administrar";
            this.ToolStpMenuAdmin.Click += new System.EventHandler(this.ToolStpMenuAdmin_Click_1);
            // 
            // ToolStpMenuCuenta
            // 
            this.ToolStpMenuCuenta.Font = new System.Drawing.Font("Consolas", 12F);
            this.ToolStpMenuCuenta.Name = "ToolStpMenuCuenta";
            this.ToolStpMenuCuenta.Size = new System.Drawing.Size(75, 23);
            this.ToolStpMenuCuenta.Text = "Cuenta";
            this.ToolStpMenuCuenta.Click += new System.EventHandler(this.ToolStpMenuCuenta_Click);
            // 
            // ToolStpMenuSalir
            // 
            this.ToolStpMenuSalir.Font = new System.Drawing.Font("Consolas", 12F);
            this.ToolStpMenuSalir.Name = "ToolStpMenuSalir";
            this.ToolStpMenuSalir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToolStpMenuSalir.Size = new System.Drawing.Size(66, 23);
            this.ToolStpMenuSalir.Text = "Salir";
            this.ToolStpMenuSalir.Click += new System.EventHandler(this.ToolStpMenuSalir_Click);
            // 
            // PanelBack
            // 
            this.PanelBack.AutoSize = true;
            this.PanelBack.BackColor = System.Drawing.Color.Transparent;
            this.PanelBack.Controls.Add(this.BtnTema);
            this.PanelBack.Controls.Add(this.Panel);
            this.PanelBack.Controls.Add(this.menuStrip1);
            this.PanelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBack.Location = new System.Drawing.Point(0, 0);
            this.PanelBack.Margin = new System.Windows.Forms.Padding(0);
            this.PanelBack.Name = "PanelBack";
            this.PanelBack.Size = new System.Drawing.Size(1280, 720);
            this.PanelBack.TabIndex = 1;
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.LblSeries);
            this.Panel.Controls.Add(this.LblPeliculas);
            this.Panel.Controls.Add(this.FlowPanelSeries);
            this.Panel.Controls.Add(this.FlowPanelPeliculas);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 35);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1280, 685);
            this.Panel.TabIndex = 2;
            // 
            // LblSeries
            // 
            this.LblSeries.AutoSize = true;
            this.LblSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSeries.Location = new System.Drawing.Point(61, 336);
            this.LblSeries.Name = "LblSeries";
            this.LblSeries.Size = new System.Drawing.Size(60, 20);
            this.LblSeries.TabIndex = 73;
            this.LblSeries.Tag = "Titulo";
            this.LblSeries.Text = "Series";
            // 
            // LblPeliculas
            // 
            this.LblPeliculas.AutoSize = true;
            this.LblPeliculas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPeliculas.Location = new System.Drawing.Point(61, 10);
            this.LblPeliculas.Name = "LblPeliculas";
            this.LblPeliculas.Size = new System.Drawing.Size(80, 20);
            this.LblPeliculas.TabIndex = 71;
            this.LblPeliculas.Tag = "Titulo";
            this.LblPeliculas.Text = "Peliculas";
            // 
            // FlowPanelSeries
            // 
            this.FlowPanelSeries.AutoScroll = true;
            this.FlowPanelSeries.BackColor = System.Drawing.Color.Transparent;
            this.FlowPanelSeries.Location = new System.Drawing.Point(65, 359);
            this.FlowPanelSeries.Name = "FlowPanelSeries";
            this.FlowPanelSeries.Padding = new System.Windows.Forms.Padding(10);
            this.FlowPanelSeries.Size = new System.Drawing.Size(1123, 280);
            this.FlowPanelSeries.TabIndex = 1;
            this.FlowPanelSeries.Tag = "Default";
            this.FlowPanelSeries.WrapContents = false;
            // 
            // FlowPanelPeliculas
            // 
            this.FlowPanelPeliculas.AutoScroll = true;
            this.FlowPanelPeliculas.BackColor = System.Drawing.Color.Transparent;
            this.FlowPanelPeliculas.Location = new System.Drawing.Point(65, 33);
            this.FlowPanelPeliculas.Name = "FlowPanelPeliculas";
            this.FlowPanelPeliculas.Padding = new System.Windows.Forms.Padding(10);
            this.FlowPanelPeliculas.Size = new System.Drawing.Size(1123, 280);
            this.FlowPanelPeliculas.TabIndex = 0;
            this.FlowPanelPeliculas.Tag = "Default";
            this.FlowPanelPeliculas.WrapContents = false;
            // 
            // BtnTema
            // 
            this.BtnTema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTema.Location = new System.Drawing.Point(1146, 0);
            this.BtnTema.Name = "BtnTema";
            this.BtnTema.Size = new System.Drawing.Size(42, 35);
            this.BtnTema.TabIndex = 3;
            this.BtnTema.Text = "👁";
            this.BtnTema.UseVisualStyleBackColor = true;
            this.BtnTema.Click += new System.EventHandler(this.BtnTema_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.PanelBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reelnode";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PanelBack.ResumeLayout(false);
            this.PanelBack.PerformLayout();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuAdmin;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuSalir;
        private System.Windows.Forms.Panel PanelBack;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuCuenta;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuHome;
        private System.Windows.Forms.FlowLayoutPanel FlowPanelPeliculas;
        private System.Windows.Forms.FlowLayoutPanel FlowPanelSeries;
        private System.Windows.Forms.Label LblPeliculas;
        private System.Windows.Forms.Label LblSeries;
        private System.Windows.Forms.Button BtnTema;
    }
}

