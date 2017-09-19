using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSMvcDemo.MessageHandlers;
namespace WSMvcDemo.Controllers
{
    public class MessageController : Controller
    {

        private NotificationMessageHandler _notificationsMessageHandler { get; set; }

        public MessageController(NotificationMessageHandler notificationsMessageHandler)
        {
            _notificationsMessageHandler = notificationsMessageHandler;
        }

        [HttpGet]
        public async Task SendMessage([FromQueryAttribute]string message)
        {
            await _notificationsMessageHandler.InvokeClientMethodToAllAsync("receiveMessage", message);
        }
    }
}