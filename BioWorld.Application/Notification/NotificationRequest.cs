namespace BioWorld.Application.Notification
{
    public class NotificationRequest<T> where T : class
    {
        public string AdminEmail { get; set; }
        public string EmailDisplayName { get; set; }
        public T Payload { get; set; }

        public MailMessageTypes MessageType { get; set; }

        public NotificationRequest(MailMessageTypes messageType, T payload)
        {
            MessageType = messageType;
            Payload = payload;
        }
    }
}
