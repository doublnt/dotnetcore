using System.Threading.Tasks;

namespace EventBusDemo.EventBus.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
         Task Handle(dynamic eventDate);
    }
}