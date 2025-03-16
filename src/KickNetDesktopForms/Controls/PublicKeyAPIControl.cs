
using System.Text.Json;

using KickNetLib.Api;

namespace KickNetLib.DesktopFormsTool.Controls
{
    public partial class PublicKeyAPIControl : BaseAPIControl
    {
        #region Constructor

        public PublicKeyAPIControl(Main parentForm) : base(parentForm) { InitializeComponent(); }

        #endregion

        #region Events

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                KickApi kickApi = new KickApi(_kickApiSettings);
                var publicKey = await kickApi.PublicKey.GetPublicKeyAsync();

                SetResult(JsonSerializer.Serialize(publicKey, new JsonSerializerOptions 
                { 
                    WriteIndented = true, 
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }
                ));
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
