using WebSocketManage;

namespace WSMvcDemo.MessageHandlers
{
    public class NotificationMessageHandler : WebSocketHandler
    {
        public NotificationMessageHandler(WebSocketConnectionManager webSocketConnectionManager)
        : base(webSocketConnectionManager)
        {

        }
    }
}