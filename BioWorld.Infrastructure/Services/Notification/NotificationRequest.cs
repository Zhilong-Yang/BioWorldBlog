namespace BioWorld.Infrastructure.Services.Notification
{
    public class NotificationRequest<T> where T : class
    {
        public string AdminEmail { get; set; }
        public string EmailDisplayName { get; set; }
        public T Payload { get; set; }

        public NotificationRequest(T payload)
        {
            Payload = payload;
        }
    }
}
