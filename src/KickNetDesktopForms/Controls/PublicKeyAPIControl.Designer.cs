namespace KickNetLib.DesktopFormsTool.Controls
{
    partial class PublicKeyAPIControl
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
            gb1 = new GroupBox();
            btnSearch = new Button();
            panel = new Panel();
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).BeginInit();
            scBaseAPI.Panel1.SuspendLayout();
            scBaseAPI.SuspendLayout();
            gb1.SuspendLayout();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // scBaseAPI
            // 
            // 
            // scBaseAPI.Panel1
            // 
            scBaseAPI.Panel1.Controls.Add(panel);
            scBaseAPI.Size = new Size(967, 496);
            // 
            // gb1
            // 
            gb1.Controls.Add(btnSearch);
            gb1.Location = new Point(3, 12);
            gb1.Name = "gb1";
            gb1.Size = new Size(419, 67);
            gb1.TabIndex = 4;
            gb1.TabStop = false;
            gb1.Text = "GET /public/v1/public-key - Get Public Key";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(303, 26);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 29);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Controls.Add(gb1);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(446, 496);
            panel.TabIndex = 0;
            // 
            // PublicKeyAPIControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "PublicKeyAPIControl";
            Size = new Size(967, 496);
            scBaseAPI.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).EndInit();
            scBaseAPI.ResumeLayout(false);
            gb1.ResumeLayout(false);
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gb1;
        private Button btnSearch;
        private Panel panel;
    }
}
