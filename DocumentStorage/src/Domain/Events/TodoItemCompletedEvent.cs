namespace DocumentStorage.Domain.Events;

public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemCompletedEvent(DocumentVersion item)
    {
        Item = item;
    }

    public DocumentVersion Item { get; }
}