namespace KickNetLib.DesktopFormsTool.Controls
{
    partial class UserAPIControl
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
            btnSearchByIds = new Button();
            lblIdsUsers = new Label();
            txtTermOfSearch = new TextBox();
            gb1 = new GroupBox();
            gb2 = new GroupBox();
            btnSearchMe = new Button();
            panel = new Panel();
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).BeginInit();
            scBaseAPI.Panel1.SuspendLayout();
            scBaseAPI.SuspendLayout();
            gb1.SuspendLayout();
            gb2.SuspendLayout();
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
            // btnSearchByIds
            // 
            btnSearchByIds.Location = new Point(303, 55);
            btnSearchByIds.Name = "btnSearchByIds";
            btnSearchByIds.Size = new Size(100, 29);
            btnSearchByIds.TabIndex = 0;
            btnSearchByIds.Text = "Search";
            btnSearchByIds.UseVisualStyleBackColor = true;
            btnSearchByIds.Click += btnSearchByIds_Click;
            // 
            // lblIdsUsers
            // 
            lblIdsUsers.AutoSize = true;
            lblIdsUsers.Location = new Point(20, 34);
            lblIdsUsers.Name = "lblIdsUsers";
            lblIdsUsers.Size = new Size(239, 20);
            lblIdsUsers.TabIndex = 1;
            lblIdsUsers.Text = "Ids of users separated with comma";
            // 
            // txtTermOfSearch
            // 
            txtTermOfSearch.Location = new Point(20, 57);
            txtTermOfSearch.Name = "txtTermOfSearch";
            txtTermOfSearch.Size = new Size(277, 27);
            txtTermOfSearch.TabIndex = 2;
            // 
            // gb1
            // 
            gb1.Controls.Add(lblIdsUsers);
            gb1.Controls.Add(txtTermOfSearch);
            gb1.Controls.Add(btnSearchByIds);
            gb1.Location = new Point(3, 12);
            gb1.Name = "gb1";
            gb1.Size = new Size(419, 109);
            gb1.TabIndex = 3;
            gb1.TabStop = false;
            gb1.Text = "GET /public/v1/users - Get Users";
            // 
            // gb2
            // 
            gb2.Controls.Add(btnSearchMe);
            gb2.Location = new Point(3, 127);
            gb2.Name = "gb2";
            gb2.Size = new Size(419, 67);
            gb2.TabIndex = 4;
            gb2.TabStop = false;
            gb2.Text = "GET /public/v1/users - Get Users (Me)";
            // 
            // btnSearchMe
            // 
            btnSearchMe.Location = new Point(303, 26);
            btnSearchMe.Name = "btnSearchMe";
            btnSearchMe.Size = new Size(100, 29);
            btnSearchMe.TabIndex = 0;
            btnSearchMe.Text = "Search";
            btnSearchMe.UseVisualStyleBackColor = true;
            btnSearchMe.Click += btnSearchMe_Click;
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Controls.Add(gb2);
            panel.Controls.Add(gb1);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(446, 496);
            panel.TabIndex = 0;
            // 
            // UserAPIControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "UserAPIControl";
            Size = new Size(967, 496);
            scBaseAPI.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).EndInit();
            scBaseAPI.ResumeLayout(false);
            gb1.ResumeLayout(false);
            gb1.PerformLayout();
            gb2.ResumeLayout(false);
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnSearchByIds;
        private Label lblIdsUsers;
        private TextBox txtTermOfSearch;
        private GroupBox gb1;
        private GroupBox gb2;
        private Button btnSearchMe;
        private Panel panel;
    }
}
