
using System.Text.Json;

using KickNetLib.Api;

namespace KickNetLib.DesktopFormsTool.Controls
{
    public partial class CategoryAPIControl : BaseAPIControl
    {
        #region Constructor

        public CategoryAPIControl(Main parentForm) : base(parentForm) { InitializeComponent(); }

        #endregion

        #region Events

        private async void btnSearchByTerm_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                KickApi kickApi = new KickApi(_kickApiSettings);
                var categories = await kickApi.Categories.GetCategoriesAsync(txtTermOfSearch.Text);

                SetResult(JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSerachByID_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                int categoryId = 0;

                int.TryParse(txtIdCategory.Text, out categoryId);

                KickApi kickApi = new KickApi(_kickApiSettings);
                var categories = await kickApi.Categories.GetCategoryByIdAsync(categoryId);

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
