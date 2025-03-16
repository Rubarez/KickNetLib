
using System.Text.Json;

using KickNetLib.Api;

namespace KickNetLib.DesktopFormsTool.Controls
{
    public partial class TokenAPIControl : BaseAPIControl
    {
        #region Constructor

        public TokenAPIControl(Main parentForm) : base(parentForm) { InitializeComponent(); }

        #endregion

        #region Events

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                KickApi kickApi = new KickApi(_kickApiSettings);

                var tokenIntroespect = await kickApi.Token.IntrospectTokenAsync();

                SetResult(JsonSerializer.Serialize(tokenIntroespect, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
