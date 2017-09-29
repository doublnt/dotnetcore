using WebSocketManage;

namespace WSMvcDemo.MessageHandlers
{
    public class NotificationsMessageHandler : WebSocketHandler
    {
        public NotificationsMessageHandler(WebSocketConnectionManager webSocketConnectionManager)
        : base(webSocketConnectionManager)
        {

        }
    }
}