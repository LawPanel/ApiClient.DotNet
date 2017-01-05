namespace LawPanel.ApiClient.Models.HubNotifications
{
    public class NotificationFromHub<TEntity>
    {
        public NotificationFromHubData<TEntity> Data { get; set; }

        public NotificationFromHub(TEntity contents)
        {
            Data = new NotificationFromHubData<TEntity>
            {
                Type = typeof (TEntity).FullName,
                Contents = contents
            };
        }
    }
}