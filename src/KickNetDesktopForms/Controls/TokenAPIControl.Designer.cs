namespace KickNetLib.DesktopFormsTool.Controls
{
    partial class TokenAPIControl
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
            btnSend = new Button();
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
            scBaseAPI.Size = new Size(728, 433);
            // 
            // gb1
            // 
            gb1.Controls.Add(btnSend);
            gb1.Location = new Point(3, 12);
            gb1.Name = "gb1";
            gb1.Size = new Size(419, 70);
            gb1.TabIndex = 5;
            gb1.TabStop = false;
            gb1.Text = "POST /public/v1/token/introspect - Post Token Introespect";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(313, 26);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(100, 29);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Controls.Add(gb1);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(446, 433);
            panel.TabIndex = 6;
            // 
            // TokenAPIControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "TokenAPIControl";
            Size = new Size(728, 433);
            scBaseAPI.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).EndInit();
            scBaseAPI.ResumeLayout(false);
            gb1.ResumeLayout(false);
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gb1;
        private Button btnSend;
        private Panel panel;
    }
}
