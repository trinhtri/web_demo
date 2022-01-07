using System;

namespace DGod.SuparCar.Application.Interfaces.Shared
{

    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
