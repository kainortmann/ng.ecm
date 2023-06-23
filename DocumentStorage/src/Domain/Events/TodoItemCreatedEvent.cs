namespace DocumentStorage.Domain.Events;

public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(DocumentVersion item)
    {
        Item = item;
    }

    public DocumentVersion Item { get; }
}