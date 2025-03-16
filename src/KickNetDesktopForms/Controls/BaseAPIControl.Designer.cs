namespace KickNetLib.DesktopFormsTool.Controls
{
    partial class BaseAPIControl
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
            scBaseAPI = new SplitContainer();
            gbResults = new GroupBox();
            txtResults = new TextBox();
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).BeginInit();
            scBaseAPI.Panel2.SuspendLayout();
            scBaseAPI.SuspendLayout();
            gbResults.SuspendLayout();
            SuspendLayout();
            // 
            // scBaseAPI
            // 
            scBaseAPI.Dock = DockStyle.Fill;
            scBaseAPI.FixedPanel = FixedPanel.Panel1;
            scBaseAPI.Location = new Point(0, 0);
            scBaseAPI.Name = "scBaseAPI";
            // 
            // scBaseAPI.Panel2
            // 
            scBaseAPI.Panel2.Controls.Add(gbResults);
            scBaseAPI.Size = new Size(1024, 600);
            scBaseAPI.SplitterDistance = 446;
            scBaseAPI.TabIndex = 0;
            // 
            // gbResults
            // 
            gbResults.Controls.Add(txtResults);
            gbResults.Dock = DockStyle.Fill;
            gbResults.Location = new Point(0, 0);
            gbResults.Name = "gbResults";
            gbResults.Size = new Size(574, 600);
            gbResults.TabIndex = 5;
            gbResults.TabStop = false;
            gbResults.Text = "Results";
            // 
            // txtResults
            // 
            txtResults.Dock = DockStyle.Fill;
            txtResults.Location = new Point(3, 23);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Vertical;
            txtResults.Size = new Size(568, 574);
            txtResults.TabIndex = 0;
            // 
            // BaseAPIControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(scBaseAPI);
            Name = "BaseAPIControl";
            Size = new Size(1024, 600);
            scBaseAPI.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).EndInit();
            scBaseAPI.ResumeLayout(false);
            gbResults.ResumeLayout(false);
            gbResults.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        protected SplitContainer scBaseAPI;
        private GroupBox gbResults;
        private TextBox txtResults;
    }
}
