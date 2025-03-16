
using System.Text.Json;

using KickNetLib.DesktopFormsTool.Models;
using KickNetLib.Api;
using KickNetLib.Api.ApiClients.V1.EventSuscriptions.Models;
using KickNetLib.Shared.Models.WebHooks;

namespace KickNetLib.DesktopFormsTool.Controls
{
    public partial class EventSuscriptionAPIControl : BaseAPIControl
    {
        #region Constructor

        public EventSuscriptionAPIControl(Main parentForm) : base(parentForm)
        {
            InitializeComponent();

            PopulateCheckedListBox();
        }

        #endregion

        #region Events

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                KickApi kickApi = new KickApi(_kickApiSettings);
                var eventSuscriptions = await kickApi.EventsSuscriptions.GetEventsSuscriptionsAsync();

                SetResult(JsonSerializer.Serialize(eventSuscriptions, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                KickApi kickApi = new KickApi(_kickApiSettings);

                List<EventType> events = new List<EventType>();
                foreach (EventTypeHelper item in chklEvents.CheckedItems)
                {
                    events.Add(item.Value);
                }

                var addEventResponse = await kickApi.EventsSuscriptions.SubscribeToEventsAsync(events, 1);

                SetResult(JsonSerializer.Serialize(addEventResponse, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDeleteByIds_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                List<string> idSusriptionEvents = string.IsNullOrEmpty(txtIdsSuscriptions.Text)
                ? new List<string>()  // return an empty list if the input is empty
                : txtIdsSuscriptions.Text.Split(',')
                        .Where(s => !string.IsNullOrWhiteSpace(s))  // optional: to remove empty or whitespace items
                        .ToList();

                KickApi kickApi = new KickApi(_kickApiSettings);
                var isDone = await kickApi.EventsSuscriptions.UnsubscribeEventsAsync(idSusriptionEvents);

                var result = "OK";

                if (!isDone)
                    result = "KO";

                SetResult(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRestult();

                KickApi kickApi = new KickApi(_kickApiSettings);
                bool isDone = await kickApi.EventsSuscriptions.UnsubscribeAllEventsAsync();

                var result = "OK";

                if (!isDone)
                    result = "KO";

                SetResult(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Methods

        private void PopulateCheckedListBox()
        {
            List<EventTypeHelper> eventTypesList = new List<EventTypeHelper>
            {
                new EventTypeHelper { Name = WebhookEventTypes.ChatMessageSent, Value = EventType.ChatMessageSent },
                new EventTypeHelper { Name = WebhookEventTypes.ChannelFollowed, Value = EventType.ChannelFollowed },
                new EventTypeHelper { Name = WebhookEventTypes.ChannelSubscriptionRenewal, Value = EventType.ChannelSubscriptionRenewal },
                new EventTypeHelper { Name = WebhookEventTypes.ChannelGiftedSubscription, Value = EventType.ChannelSubscriptionGifts },
                new EventTypeHelper { Name = WebhookEventTypes.ChannelNewSubscription, Value = EventType.ChannelSubscriptionNew },
                new EventTypeHelper { Name = WebhookEventTypes.LivestreamStatusUpdated, Value = EventType.LivestreamStatusUpdated },
            };

            foreach (var item in eventTypesList)
            {
                chklEvents.Items.Add(item);
            }


            chklEvents.DisplayMember = "Name";
        }

        #endregion
    }
}
