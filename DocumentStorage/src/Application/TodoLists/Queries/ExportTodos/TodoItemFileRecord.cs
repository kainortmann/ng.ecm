using DocumentStorage.Application.Common.Mappings;
using DocumentStorage.Domain.Entities;

namespace DocumentStorage.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<DocumentVersion>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}