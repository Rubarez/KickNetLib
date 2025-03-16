

using System.Text.Json;

using KickNetLib.Api;
using KickNetLib.Api.ApiClients.V1.Chat.Models;

namespace KickNetLib.DesktopFormsTool.Controls
{
    public partial class ChatAPIControl : BaseAPIControl
    {
        #region Constructor

        public ChatAPIControl(Main parentForm) : base(parentForm) { InitializeComponent(); }

        #endregion

        #region Events

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                int broadcasterUserId = 0;

                int.TryParse(txtBroadcasterId.Text, out broadcasterUserId);

                KickApi kickApi = new KickApi(_kickApiSettings);

                SendMessageResponse sendMessageResponse = null;

                if (rbBot.Checked)
                    sendMessageResponse = await kickApi.Chat.SendMessageAsBotAsync(txtMessage.Text);

                if (rbUser.Checked)
                    sendMessageResponse = await kickApi.Chat.SendMessageAsUserAsync(broadcasterUserId, txtMessage.Text);

                SetResult(JsonSerializer.Serialize(sendMessageResponse, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbBot_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBot.Checked)
                txtBroadcasterId.Text = "";
        }

        #endregion
    }
}
