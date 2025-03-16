
using System.Text.Json;

using KickNetLib.Api;

namespace KickNetLib.DesktopFormsTool.Controls
{
    public partial class ChannelAPIControl : BaseAPIControl
    {
        #region Constructor

        public ChannelAPIControl(Main parentForm) : base(parentForm)
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private async void btnSearchByIds_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                List<int> idbroadcasterUserIds = txtTermOfSearch.Text?
                     .Split(',', StringSplitOptions.RemoveEmptyEntries)
                     .Select(s => int.TryParse(s.Trim(), out int id) ? id : (int?)null)
                     .Where(id => id.HasValue)
                     .Select(id => id.Value)
                     .ToList() ?? new List<int>();

                KickApi kickApi = new KickApi(_kickApiSettings);
                var channels = await kickApi.Channels.GetChannelsByIdAsync(idbroadcasterUserIds);

                SetResult(JsonSerializer.Serialize(channels, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            ResetRestult();

            int categoryId = 0;

            int.TryParse(txtCategoryId.Text, out categoryId);

            KickApi kickApi = new KickApi(_kickApiSettings);
            bool isDone = await kickApi.Channels.UpdateChannelAsync(categoryId, txtTitle.Text);

            var result = "OK";

            if (!isDone)
                result = "KO";

            SetResult(result);
        }

        #endregion
    }
}
