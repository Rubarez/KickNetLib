

using KickNetLib.Api.Models.Settings;

namespace KickNetLib.DesktopFormsTool.Controls
{
    public partial class BaseAPIControl : UserControl, IBaseAPIControl
    {
        #region Members

        protected KickApiSettings _kickApiSettings;

        protected readonly Main _parentForm;

        #endregion

        #region Constructor

        public BaseAPIControl(Main parentForm)
        {
            _parentForm = parentForm;

            _kickApiSettings = parentForm.KickApiSettings;

            InitializeComponent();
        }

        // Parameterless constructor (required for Designer)
        public BaseAPIControl()
        {
            // You can initialize the settings here if required, or leave them null
            _kickApiSettings = null;

            InitializeComponent();
        }

        #endregion

        #region Methods

        protected void ResetRestult()
        {
            Invoke(new Action(() =>
            {
                txtResults.Text = string.Empty;
            }));
        }

        protected void SetResult(string result)
        {
            Invoke(new Action(() =>
            {
                txtResults.Text = result;
            }));
        }

        #endregion

        #region Other events

        public void OnGlobalVariableChanged()
        {
            _kickApiSettings = _parentForm.KickApiSettings;

            ResetRestult();
        }

        #endregion
    }
}
