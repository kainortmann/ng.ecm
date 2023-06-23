using DocumentStorage.Application.TodoLists.Queries.GetTodos;
using DocumentStorage.Domain.Entities;
using DocumentStorage.Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace DocumentStorage.Application.IntegrationTests.TodoLists.Queries;

using static Testing;

public class GetTodosTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnPriorityLevels()
    {
        await RunAsDefaultUserAsync();

        var query = new GetTodosQuery();

        var result = await SendAsync(query);

        result.PriorityLevels.Should().NotBeEmpty();
    }

    [Test]
    public async Task ShouldReturnAllListsAndItems()
    {
        await RunAsDefaultUserAsync();

        await AddAsync(new TodoList
        {
            Title = "Shopping",
            Colour = Colour.Blue,
            Items =
            {
                new DocumentVersion {Title = "Apples", Done = true},
                new DocumentVersion {Title = "Milk", Done = true},
                new DocumentVersion {Title = "Bread", Done = true},
                new DocumentVersion {Title = "Toilet paper"},
                new DocumentVersion {Title = "Pasta"},
                new DocumentVersion {Title = "Tissues"},
                new DocumentVersion {Title = "Tuna"}
            }
        });

        var query = new GetTodosQuery();

        var result = await SendAsync(query);

        result.Lists.Should().HaveCount(1);
        result.Lists.First().Items.Should().HaveCount(7);
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetTodosQuery();

        var action = () => SendAsync(query);

        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}