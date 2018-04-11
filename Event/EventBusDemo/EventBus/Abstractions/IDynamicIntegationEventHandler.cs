using System.Threading.Tasks;

namespace EventBusDemo.EventBus.Abstractions
{
    public interface IDynamicIntegationEventHandler
    {
         Task Handle(dynamic eventDate);
    }
}