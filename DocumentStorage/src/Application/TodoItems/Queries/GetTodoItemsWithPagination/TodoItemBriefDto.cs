using DocumentStorage.Application.Common.Mappings;
using DocumentStorage.Domain.Entities;

namespace DocumentStorage.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<DocumentVersion>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}