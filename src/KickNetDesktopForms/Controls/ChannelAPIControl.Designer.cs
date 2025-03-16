namespace KickNetLib.DesktopFormsTool.Controls
{
    partial class ChannelAPIControl
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
            g2 = new GroupBox();
            label2 = new Label();
            txtTitle = new TextBox();
            lblCategoryId = new Label();
            txtCategoryId = new TextBox();
            btnSend = new Button();
            panel = new Panel();
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).BeginInit();
            scBaseAPI.Panel1.SuspendLayout();
            scBaseAPI.SuspendLayout();
            gb1.SuspendLayout();
            g2.SuspendLayout();
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
            lblIdsUsers.Size = new Size(291, 20);
            lblIdsUsers.TabIndex = 1;
            lblIdsUsers.Text = "Ids of broadcasters separated with comma";
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
            gb1.Text = "GET/public/v1/channels - Get Channels";
            // 
            // g2
            // 
            g2.Controls.Add(label2);
            g2.Controls.Add(txtTitle);
            g2.Controls.Add(lblCategoryId);
            g2.Controls.Add(txtCategoryId);
            g2.Controls.Add(btnSend);
            g2.Location = new Point(3, 127);
            g2.Name = "g2";
            g2.Size = new Size(419, 165);
            g2.TabIndex = 4;
            g2.TabStop = false;
            g2.Text = "PATCH /public/v1/channels - Patch Channels";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 94);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 4;
            label2.Text = "Tittle";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(20, 117);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(277, 27);
            txtTitle.TabIndex = 3;
            // 
            // lblCategoryId
            // 
            lblCategoryId.AutoSize = true;
            lblCategoryId.Location = new Point(20, 34);
            lblCategoryId.Name = "lblCategoryId";
            lblCategoryId.Size = new Size(86, 20);
            lblCategoryId.TabIndex = 1;
            lblCategoryId.Text = "Category Id";
            // 
            // txtCategoryId
            // 
            txtCategoryId.Location = new Point(20, 57);
            txtCategoryId.Name = "txtCategoryId";
            txtCategoryId.Size = new Size(277, 27);
            txtCategoryId.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(303, 117);
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
            panel.Controls.Add(g2);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(446, 496);
            panel.TabIndex = 0;
            // 
            // ChannelAPIControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "ChannelAPIControl";
            Size = new Size(967, 496);
            scBaseAPI.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).EndInit();
            scBaseAPI.ResumeLayout(false);
            gb1.ResumeLayout(false);
            gb1.PerformLayout();
            g2.ResumeLayout(false);
            g2.PerformLayout();
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnSearchByIds;
        private Label lblIdsUsers;
        private TextBox txtTermOfSearch;
        private GroupBox gb1;
        private GroupBox g2;
        private Label lblCategoryId;
        private TextBox txtCategoryId;
        private Button btnSend;
        private Label label2;
        private TextBox txtTitle;
        private Panel panel;
    }
}
