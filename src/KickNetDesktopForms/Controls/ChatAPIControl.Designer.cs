namespace KickNetLib.DesktopFormsTool.Controls
{
    partial class ChatAPIControl
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
            rbBot = new RadioButton();
            rbUser = new RadioButton();
            label2 = new Label();
            txtMessage = new TextBox();
            lblBroadcasterId = new Label();
            txtBroadcasterId = new TextBox();
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
            gb1.Controls.Add(rbBot);
            gb1.Controls.Add(rbUser);
            gb1.Controls.Add(label2);
            gb1.Controls.Add(txtMessage);
            gb1.Controls.Add(lblBroadcasterId);
            gb1.Controls.Add(txtBroadcasterId);
            gb1.Controls.Add(btnSend);
            gb1.Location = new Point(4, 12);
            gb1.Name = "gb1";
            gb1.Size = new Size(419, 325);
            gb1.TabIndex = 5;
            gb1.TabStop = false;
            gb1.Text = "PATCH /public/v1/chat - Post Chat Message";
            // 
            // rbBot
            // 
            rbBot.AutoSize = true;
            rbBot.Checked = true;
            rbBot.Location = new Point(21, 283);
            rbBot.Name = "rbBot";
            rbBot.Size = new Size(343, 24);
            rbBot.TabIndex = 6;
            rbBot.TabStop = true;
            rbBot.Text = "As Bot (You must got enabled the bot into kick)";
            rbBot.UseVisualStyleBackColor = true;
            rbBot.CheckedChanged += rbBot_CheckedChanged;
            // 
            // rbUser
            // 
            rbUser.AutoSize = true;
            rbUser.Location = new Point(21, 253);
            rbUser.Name = "rbUser";
            rbUser.Size = new Size(79, 24);
            rbUser.TabIndex = 5;
            rbUser.Text = "As User";
            rbUser.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 94);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 4;
            label2.Text = "Message";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(20, 117);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(277, 116);
            txtMessage.TabIndex = 3;
            // 
            // lblBroadcasterId
            // 
            lblBroadcasterId.AutoSize = true;
            lblBroadcasterId.Location = new Point(20, 34);
            lblBroadcasterId.Name = "lblBroadcasterId";
            lblBroadcasterId.Size = new Size(105, 20);
            lblBroadcasterId.TabIndex = 1;
            lblBroadcasterId.Text = "Broadcaster Id";
            // 
            // txtBroadcasterId
            // 
            txtBroadcasterId.Location = new Point(20, 57);
            txtBroadcasterId.Name = "txtBroadcasterId";
            txtBroadcasterId.Size = new Size(277, 27);
            txtBroadcasterId.TabIndex = 2;
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
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(446, 433);
            panel.TabIndex = 6;
            // 
            // ChatAPIControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "ChatAPIControl";
            Size = new Size(728, 433);
            scBaseAPI.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).EndInit();
            scBaseAPI.ResumeLayout(false);
            gb1.ResumeLayout(false);
            gb1.PerformLayout();
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gb1;
        private Label label2;
        private TextBox txtMessage;
        private Label lblBroadcasterId;
        private TextBox txtBroadcasterId;
        private Button btnSend;
        private RadioButton rbBot;
        private RadioButton rbUser;
        private Panel panel;
    }
}
