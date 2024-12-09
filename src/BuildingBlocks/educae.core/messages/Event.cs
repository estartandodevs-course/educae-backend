using MediatR;

namespace educae.core.messages
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        public Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}