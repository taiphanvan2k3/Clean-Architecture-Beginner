using MiniATM.Entities.DomainEvents;

namespace MiniATM.Entities.DomainEventQueue
{
    public interface IDomainEventQueue<T> where T: DomainEvent
    {
        void Enqueue(T evt);
    }
}
