namespace Escola.Shared.Entities
{
    public abstract class Notifiable
    {
        private readonly List<Notification> _notifications;

        protected Notifiable()
        {
            _notifications = new List<Notification>();
        }

        public IReadOnlyCollection<Notification> Notifications 
            => _notifications;

        public void AddNotification(Notification notification) 
            => _notifications.Add(notification);

        public void AddNotifications(IEnumerable<Notification> notifications) 
            => _notifications.AddRange(notifications);

        public bool IsValid() 
            => _notifications.Any().Equals(false);
    }
}
