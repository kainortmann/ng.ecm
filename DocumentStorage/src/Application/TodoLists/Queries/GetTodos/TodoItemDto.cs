using AutoMapper;
using DocumentStorage.Application.Common.Mappings;
using DocumentStorage.Domain.Entities;

namespace DocumentStorage.Application.TodoLists.Queries.GetTodos;

public class TodoItemDto : IMapFrom<DocumentVersion>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }

    public int Priority { get; set; }

    public string? Note { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DocumentVersion, TodoItemDto>()
            .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int) s.Priority));
    }
}