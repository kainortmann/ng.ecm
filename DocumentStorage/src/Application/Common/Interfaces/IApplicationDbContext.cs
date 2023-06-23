using DocumentStorage.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocumentStorage.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<DocumentVersion> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}