using WebSocketManage;

namespace WSMvcDemo.MessageHandler
{
    public class NotificationMessageHandler : WebSocketHandler
    {
        public NotificationMessageHandler(WebSocketConnectionManager webSocketConnectionManager)
        : base(webSocketConnectionManager)
        {

        }
    }
}