namespace LawPanel.ApiClient.Models.HubNotifications
{
    public class NotificationFromHubData<TEntity>
    {
        public string   Type        { get; set; }
        public TEntity  Contents    { get; set; }
    }
}
