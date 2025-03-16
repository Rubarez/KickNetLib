using KickNetLib.DesktopFormsTool.Models;

namespace KickNetLib.DesktopFormsTool
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            btnStartAuth = new Button();
            btnRefreshToken = new Button();
            btnRevokeToken = new Button();
            gbAuthentication = new GroupBox();
            txtRefreshToken = new TextBox();
            bsTokenInfo = new BindingSource(components);
            lblRefreshToken = new Label();
            txtAccessToken = new TextBox();
            label1 = new Label();
            txtTokenExpiresAt = new TextBox();
            label2 = new Label();
            tbMain = new TabControl();
            tpApis = new TabPage();
            tbAPIS = new TabControl();
            tpCategories = new TabPage();
            tpUsers = new TabPage();
            tpChannels = new TabPage();
            tpPublicKey = new TabPage();
            tpEventsSuscriptions = new TabPage();
            tpChat = new TabPage();
            tpToken = new TabPage();
            tpEvents = new TabPage();
            txtEvents = new TextBox();
            spMainContainer = new SplitContainer();
            gbAuthentication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bsTokenInfo).BeginInit();
            tbMain.SuspendLayout();
            tpApis.SuspendLayout();
            tbAPIS.SuspendLayout();
            tpEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spMainContainer).BeginInit();
            spMainContainer.Panel1.SuspendLayout();
            spMainContainer.Panel2.SuspendLayout();
            spMainContainer.SuspendLayout();
            SuspendLayout();
            // 
            // btnStartAuth
            // 
            btnStartAuth.Location = new Point(22, 36);
            btnStartAuth.Name = "btnStartAuth";
            btnStartAuth.Size = new Size(281, 51);
            btnStartAuth.TabIndex = 0;
            btnStartAuth.Text = "Start Authentication";
            btnStartAuth.UseVisualStyleBackColor = true;
            btnStartAuth.Click += BtnStartAuth_Click;
            // 
            // btnRefreshToken
            // 
            btnRefreshToken.Location = new Point(22, 93);
            btnRefreshToken.Name = "btnRefreshToken";
            btnRefreshToken.Size = new Size(281, 51);
            btnRefreshToken.TabIndex = 1;
            btnRefreshToken.Text = "Refresh Token";
            btnRefreshToken.UseVisualStyleBackColor = true;
            btnRefreshToken.Click += BtnRefreshTokenAuth_Click;
            // 
            // btnRevokeToken
            // 
            btnRevokeToken.Location = new Point(22, 151);
            btnRevokeToken.Name = "btnRevokeToken";
            btnRevokeToken.Size = new Size(281, 51);
            btnRevokeToken.TabIndex = 2;
            btnRevokeToken.Text = "Revoke Token";
            btnRevokeToken.UseVisualStyleBackColor = true;
            btnRevokeToken.Click += btnRevokeToken_Click;
            // 
            // gbAuthentication
            // 
            gbAuthentication.Controls.Add(txtRefreshToken);
            gbAuthentication.Controls.Add(lblRefreshToken);
            gbAuthentication.Controls.Add(txtAccessToken);
            gbAuthentication.Controls.Add(label1);
            gbAuthentication.Controls.Add(txtTokenExpiresAt);
            gbAuthentication.Controls.Add(label2);
            gbAuthentication.Controls.Add(btnStartAuth);
            gbAuthentication.Controls.Add(btnRefreshToken);
            gbAuthentication.Controls.Add(btnRevokeToken);
            gbAuthentication.Dock = DockStyle.Fill;
            gbAuthentication.Location = new Point(0, 0);
            gbAuthentication.Name = "gbAuthentication";
            gbAuthentication.Size = new Size(1006, 225);
            gbAuthentication.TabIndex = 7;
            gbAuthentication.TabStop = false;
            gbAuthentication.Text = "Authentication";
            // 
            // txtRefreshToken
            // 
            txtRefreshToken.DataBindings.Add(new Binding("Text", bsTokenInfo, "RefreshToken", true));
            txtRefreshToken.Location = new Point(341, 175);
            txtRefreshToken.Name = "txtRefreshToken";
            txtRefreshToken.ReadOnly = true;
            txtRefreshToken.Size = new Size(623, 27);
            txtRefreshToken.TabIndex = 8;
            // 
            // bsTokenInfo
            // 
            bsTokenInfo.DataSource = typeof(TokenInfo);
            // 
            // lblRefreshToken
            // 
            lblRefreshToken.AutoSize = true;
            lblRefreshToken.Location = new Point(341, 151);
            lblRefreshToken.Name = "lblRefreshToken";
            lblRefreshToken.Size = new Size(101, 20);
            lblRefreshToken.TabIndex = 7;
            lblRefreshToken.Text = "Refresh Token";
            // 
            // txtAccessToken
            // 
            txtAccessToken.DataBindings.Add(new Binding("Text", bsTokenInfo, "AccessToken", true));
            txtAccessToken.Location = new Point(341, 117);
            txtAccessToken.Name = "txtAccessToken";
            txtAccessToken.ReadOnly = true;
            txtAccessToken.Size = new Size(623, 27);
            txtAccessToken.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(341, 93);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 5;
            label1.Text = "Access Token";
            // 
            // txtTokenExpiresAt
            // 
            txtTokenExpiresAt.DataBindings.Add(new Binding("Text", bsTokenInfo, "StringTokenExpireAt", true));
            txtTokenExpiresAt.Location = new Point(341, 59);
            txtTokenExpiresAt.Name = "txtTokenExpiresAt";
            txtTokenExpiresAt.ReadOnly = true;
            txtTokenExpiresAt.Size = new Size(184, 27);
            txtTokenExpiresAt.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(341, 36);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 3;
            label2.Text = "Token Expires At";
            // 
            // tbMain
            // 
            tbMain.Controls.Add(tpApis);
            tbMain.Controls.Add(tpEvents);
            tbMain.Dock = DockStyle.Fill;
            tbMain.Location = new Point(0, 0);
            tbMain.Name = "tbMain";
            tbMain.SelectedIndex = 0;
            tbMain.Size = new Size(1006, 492);
            tbMain.TabIndex = 8;
            // 
            // tpApis
            // 
            tpApis.Controls.Add(tbAPIS);
            tpApis.Location = new Point(4, 29);
            tpApis.Name = "tpApis";
            tpApis.Padding = new Padding(3);
            tpApis.Size = new Size(998, 459);
            tpApis.TabIndex = 0;
            tpApis.Text = "APIS";
            tpApis.UseVisualStyleBackColor = true;
            // 
            // tbAPIS
            // 
            tbAPIS.Controls.Add(tpCategories);
            tbAPIS.Controls.Add(tpUsers);
            tbAPIS.Controls.Add(tpChannels);
            tbAPIS.Controls.Add(tpPublicKey);
            tbAPIS.Controls.Add(tpEventsSuscriptions);
            tbAPIS.Controls.Add(tpChat);
            tbAPIS.Controls.Add(tpToken);
            tbAPIS.Dock = DockStyle.Fill;
            tbAPIS.Location = new Point(3, 3);
            tbAPIS.Name = "tbAPIS";
            tbAPIS.SelectedIndex = 0;
            tbAPIS.Size = new Size(992, 453);
            tbAPIS.TabIndex = 0;
            tbAPIS.SelectedIndexChanged += tbAPIS_SelectedIndexChanged;
            // 
            // tpCategories
            // 
            tpCategories.Location = new Point(4, 29);
            tpCategories.Name = "tpCategories";
            tpCategories.Padding = new Padding(3);
            tpCategories.Size = new Size(984, 420);
            tpCategories.TabIndex = 0;
            tpCategories.Text = "Categories";
            tpCategories.UseVisualStyleBackColor = true;
            // 
            // tpUsers
            // 
            tpUsers.Location = new Point(4, 29);
            tpUsers.Name = "tpUsers";
            tpUsers.Padding = new Padding(3);
            tpUsers.Size = new Size(984, 420);
            tpUsers.TabIndex = 1;
            tpUsers.Text = "Users";
            tpUsers.UseVisualStyleBackColor = true;
            // 
            // tpChannels
            // 
            tpChannels.Location = new Point(4, 29);
            tpChannels.Name = "tpChannels";
            tpChannels.Size = new Size(984, 420);
            tpChannels.TabIndex = 2;
            tpChannels.Text = "Channels";
            tpChannels.UseVisualStyleBackColor = true;
            // 
            // tpPublicKey
            // 
            tpPublicKey.Location = new Point(4, 29);
            tpPublicKey.Name = "tpPublicKey";
            tpPublicKey.Size = new Size(984, 420);
            tpPublicKey.TabIndex = 3;
            tpPublicKey.Text = "Public Key";
            tpPublicKey.UseVisualStyleBackColor = true;
            // 
            // tpEventsSuscriptions
            // 
            tpEventsSuscriptions.Location = new Point(4, 29);
            tpEventsSuscriptions.Name = "tpEventsSuscriptions";
            tpEventsSuscriptions.Size = new Size(984, 420);
            tpEventsSuscriptions.TabIndex = 4;
            tpEventsSuscriptions.Text = "Events Suscriptions";
            tpEventsSuscriptions.UseVisualStyleBackColor = true;
            // 
            // tpChat
            // 
            tpChat.Location = new Point(4, 29);
            tpChat.Name = "tpChat";
            tpChat.Size = new Size(984, 420);
            tpChat.TabIndex = 5;
            tpChat.Text = "Chat";
            tpChat.UseVisualStyleBackColor = true;
            // 
            // tpToken
            // 
            tpToken.Location = new Point(4, 29);
            tpToken.Name = "tpToken";
            tpToken.Size = new Size(984, 420);
            tpToken.TabIndex = 6;
            tpToken.Text = "Token";
            tpToken.UseVisualStyleBackColor = true;
            // 
            // tpEvents
            // 
            tpEvents.Controls.Add(txtEvents);
            tpEvents.Location = new Point(4, 29);
            tpEvents.Name = "tpEvents";
            tpEvents.Padding = new Padding(3);
            tpEvents.Size = new Size(998, 459);
            tpEvents.TabIndex = 1;
            tpEvents.Text = "Events";
            tpEvents.UseVisualStyleBackColor = true;
            // 
            // txtEvents
            // 
            txtEvents.Dock = DockStyle.Fill;
            txtEvents.Location = new Point(3, 3);
            txtEvents.Multiline = true;
            txtEvents.Name = "txtEvents";
            txtEvents.ScrollBars = ScrollBars.Vertical;
            txtEvents.Size = new Size(992, 453);
            txtEvents.TabIndex = 0;
            // 
            // spMainContainer
            // 
            spMainContainer.Dock = DockStyle.Fill;
            spMainContainer.FixedPanel = FixedPanel.Panel1;
            spMainContainer.Location = new Point(0, 0);
            spMainContainer.Name = "spMainContainer";
            spMainContainer.Orientation = Orientation.Horizontal;
            // 
            // spMainContainer.Panel1
            // 
            spMainContainer.Panel1.Controls.Add(gbAuthentication);
            // 
            // spMainContainer.Panel2
            // 
            spMainContainer.Panel2.Controls.Add(tbMain);
            spMainContainer.Size = new Size(1006, 721);
            spMainContainer.SplitterDistance = 225;
            spMainContainer.TabIndex = 9;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 721);
            Controls.Add(spMainContainer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1024, 768);
            Name = "Main";
            Text = "KickNet Desktop Forms - Tool";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            gbAuthentication.ResumeLayout(false);
            gbAuthentication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bsTokenInfo).EndInit();
            tbMain.ResumeLayout(false);
            tpApis.ResumeLayout(false);
            tbAPIS.ResumeLayout(false);
            tpEvents.ResumeLayout(false);
            tpEvents.PerformLayout();
            spMainContainer.Panel1.ResumeLayout(false);
            spMainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spMainContainer).EndInit();
            spMainContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnStartAuth;
        private Button btnRefreshToken;
        private Button btnRevokeToken;
        private GroupBox gbAuthentication;
        private Label label2;
        private TextBox txtTokenExpiresAt;
        private Label label1;
        private TextBox txtAccessToken;
        private TextBox txtRefreshToken;
        private Label lblRefreshToken;
        private BindingSource bsTokenInfo;
        private TabControl tbMain;
        private TabPage tpApis;
        private TabPage tpEvents;
        private SplitContainer spMainContainer;
        private TabControl tbAPIS;
        private TabPage tpCategories;
        private TabPage tpUsers;
        private TabPage tpChannels;
        private TabPage tpPublicKey;
        private TabPage tpEventsSuscriptions;
        private TabPage tpChat;
        private TabPage tpToken;
        private TextBox txtEvents;
    }
}
