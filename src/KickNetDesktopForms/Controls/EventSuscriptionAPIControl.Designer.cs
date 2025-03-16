namespace KickNetLib.DesktopFormsTool.Controls
{
    partial class EventSuscriptionAPIControl
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
            gb2 = new GroupBox();
            chklEvents = new CheckedListBox();
            btnSubscribe = new Button();
            gb3 = new GroupBox();
            lblButtonDeleteAll = new Label();
            btnDeleteAll = new Button();
            lblIdsUsers = new Label();
            txtIdsSuscriptions = new TextBox();
            btnDeleteByIds = new Button();
            panel = new Panel();
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).BeginInit();
            scBaseAPI.Panel1.SuspendLayout();
            scBaseAPI.SuspendLayout();
            gb1.SuspendLayout();
            gb2.SuspendLayout();
            gb3.SuspendLayout();
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
            gb1.Text = "GET /public/v1/events/subscriptions - Get Event suscriptions";
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
            // gb2
            // 
            gb2.Controls.Add(chklEvents);
            gb2.Controls.Add(btnSubscribe);
            gb2.Location = new Point(3, 85);
            gb2.Name = "gb2";
            gb2.Size = new Size(419, 199);
            gb2.TabIndex = 5;
            gb2.TabStop = false;
            gb2.Text = "POST /public/v1/events/subscriptions - Subscribe To Events";
            // 
            // chklEvents
            // 
            chklEvents.CheckOnClick = true;
            chklEvents.FormattingEnabled = true;
            chklEvents.Location = new Point(15, 26);
            chklEvents.Name = "chklEvents";
            chklEvents.Size = new Size(282, 158);
            chklEvents.TabIndex = 1;
            // 
            // btnSubscribe
            // 
            btnSubscribe.Location = new Point(303, 26);
            btnSubscribe.Name = "btnSubscribe";
            btnSubscribe.Size = new Size(100, 29);
            btnSubscribe.TabIndex = 0;
            btnSubscribe.Text = "Subscribe";
            btnSubscribe.UseVisualStyleBackColor = true;
            btnSubscribe.Click += btnSubscribe_Click;
            // 
            // gb3
            // 
            gb3.Controls.Add(lblButtonDeleteAll);
            gb3.Controls.Add(btnDeleteAll);
            gb3.Controls.Add(lblIdsUsers);
            gb3.Controls.Add(txtIdsSuscriptions);
            gb3.Controls.Add(btnDeleteByIds);
            gb3.Location = new Point(3, 290);
            gb3.Name = "gb3";
            gb3.Size = new Size(419, 153);
            gb3.TabIndex = 6;
            gb3.TabStop = false;
            gb3.Text = "DELETE /public/v1/events/subscriptions - Delete sub. event";
            // 
            // lblButtonDeleteAll
            // 
            lblButtonDeleteAll.AutoSize = true;
            lblButtonDeleteAll.Location = new Point(153, 109);
            lblButtonDeleteAll.Name = "lblButtonDeleteAll";
            lblButtonDeleteAll.Size = new Size(144, 20);
            lblButtonDeleteAll.TabIndex = 4;
            lblButtonDeleteAll.Text = "Button for delete All";
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.Location = new Point(303, 105);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(100, 29);
            btnDeleteAll.TabIndex = 3;
            btnDeleteAll.Text = "Send";
            btnDeleteAll.UseVisualStyleBackColor = true;
            btnDeleteAll.Click += btnDeleteAll_Click;
            // 
            // lblIdsUsers
            // 
            lblIdsUsers.AutoSize = true;
            lblIdsUsers.Location = new Point(20, 34);
            lblIdsUsers.Name = "lblIdsUsers";
            lblIdsUsers.Size = new Size(283, 20);
            lblIdsUsers.TabIndex = 1;
            lblIdsUsers.Text = "Ids of suscriptions separated with comma";
            // 
            // txtIdsSuscriptions
            // 
            txtIdsSuscriptions.Location = new Point(20, 57);
            txtIdsSuscriptions.Name = "txtIdsSuscriptions";
            txtIdsSuscriptions.Size = new Size(277, 27);
            txtIdsSuscriptions.TabIndex = 2;
            // 
            // btnDeleteByIds
            // 
            btnDeleteByIds.Location = new Point(303, 55);
            btnDeleteByIds.Name = "btnDeleteByIds";
            btnDeleteByIds.Size = new Size(100, 29);
            btnDeleteByIds.TabIndex = 0;
            btnDeleteByIds.Text = "Send";
            btnDeleteByIds.UseVisualStyleBackColor = true;
            btnDeleteByIds.Click += btnDeleteByIds_Click;
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Controls.Add(gb1);
            panel.Controls.Add(gb2);
            panel.Controls.Add(gb3);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(446, 496);
            panel.TabIndex = 7;
            // 
            // EventSuscriptionAPIControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "EventSuscriptionAPIControl";
            Size = new Size(967, 496);
            scBaseAPI.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).EndInit();
            scBaseAPI.ResumeLayout(false);
            gb1.ResumeLayout(false);
            gb2.ResumeLayout(false);
            gb3.ResumeLayout(false);
            gb3.PerformLayout();
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gb1;
        private Button btnSearch;
        private GroupBox gb2;
        private Button btnSubscribe;
        private CheckedListBox chklEvents;
        private GroupBox gb3;
        private Label lblIdsUsers;
        private TextBox txtIdsSuscriptions;
        private Button btnDeleteByIds;
        private Label lblButtonDeleteAll;
        private Button btnDeleteAll;
        private Panel panel;
    }
}
