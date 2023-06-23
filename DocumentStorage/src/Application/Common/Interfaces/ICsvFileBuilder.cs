using DocumentStorage.Application.TodoLists.Queries.ExportTodos;

namespace DocumentStorage.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}