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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStpMenuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.noTocarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.ListSeries = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.PanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 31);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStpMenuAdmin,
            this.noTocarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStpMenuAdmin
            // 
            this.ToolStpMenuAdmin.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStpMenuAdmin.Name = "ToolStpMenuAdmin";
            this.ToolStpMenuAdmin.Size = new System.Drawing.Size(96, 22);
            this.ToolStpMenuAdmin.Text = "Administrar";
            this.ToolStpMenuAdmin.Click += new System.EventHandler(this.ToolStpMenuAdmin_Click);
            // 
            // noTocarToolStripMenuItem
            // 
            this.noTocarToolStripMenuItem.Enabled = false;
            this.noTocarToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noTocarToolStripMenuItem.Name = "noTocarToolStripMenuItem";
            this.noTocarToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.noTocarToolStripMenuItem.Text = "Agregar Contenido";
            this.noTocarToolStripMenuItem.Click += new System.EventHandler(this.noTocarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // PanelMain
            // 
            this.PanelMain.AutoSize = true;
            this.PanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(55)))), ((int)(((byte)(82)))));
            this.PanelMain.Controls.Add(this.ListSeries);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 31);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(1280, 689);
            this.PanelMain.TabIndex = 1;
            this.PanelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ListSeries
            // 
            this.ListSeries.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ListSeries.HideSelection = false;
            this.ListSeries.Location = new System.Drawing.Point(245, 338);
            this.ListSeries.Name = "ListSeries";
            this.ListSeries.Size = new System.Drawing.Size(771, 157);
            this.ListSeries.TabIndex = 0;
            this.ListSeries.UseCompatibleStateImageBehavior = false;
            this.ListSeries.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reelnode";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PanelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.ToolStripMenuItem ToolStpMenuAdmin;
        private System.Windows.Forms.ToolStripMenuItem noTocarToolStripMenuItem;
        private System.Windows.Forms.ListView ListSeries;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}

