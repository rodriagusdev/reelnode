namespace ProjectoNuevo
{
    partial class ControlComentarios
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
            this.Panel = new System.Windows.Forms.Panel();
            this.PanelComentar = new System.Windows.Forms.Panel();
            this.TxtComentario = new System.Windows.Forms.TextBox();
            this.BtnEnviarComentario = new System.Windows.Forms.Button();
            this.Panel.SuspendLayout();
            this.PanelComentar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel.Controls.Add(this.BtnEnviarComentario);
            this.Panel.Controls.Add(this.PanelComentar);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1280, 720);
            this.Panel.TabIndex = 0;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // PanelComentar
            // 
            this.PanelComentar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.PanelComentar.Controls.Add(this.TxtComentario);
            this.PanelComentar.Location = new System.Drawing.Point(201, 58);
            this.PanelComentar.Name = "PanelComentar";
            this.PanelComentar.Padding = new System.Windows.Forms.Padding(5);
            this.PanelComentar.Size = new System.Drawing.Size(889, 121);
            this.PanelComentar.TabIndex = 52;
            // 
            // TxtComentario
            // 
            this.TxtComentario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(74)))), ((int)(((byte)(106)))));
            this.TxtComentario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtComentario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtComentario.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentario.ForeColor = System.Drawing.Color.White;
            this.TxtComentario.Location = new System.Drawing.Point(5, 5);
            this.TxtComentario.Multiline = true;
            this.TxtComentario.Name = "TxtComentario";
            this.TxtComentario.Size = new System.Drawing.Size(879, 111);
            this.TxtComentario.TabIndex = 12;
            // 
            // BtnEnviarComentario
            // 
            this.BtnEnviarComentario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.BtnEnviarComentario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEnviarComentario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnviarComentario.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviarComentario.ForeColor = System.Drawing.Color.Black;
            this.BtnEnviarComentario.Location = new System.Drawing.Point(885, 209);
            this.BtnEnviarComentario.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEnviarComentario.Name = "BtnEnviarComentario";
            this.BtnEnviarComentario.Size = new System.Drawing.Size(205, 35);
            this.BtnEnviarComentario.TabIndex = 53;
            this.BtnEnviarComentario.Text = "Enviar comentario";
            this.BtnEnviarComentario.UseVisualStyleBackColor = false;
            this.BtnEnviarComentario.Click += new System.EventHandler(this.BtnEnviarComentario_Click);
            // 
            // ControlComentarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel);
            this.Name = "ControlComentarios";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Panel.ResumeLayout(false);
            this.PanelComentar.ResumeLayout(false);
            this.PanelComentar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Panel PanelComentar;
        private System.Windows.Forms.TextBox TxtComentario;
        private System.Windows.Forms.Button BtnEnviarComentario;
    }
}
