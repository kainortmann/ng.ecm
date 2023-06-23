using DocumentStorage.Application.Common.Interfaces;

namespace DocumentStorage.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}