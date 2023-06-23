namespace DocumentStorage.Domain.Events;

public class TodoItemDeletedEvent : BaseEvent
{
    public TodoItemDeletedEvent(DocumentVersion item)
    {
        Item = item;
    }

    public DocumentVersion Item { get; }
}