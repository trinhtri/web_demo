using DGod.SuparCar.Application.Interfaces.Shared;
using System;

namespace DGod.SuparCar.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}