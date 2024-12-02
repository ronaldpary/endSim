namespace Newspapers
{
    partial class InterfaceNewsPapers
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.userControlN1 = new Guna.UI2.WinForms.Guna2Panel();
            this.userControlN11 = new Newspapers.Presentation.UserControlN1();
            this.userControlN1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userControlN1
            // 
            this.userControlN1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlN1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userControlN1.Controls.Add(this.userControlN11);
            this.userControlN1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.userControlN1.Location = new System.Drawing.Point(12, 12);
            this.userControlN1.Name = "userControlN1";
            this.userControlN1.Size = new System.Drawing.Size(1403, 702);
            this.userControlN1.TabIndex = 3;
            // 
            // userControlN11
            // 
            this.userControlN11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlN11.Location = new System.Drawing.Point(0, 0);
            this.userControlN11.Name = "userControlN11";
            this.userControlN11.Size = new System.Drawing.Size(1403, 702);
            this.userControlN11.TabIndex = 0;
            this.userControlN11.Load += new System.EventHandler(this.userControlN11_Load);
            // 
            // InterfaceNewsPapers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 726);
            this.Controls.Add(this.userControlN1);
            this.Name = "InterfaceNewsPapers";
            this.userControlN1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel userControlN1;
        private Presentation.UserControlN1 userControlN11;
    }
}

