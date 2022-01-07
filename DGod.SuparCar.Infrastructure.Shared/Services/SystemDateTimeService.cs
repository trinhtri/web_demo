using DGod.SuparCar.Application.Interfaces.Shared;

namespace DGod.SuparCar.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}