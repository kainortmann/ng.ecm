using DocumentStorage.Application.Common.Exceptions;
using DocumentStorage.Application.TodoItems.Commands.CreateTodoItem;
using DocumentStorage.Application.TodoItems.Commands.DeleteTodoItem;
using DocumentStorage.Application.TodoLists.Commands.CreateTodoList;
using DocumentStorage.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace DocumentStorage.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateDocumentVersionCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<DocumentVersion>(itemId);

        item.Should().BeNull();
    }
}