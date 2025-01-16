namespace MiniATM.Entities.DomainEvents
{
    public class DomainEvent
    {
        public required DateOnly EventTimeUtc { get; set; }
    }
}
