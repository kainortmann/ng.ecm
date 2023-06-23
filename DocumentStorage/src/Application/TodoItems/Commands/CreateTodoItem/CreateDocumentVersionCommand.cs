using DocumentStorage.Application.Common.Interfaces;
using DocumentStorage.Domain.Entities;
using DocumentStorage.Domain.Events;
using MediatR;

namespace DocumentStorage.Application.TodoItems.Commands.CreateTodoItem;

public record CreateDocumentVersionCommand : IRequest<int>
{
    public int ListId { get; init; }
    public string? Title { get; init; }
}

public class CreateDocumentVersionCommandHandler : IRequestHandler<CreateDocumentVersionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateDocumentVersionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateDocumentVersionCommand request, CancellationToken cancellationToken)
    {
        var entity = new DocumentVersion
        {
            ListId = request.ListId,
            Title = request.Title,
            Done = false
        };

        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.TodoItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}