
using System.Text.Json;

using KickNetLib.Api;

namespace KickNetLib.DesktopFormsTool.Controls
{
    public partial class UserAPIControl : BaseAPIControl
    {
        #region Constructor

        public UserAPIControl(Main parentForm) : base(parentForm) { InitializeComponent(); }

        #endregion

        #region Events

        private async void btnSearchByIds_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                List<int> idsUser = txtTermOfSearch.Text?
                  .Split(',', StringSplitOptions.RemoveEmptyEntries)
                  .Select(s => int.TryParse(s.Trim(), out int id) ? id : (int?)null)
                  .Where(id => id.HasValue)
                  .Select(id => id.Value)
                  .ToList() ?? new List<int>();

                KickApi kickApi = new KickApi(_kickApiSettings);
                var categories = await kickApi.Users.GetUserByIdsAsync(idsUser);

                SetResult(JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSearchMe_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                List<string> idsUser = txtTermOfSearch.Text.Split(',').ToList();

                KickApi kickApi = new KickApi(_kickApiSettings);
                var categories = await kickApi.Users.GetUserMeAsync();

                SetResult(JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true }));
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
