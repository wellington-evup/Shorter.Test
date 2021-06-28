namespace Shorter.Core
{
    public class PushNotificationTemplate
    {
        public long Id { get; set; }
        public int NotificationType { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string ShortMessage { get; set; }
        public bool Inactive { get; set; }
        public int SendPushType { get; set; }
        public int SendSmsType { get; set; }
        public int SendEmailType { get; set; }
    }
}
