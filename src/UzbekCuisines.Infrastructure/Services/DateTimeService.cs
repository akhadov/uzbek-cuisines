

using UzbekCuisines.Application.Common.Interfaces;

namespace UzbekCuisines.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime UtcNow => DateTime.UtcNow;
}
