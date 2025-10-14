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
            this.ToolStpMenuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStpMenuCuenta = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelBack = new System.Windows.Forms.Panel();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.ToolStpMenuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.PanelBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStpMenuHome,
            this.ToolStpMenuAdmin,
            this.ToolStpMenuCuenta,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1280, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStpMenuAdmin
            // 
            this.ToolStpMenuAdmin.Font = new System.Drawing.Font("Consolas", 9F);
            this.ToolStpMenuAdmin.Name = "ToolStpMenuAdmin";
            this.ToolStpMenuAdmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ToolStpMenuAdmin.Size = new System.Drawing.Size(96, 20);
            this.ToolStpMenuAdmin.Text = "Administrar";
            this.ToolStpMenuAdmin.Click += new System.EventHandler(this.ToolStpMenuAdmin_Click_1);
            // 
            // ToolStpMenuCuenta
            // 
            this.ToolStpMenuCuenta.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStpMenuCuenta.Name = "ToolStpMenuCuenta";
            this.ToolStpMenuCuenta.Size = new System.Drawing.Size(61, 20);
            this.ToolStpMenuCuenta.Text = "Cuenta";
            this.ToolStpMenuCuenta.Click += new System.EventHandler(this.ToolStpMenuCuenta_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F);
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click_1);
            // 
            // PanelBack
            // 
            this.PanelBack.AutoSize = true;
            this.PanelBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(55)))), ((int)(((byte)(82)))));
            this.PanelBack.Controls.Add(this.PanelMain);
            this.PanelBack.Controls.Add(this.menuStrip1);
            this.PanelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBack.Location = new System.Drawing.Point(0, 0);
            this.PanelBack.Margin = new System.Windows.Forms.Padding(0);
            this.PanelBack.Name = "PanelBack";
            this.PanelBack.Size = new System.Drawing.Size(1280, 720);
            this.PanelBack.TabIndex = 1;
            // 
            // PanelMain
            // 
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 24);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(1280, 696);
            this.PanelMain.TabIndex = 2;
            // 
            // ToolStpMenuHome
            // 
            this.ToolStpMenuHome.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStpMenuHome.Name = "ToolStpMenuHome";
            this.ToolStpMenuHome.Size = new System.Drawing.Size(47, 20);
            this.ToolStpMenuHome.Text = "Home";
            this.ToolStpMenuHome.Click += new System.EventHandler(this.ToolStpMenuHome_Click);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuAdmin;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Panel PanelBack;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuCuenta;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuHome;
    }
}

